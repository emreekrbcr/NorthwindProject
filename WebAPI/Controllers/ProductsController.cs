using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = CheckRequestResult(_productService.GetAll());
            return result;
        }

        //[HttpGet("getbyid")]
        //public IActionResult Get(int id)
        //{
        //    return CheckRequestResult(() => _productService.GetById(id));
        //}

        [HttpPost("add")]
        public IActionResult Post(Product product)
        {
            return CheckRequestResult(_productService.Add(product));
        }

        private IActionResult CheckRequestResult(IResult result)
        {
            if (result.Success)
            {
                return new OkObjectResult(result);
            }

            return new BadRequestObjectResult(result);
        }
    }
}
