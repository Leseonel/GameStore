using GameStore.Filters.Enums;
using System;

namespace GameStore.Filters
{
    public class EditGameGenres
    {
        public Guid GenreId { get; set; }
        public EditTypeValue EditType { get; set; }
    }
}
