using Data.Entities;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
    public class GrossisteController : ControllerBase
    {
        private readonly IGrossisteService grossisteService;
        private readonly UserManager<Utilisateur> _userManager;
        private readonly IConfiguration configuration;
        private readonly IMailingService mailingService;
        private readonly IWebHostEnvironment hostingEnvironment;

        public GrossisteController(IGrossisteService _grossisteService, UserManager<Utilisateur> userManager, IConfiguration configuration, IMailingService mailingService, IWebHostEnvironment hostingEnvironment)
        {
            grossisteService = _grossisteService;
            _userManager = userManager;
            this.configuration = configuration;
            this.mailingService = mailingService;
            this.hostingEnvironment = hostingEnvironment;
        }
        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromForm] RegisterModelGrossiste model)
        {try {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);


                List<Document> emp = new List<Document>();
                string uniqueFileName = null;
                if (model.Documents != null)
                {

                    Document employe = new Document();
                    // The file must be uploaded to the images folder in wwwroot
                    // To get the path of the wwwroot folder we are using the injected
                    // IHostingEnvironment service provided by ASP.NET Core
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Files");
                    // To make sure the file name is unique we are appending a new
                    // GUID value and and an underscore to the file name
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Documents.FileName;
                    string filePathImage = Path.Combine(uploadsFolder, uniqueFileName);
                    // Use CopyTo() method provided by IFormFile interface to
                    // copy the file to wwwroot/images folder
                    model.Documents.CopyTo(new FileStream(filePathImage, FileMode.Create));
                    employe.Filepath = uniqueFileName;
                    emp.Add(employe);


                }


                var result = await grossisteService.RegisterAsync(model);

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

               //// await mailingService.SendEmailAsync(user.Email, "Welcome to BigSoft" +
               //     "", mailText);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

           
        }


        [HttpPost("Token")]
        public async Task<IActionResult> GetTokenAsync([FromBody] TokenRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await grossisteService.Login(model);
          
            if (!result.IsAuthenticated)
                return BadRequest(result.Message);
            if (!result.IsConfirmed)
            {
                return BadRequest("email not yet confirmed");
            }
            return Ok(result);
        }
        [Authorize]
        [HttpGet]
        public IQueryable GetAll()
        {


            return (grossisteService.GetAll().AsQueryable());
        }
        [Authorize]

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await grossisteService.Delete(id);

                return Ok(StatusCode(200));
            }
            catch (Exception)
            {

                return Ok(StatusCode(400));
            }

        }


        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromForm] RegisterModelGrossiste model)
        {
            if (ModelState.IsValid)
            {
                List<Document> emp = new List<Document>();
                string uniqueFileName = null;
                if (model.Documents != null)
                {

                    Document employe = new Document();
                    // The file must be uploaded to the images folder in wwwroot
                    // To get the path of the wwwroot folder we are using the injected
                    // IHostingEnvironment service provided by ASP.NET Core
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Files");
                    // To make sure the file name is unique we are appending a new
                    // GUID value and and an underscore to the file name
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Documents.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    // Use CopyTo() method provided by IFormFile interface to
                    // copy the file to wwwroot/images folder
                    model.Documents.CopyTo(new FileStream(filePath, FileMode.Create));
                    employe.Filepath = uniqueFileName;
                    emp.Add(employe);


                }
                var Grossiste = new Grossiste
                {
                    UserName = model.Username,
                    Email = model.Email,
                    Identifiant_fiscale = model.Identifiant_fiscale,
                    Adresse = model.Adresse,
                    BirthDate = model.BirthDate,
                    Civility = model.Civility,
                    PhoneNumber = model.Numbureau.ToString(),
                    NumMobile = model.NumMobile,
                    CodePostale = model.CodePostale,
                    Numbureau = model.Numbureau,
                    Rib = model.Rib,
                    EmailPersAContact = model.emailPersAContact,
                    Gouvernorats = model.Gouvernorats,
                    NomPersAContact = model.Nom,
                    PrenomPersAContact = model.Prenom,
                    SiteWeb = model.SiteWeb,
                    NumFax = model.NumFax,
                    Nom = model.Nom,
                    Prenom = model.Prenom,
                    RaisonSocial = model.RaisonSocial,
                    Documents = emp,




                };
                var result =  grossisteService.Update(model.id, Grossiste);
                return Ok(result);

            }



            return Ok(StatusCode(400));
        }
        [Authorize]
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Grossiste>> Details(string id)
        {
            var Entity = await grossisteService.GetById(id);

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
                    Message = "No Grossiste associated with email",
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
