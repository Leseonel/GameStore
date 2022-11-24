using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Models
{
    public class GenreModel
    {
        [Key]
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public int GenreParentId { get; set; }
    }
}