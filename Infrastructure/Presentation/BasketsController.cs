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
    public class BasketsController(IserviceManager serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetBasketById(string userId)
        {
            var result = await serviceManager.BasketService.GetBasketAsync(userId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBasket(BasketDto basketDto)
        {
            var result = await serviceManager.BasketService.UpdateBasketAsync(basketDto);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket(string userId)
        {
            await serviceManager.BasketService.DeleteBasketAsync(userId);
            return NoContent();
        }
    }
}
