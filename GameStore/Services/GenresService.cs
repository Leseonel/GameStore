using GameStore.Data;
using GameStore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Services
{
    public class GenresService
    {
        private readonly GameStoreContext _context;
        public GenresService(GameStoreContext context)
        {
            _context = context;
        }
    }
}