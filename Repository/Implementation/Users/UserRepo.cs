﻿using Data;
using Data.Entities;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApi.Helpers;
using WebApi.Models;

namespace Repository.Implementation
{
    public class UserRepo : IUserRepo
    {
        private readonly BigSoftContext bigSoftContext;
        private readonly IGenericRepository<Utilisateur> genericRepository;
        private readonly UserManager<Utilisateur> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly JWT _jwt;

        public UserRepo(BigSoftContext _bigSoftContext, IGenericRepository<Utilisateur> _genericRepository, UserManager<Utilisateur> _userManager, RoleManager<IdentityRole> _roleManager, IOptions<JWT> jwt)
        {
            bigSoftContext = _bigSoftContext;
            genericRepository = _genericRepository;
            userManager = _userManager;
            roleManager = _roleManager;
            _jwt = jwt.Value;
        }

        public async Task<AuthModel> GetTokenAsync(TokenRequestModel model)
        {
            var authModel = new AuthModel();

            var user = await userManager.FindByEmailAsync(model.Email);

            if (user is null || !await userManager.CheckPasswordAsync(user, model.Password))
            {
                authModel.Message = "Email or Password is incorrect!";
                return authModel;
            }

            var jwtSecurityToken = await CreateJwtToken(user);
            var rolesList = userManager.GetRolesAsync(user).Result.First();

            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Email = user.Email;
            authModel.Username = user.UserName;
            authModel.ExpiresOn = jwtSecurityToken.ValidTo;
            authModel.Role = rolesList;

            return authModel;
        }

        public async Task<Utilisateur> getUserByEmail(string email)
        {
            var user = await bigSoftContext.Utilisateurs.SingleOrDefaultAsync(c => c.NormalizedEmail == email.ToUpper());
            if (user != null) { return user; }

            return null;
        }

        public async Task<Utilisateur> getUserByUserName(string UserName)
        {
            var user = await bigSoftContext.Utilisateurs.SingleOrDefaultAsync(c => c.UserName == UserName);
            if (user != null) { return user; }

            return null;
        }

        public async Task PutAsync(string id,Utilisateur entity)
        {
            var user = await bigSoftContext.Utilisateurs.SingleAsync(user => user.Id == id);
            user.Prenom = entity.Prenom;
            user.UserName = entity.UserName;
            user.Nom = entity.Nom;
            user.NumMobile = entity.NumMobile;
            user.Adresse = entity.Adresse;
            user.Gouvernorats = entity.Gouvernorats;
            user.Civility = entity.Civility;
            user.CodePostale = entity.CodePostale;
            user.Email = entity.Email;
            user.BirthDate = entity.BirthDate;
            user.Image = entity.Image;
            user.UserName = entity.UserName;
            try
            {
                bigSoftContext.Utilisateurs.Update(user);
                 await bigSoftContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<AuthModel> RegisterAsync(RegisterModelUser model)
        {
            //Testing for Email
            if (await userManager.FindByEmailAsync(model.Email) != null)
                return new AuthModel { Message = "Email is already registered!" };
            //Testing for UserName
            if (await userManager.FindByNameAsync(model.Username) != null)
                return new AuthModel { Message = "Username is already registered!" };
            //User Creation

            var user = new Utilisateur
            {
                UserName = model.Username,
                Email = model.Email,
                Nom = model.Nom,
                Prenom = model.Prenom,
                Adresse = model.Adresse,
                BirthDate = model.BirthDate,
                Civility = model.Civility,
                CodePostale = model.CodePostale,
                Gouvernorats = model.Gouvernorats,

                NumMobile = model.NumMobile
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                var errors = string.Empty;

                foreach (var error in result.Errors)
                    errors += $"{error.Description},";

                return new AuthModel { Message = errors };
            }
            //Testing and creating Role
            if (await roleManager.RoleExistsAsync("Utilisateur"))
            {
                await userManager.AddToRoleAsync(user, "Utilisateur");
            }
            else
            {
                IdentityRole identityrole = new IdentityRole
                {
                    Name = "Utilisateur"

                };
                await roleManager.CreateAsync(identityrole);
                await userManager.AddToRoleAsync(user, "Utilisateur");

            }
            var jwtSecurityToken = await CreateJwtToken(user);


            return new AuthModel
            {
                Email = user.Email,
                ExpiresOn = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Role = "Utilisateur",
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Username = user.UserName
            };
        }
        private async Task<JwtSecurityToken> CreateJwtToken(Utilisateur user)
        {
            var userClaims = await userManager.GetClaimsAsync(user);
            var roles = await userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }

    }
}
