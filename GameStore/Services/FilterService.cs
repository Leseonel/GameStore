﻿using GameStore.Data;
using GameStore.Filters.Enums;
using GameStore.Filters;
using GameStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace GameStore.Services
{
    public class FilterService
    {
        private readonly GameStoreContext _context;
        public FilterService(GameStoreContext context)
        {
            _context = context;
        }
        public Task<List<GameModel>> FilterGamesByName(List<GameFilter> gamesFilters)
        {
            gamesFilters = ValidateFilters(gamesFilters);

            var games = _context.Games.AsQueryable();

            foreach (var filter in gamesFilters)
            {
                if (filter.PropertyType == FilteringGame.Name)
                {
                    games = ApplyNameFilters(games, filter);
                }
            }
            return games.ToListAsync();
        }
        public Task<List<GamesAndGenresModel>> FilterGamesByGenreId(List<GameFilter> gamesFilters)
        {
            gamesFilters = ValidateFilters(gamesFilters);

            var games = _context.GamesAndGenres.AsQueryable();

            foreach (var filter in gamesFilters)
            {
                if (filter.PropertyType == FilteringGame.Id)
                {
                    games = ApplyIdFilters(games, filter);
                }
            }
            return games.ToListAsync();
        }

        private IQueryable<GamesAndGenresModel> ApplyIdFilters(IQueryable<GamesAndGenresModel> genres, GameFilter gameFilter)
        {
            return genres.Where(game => game.GenreId == Int32.Parse(gameFilter.PropertyValue));
        }

        private IQueryable<GameModel> ApplyNameFilters(IQueryable<GameModel> games, GameFilter gameFilter)
        {
            return games.Where(game => game.GameName.Contains(gameFilter.PropertyValue));
        }

        private List<GameFilter> ValidateFilters(List<GameFilter> gameFilters)
        {
            if (gameFilters == null)
            {
                return new List<GameFilter>();
            }

            foreach (var filter in gameFilters)
            {
                filter.PropertyValue ??= "";
            }
            return gameFilters;
        }
    }
}