using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IserviceManager _serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery]ProductSpecificationParameters productSpecificationParameters)
        {
            var result = await _serviceManager.ProductService.GetAllProductsAsync(productSpecificationParameters);
            if (result is null) return BadRequest();
            return Ok(result);
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var result = await _serviceManager.ProductService.GetProductByIdAsync(id);
            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpGet("brands")]
        public async Task<IActionResult> GetAllBrands()
        {
            var result = await _serviceManager.ProductService.GetAllBrandsAsync();
            if (result is null) return BadRequest();
            return Ok(result);
        }
        [HttpGet("types")]
        public async Task<IActionResult> GetAllTypes()
        {
            var result = await _serviceManager.ProductService.GetAllTypesAsync();
            if (result is null) return BadRequest();
            return Ok(result);
        }
    }
}
