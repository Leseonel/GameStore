using GameStore.Filters;
using System.Collections.Generic;

namespace GameStore.ValidateData
{
    public static class ValidateFilter
    {
        public static List<GameFilter> ValidateFilters(List<GameFilter> gameFilters)
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
