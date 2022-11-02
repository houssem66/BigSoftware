using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using System;
using System.IO;
using System.Text;

namespace WebApi.Controllers.MailingAndPdf
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfController : ControllerBase
    {
        private readonly IConverter _converter;
        private readonly IRepositoryWrapper repository;

        public PdfController(IConverter converter, IRepositoryWrapper repository )
        {
            _converter = converter;
            this.repository = repository;
        }
        [Authorize]
        [HttpGet]
        public IActionResult CreatePDF()
        {string html = System.IO.File.ReadAllText("C:\\Users\\Mega-PC\\source\\repos\\BigSoftware\\Nouveau document texte.html");
            var employees = repository.ClientRepo.FindByCondition(x => x.IdGrossiste == "c86a1981-8b10-4e81-9bec-97649cf938a1");
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>This is the generated PDF report!!!</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Name</th>
                                        <th>LastName</th>
                                        <th>Age</th>
                                        <th>Gender</th>
                                    </tr>");

            foreach (var emp in employees)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                  </tr>", emp.Email, emp.Adresse, emp.Adresse, emp.Adresse);
            }

            sb.Append(@"
                                </table>
                            </body>
                        </html>");
            try
            {
                var globalSettings = new GlobalSettings
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings { Top = 10 },
                    DocumentTitle = "PDF Report",
                    Out = @"C:\Users\Mega-PC\Downloads\Employee_Report.pdf" // USE THIS PROPERTY TO SAVE PDF TO A PROVIDED LOCATION
                };

                var objectSettings = new ObjectSettings
                {
                    PagesCount = true,
                    HtmlContent = html,
                    //Page = "https://stackoverflow.com/questions/64761155/unable-to-resolve-synchronizedconverter-in-dot-net-core-2-0-web-app-when-using", //USE THIS PROPERTY TO GENERATE PDF CONTENT FROM AN HTML PAGE
                    WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "Utility", "styles.css") },
                    HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                    FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
                };

                var pdf = new HtmlToPdfDocument()
                {
                    GlobalSettings = globalSettings,
                    Objects = { objectSettings }
                };

                //_converter.Convert(pdf); IF WE USE Out PROPERTY IN THE GlobalSettings CLASS, THIS IS ENOUGH FOR CONVERSION

                var file = _converter.Convert(pdf);

                //return Ok("Successfully created PDF document.");
                //return File(file, "application/pdf", "EmployeeReport.pdf");
                return File(file, "application/pdf");
            }
            catch (Exception e)
            {
                return BadRequest("el expction");
            }

        }
      
    }
}
