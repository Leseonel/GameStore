using GameStore.Models;
using GameStore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace GameStore.Controllers
{
    [Route("api/[controller]")]
    public class CartsController : Controller
    {
        private readonly CartsService _cartsService;
        public CartsController(CartsService cartsService)
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
        [Route("AddContactToOrder")]
        public async Task<IActionResult> AddContactInfoToOrder([FromBody] OrderContactsInfoModel contact)
        {
            await _cartsService.AddContactInfoToOrder(contact);
            return Ok();
        }
        [HttpPost]
        [Route("DecreaseGameAmount")]
        public async Task<IActionResult> DecreaseAmountOfGame(Guid gameId, Guid userId, Guid cartId)
        {
            await _cartsService.DecreaseAmountOfGame(gameId, userId, cartId);
            return Ok();
        }
        [HttpPost]
        [Route("IncreaseGameAmount")]
        public async Task<IActionResult> IncreaseAmountOfGame(Guid gameId, Guid userId, Guid cartId)
        {
            await _cartsService.IncreaseAmountOfGame(gameId, userId, cartId);
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
