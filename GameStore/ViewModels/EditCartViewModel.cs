using System;

namespace GameStore.ViewModels
{
    public class EditCartViewModel
    {
        public Guid UserId { get; set; }

        public Guid GameId { get; set; }

        public Guid CartId { get; set; }

        public int AmountOfGames { get; set; }
    }
}
