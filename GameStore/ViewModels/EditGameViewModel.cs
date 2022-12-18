using GameStore.Models;
using System.Collections.Generic;
using System;
using GameStore.Filters;

namespace GameStore.ViewModels
{
    public class EditGameViewModel
    {
        public Guid GameId { get; set; }

        public string GameName { get; set; }

        public string GameDeveloper { get; set; }

        public string GamePublisher { get; set; }

        public double GamePrice { get; set; }

        public string GameDescription { get; set; }

        public string GameImgUrl { get; set; }

        public DateTime GameReleaseDate { get; set; }

        public IList<EditGameGenres> UpdateGameGenres { get; set; } = new List<EditGameGenres>();
    }
}
