using Data.Entities;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Services.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly UserManager<Utilisateur> _userManager;
        private readonly IConfiguration configuration;
        private readonly IMailingService mailingService;
        private readonly IGrossisteService grossisteService;

        public UserController(IUserService _UserService, UserManager<Utilisateur> userManager, IConfiguration configuration, IMailingService mailingService, IGrossisteService _GrossisteService)
        {

            userService = _UserService;
            _userManager = userManager;
            this.configuration = configuration;
            this.mailingService = mailingService;
            grossisteService = _GrossisteService;
        }


        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModelUser model)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await userService.RegisterAsync(model);


            if (!result.IsAuthenticated)
                return BadRequest(result.Message);
            //Confirmations mail
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
            var result = new AuthModel();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = await _userManager.FindByEmailAsync(model.Email);
            var role = _userManager.IsInRoleAsync(user, "Grossiste").Result;
            if (role)
            {
                result = await grossisteService.Login(model);
                return Ok(result);

               
            }
            else
            {
                result = await userService.Login(model);

             
            }
            if (!result.IsAuthenticated)
                return BadRequest(result.Message);


            return Ok(result);
        }

        [HttpGet]

        [AllowAnonymous]
        public IQueryable GetAll()
        {


            return (userService.GetAll().AsQueryable());
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await userService.Delete(id);

                return Ok(StatusCode(200));
            }
            catch (Exception)
            {

                return Ok(StatusCode(400));
            }

        }
        [Authorize]
        [HttpPut("Update")]
        public async Task<IActionResult> Update(string id, Utilisateur utilisateur)
        {
            try
            {
                await userService.Update(id, utilisateur);

                return Ok(StatusCode(200));
            }
            catch (Exception e)
            {

                return Ok(StatusCode(400));
            }

        }
        [Authorize]
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Utilisateur>> Details(string id)
        {
            var Entity = await userService.GetById(id);

            if (Entity == null)
            {
                return NotFound();
            }

            return Entity;

        }

        [HttpGet("Get/Email/{email}")]
        public async Task<ActionResult<Utilisateur>> GetByEmail(string email)
        {
            var Entity = await userService.GetByEmail(email);

            if (Entity == null)
            {
                return NotFound();
            }

            return Entity;

        }
        [HttpGet("Get/UserName/{UserName}")]
        public async Task<ActionResult<Utilisateur>> GetByUserName(string userName)
        {
            var Entity = await userService.GetByUserName(userName);

            if (Entity == null)
            {
                return NotFound();
            }

            return Entity;

        }
        [Authorize]
        [HttpPost("ResetP")]
        public async Task<IActionResult> ChangerPassWord([FromBody] PasswordModel passwordModel)
        {
            var user = await _userManager.FindByIdAsync(passwordModel.id);

            if (user != null)
            {
                var token = new AuthModel();

                var model = new TokenRequestModel { Email = user.Email, Password = passwordModel.OldPassword };
                token = await userService.Login(model);
                if (token.Token != null)
                {
                    var PassWordToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var result = await _userManager.ResetPasswordAsync(user, PassWordToken, passwordModel.NewPassword);
                    return Ok(token);
                }
                else
                {
                    token.Message = "Ancienne mot de passe est faux";
                    return BadRequest(token.Message);
                }


            }



            return Ok(StatusCode(400));

        }
        [AllowAnonymous]
        [HttpGet("confirmemail")]
        public async Task<IActionResult> ConfirmEmail(string userid, string token)
        {
            if (userid == null || token == null)
            {
                return BadRequest();
            }

            var user = await _userManager.FindByIdAsync(userid);
            if (user == null)
            {
                return BadRequest("User Cannot be found");
            }
            var decodedToken = WebEncoders.Base64UrlDecode(token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);
            var result = await _userManager.ConfirmEmailAsync(user, normalToken);
            if (result.Succeeded)
            {
                return Redirect($"{configuration["AppUrl"]}/Templates/confirmemail.html");
            }


            return BadRequest("Email cannot be confirmed");
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
        [HttpGet("calculer")]
        public async Task<IActionResult> Calculer(float prix, float transport)
        {
            var x = (prix * 1.19 + transport * 1.07) * 6;

            return Ok(x);
        }

    }
}
