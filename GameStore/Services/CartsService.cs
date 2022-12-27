using GameStore.Data.Repositories.RepositoryInterfaces;
using GameStore.Models;
using System.Threading.Tasks;
using System;
using GameStore.Services.ServiceInterfaces;
using GameStore.Data.UnitOfWork;

namespace GameStore.Services
{
    public class CartsService : ICartsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICartRepository _cartRepository;

        public CartsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _cartRepository = _unitOfWork.Carts;
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
