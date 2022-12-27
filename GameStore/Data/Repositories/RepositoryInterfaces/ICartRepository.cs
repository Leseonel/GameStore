using GameStore.Models;
using System.Threading.Tasks;
using System;

namespace GameStore.Data.Repositories.RepositoryInterfaces
{
    public interface ICartRepository
    {
        Task<CartModel> GetAllItemsFromCart(Guid cartId);
        Task AddGameToCart(OrderModel order);
        Task DecreaseAmountOfGame(Guid gameId, Guid userId, Guid cartId);
        Task IncreaseAmountOfGame(Guid gameId, Guid userId, Guid cartId);
        Task RemoveGameFromCart(Guid gameId, Guid userId, Guid cartId);
        Task<OrderContactsInfoModel> AddContactInfoToOrder(OrderContactsInfoModel contact);
    }
}
