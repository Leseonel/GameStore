using GameStore.Models;
using System.Threading.Tasks;
using System;
using GameStore.ViewModels;

namespace GameStore.Services.ServiceInterfaces
{
    public interface ICartsService
    {
        Task<CartModel> GetAllItemsFromCart(Guid cartId);
        Task AddGameToCart(OrderModel order);
        Task EditOrder(EditCartViewModel editedOrder);
        Task RemoveGameFromCart(Guid gameId, Guid userId, Guid cartId);
        Task<FinishedOrdersModel> FinishOrder(FinishedOrdersModel contact);
    }
}
