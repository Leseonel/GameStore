using GameStore.Data.Repositories.CartRepository;
using GameStore.Models;
using System.Threading.Tasks;
using System;

namespace GameStore.Services
{
    public class CartsService
    {
        private readonly ICartRepository _cartRepository;

        public CartsService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public Task<CartModel> GetAllItemsFromCart(Guid cartId)
        {
            return _cartRepository.GetAllItemsFromCart(cartId);
        }
        public Task AddGameToCart(OrderModel order)
        {
            return _cartRepository.AddGameToCart(order);
        }
        public Task DecreaseAmountOfGame(Guid gameId, Guid userId, Guid cartId)
        {
            return _cartRepository.DecreaseAmountOfGame(gameId, userId, cartId);
        }
        public Task IncreaseAmountOfGame(Guid gameId, Guid userId, Guid cartId)
        {
            return _cartRepository.IncreaseAmountOfGame(gameId, userId, cartId);
        }
        public Task RemoveGameFromCart(Guid gameId, Guid userId, Guid cartId)
        {
            return _cartRepository.RemoveGameFromCart(gameId, userId, cartId);
        }
        public Task<OrderContactsInfoModel> AddContactInfoToOrder(OrderContactsInfoModel contact)
        {
            return _cartRepository.AddContactInfoToOrder(contact);
        }
    }
}
