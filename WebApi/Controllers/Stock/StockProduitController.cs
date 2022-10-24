using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockProduitController : ControllerBase
    {
        private readonly IStockProduitService stockProduitService;

        public StockProduitController(IStockProduitService _StockProduitService)
        {
            stockProduitService = _StockProduitService;
        }
        //[Authorize]
    }
}
