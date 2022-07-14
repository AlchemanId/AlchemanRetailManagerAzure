using ARMDataManager.Library.DataAccess;
using ARMDataManager.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ARMApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Cashier")]
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration _config;

        public ProductController(IConfiguration config)
        {
            this._config = config;
        }
        public List<ProductModel> Get()
        {
            ProductData data = new ProductData(_config);

            return data.GetProducts();
        }
    }
}
