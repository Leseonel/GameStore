using GameStore.Data.Repositories.RepositoryInterfaces;
using GameStore.Models;
using System.Threading.Tasks;
using System;
using GameStore.Services.ServiceInterfaces;
using GameStore.Data.UnitOfWork;
using GameStore.ViewModels;

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
        public Task EditOrder(EditCartViewModel editedOrder)
        {
            return _cartRepository.EditOrder(editedOrder);
        }
        public Task RemoveGameFromCart(Guid gameId, Guid userId, Guid cartId)
        {
            return _cartRepository.RemoveGameFromCart(gameId, userId, cartId);
        }
        public Task<FinishedOrdersModel> FinishOrder(FinishedOrdersModel contact)
        {
            return _cartRepository.FinishOrder(contact);
        }
    }
}
