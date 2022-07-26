using Data.Entities;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class FournisseurController : ControllerBase
    {
        private readonly IFournisseurService fournisseurService;
        private readonly UserManager<Utilisateur> _userManager;
        private readonly IConfiguration configuration;
        private readonly IMailingService mailingService;

        public FournisseurController(IFournisseurService _FournisseurService, UserManager<Utilisateur> userManager, IConfiguration configuration, IMailingService mailingService)
        {
            fournisseurService = _FournisseurService;
           _userManager = userManager;
            this.configuration = configuration;
            this.mailingService = mailingService;
        }
        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModelFournisseur model)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await fournisseurService.RegisterAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);
            var user = await _userManager.FindByEmailAsync(result.Email);
            var confirmEmailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var encodedEmailToken = Encoding.UTF8.GetBytes(confirmEmailToken);
            var validEmailToken = WebEncoders.Base64UrlEncode(encodedEmailToken);
            string url = $"https://localhost:44353/api/User/confirmemail?userid={user.Id}&token={validEmailToken}";
            var filePath = $"{Directory.GetCurrentDirectory()}\\Templates\\EmailTemplate.html";
            var str = new StreamReader(filePath);

            var mailText = str.ReadToEnd();
            str.Close();

            mailText = mailText.Replace("[username]", user.UserName).Replace("[email]", user.Email).Replace("[URL]", url);

            await mailingService.SendEmailAsync(user.Email, "Welcome to BigSoft" +
                "", mailText);
            return Ok(result);
        }
        [HttpPost("token")]
        public async Task<IActionResult> GetTokenAsync([FromBody] TokenRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await fournisseurService.Login(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }
        [Authorize]
        [HttpGet]
        public IQueryable GetAll()
        {


            return (fournisseurService.GetAll().AsQueryable());
        }
        [Authorize]
        // DELETE: api/Applications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await fournisseurService.Delete(id);

                return Ok(StatusCode(200));
            }
            catch (Exception)
            {

                return Ok(StatusCode(400));
            }

        }
        [Authorize]
        [HttpPut("Update")]
        public async Task<IActionResult> Update(string id, Fournisseur entity)
        {
            try
            {
                await fournisseurService.Update(id, entity);

                return Ok(StatusCode(200));
            }
            catch (Exception)
            {

                return Ok(StatusCode(400));
            }
          

        }
        [Authorize]
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Fournisseur>> Details(string id)
        {
            var Entity = await fournisseurService.GetById(id);

            if (Entity == null)
            {
                return NotFound();
            }

            return Entity;

        }
        [AllowAnonymous]
        [HttpGet("ForgetPassword")]
        public async Task<UserManagerResponseModel> ForgetPasswordAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return new UserManagerResponseModel
                {
                    IsSuccess = false,
                    Message = "No user associated with email",
                };

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var encodedToken = Encoding.UTF8.GetBytes(token);
            var validToken = WebEncoders.Base64UrlEncode(encodedToken);



            return new UserManagerResponseModel
            {
                IsSuccess = true,
                Message = "Reset password URL has been sent to the email successfully!",
                token = validToken
            };
        }
    }
}
