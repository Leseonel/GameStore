using GameStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using GameStore.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using GameStore.ViewModels;

namespace GameStore.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CartsController : Controller
    {
        private readonly ICartsService _cartsService;
        public CartsController(ICartsService cartsService)
        {
            _cartsService = cartsService;
        }
        [HttpGet]
        [Route("GetAllCartItems")]
        public async Task<IActionResult> GetAllItemsFromCart(Guid cartId)
        {
            return new OkObjectResult(await _cartsService.GetAllItemsFromCart(cartId));
        }
        [HttpPost]
        [Route("AddGameToCart")]
        public async Task<IActionResult> AddGameToCart([FromBody] OrderModel order)
        {
            await _cartsService.AddGameToCart(order);
            return Ok();
        }
        [HttpPost]
        [Route("FinishOrder")]
        public async Task<IActionResult> FinishOrder([FromBody] FinishedOrdersModel contact)
        {
            await _cartsService.FinishOrder(contact);
            return Ok();
        }
        [HttpPost]
        [Route("EditOrder")]
        public async Task<IActionResult> EditOrder(EditCartViewModel editedOrder)
        {
            await _cartsService.EditOrder(editedOrder);
            return Ok();
        }
        [HttpDelete]
        [Route("RemoveCartGame")]
        public async Task<IActionResult> RemoveGameFromCart(Guid gameId, Guid userId, Guid cartId)
        {
            await _cartsService.RemoveGameFromCart(gameId, userId, cartId);
            return Ok();
        }
    }
}
