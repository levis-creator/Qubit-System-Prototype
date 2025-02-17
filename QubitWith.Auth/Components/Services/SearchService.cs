using System;
using System.Collections.Generic;
using System.Linq;

namespace QubitWith.Auth.Components.Services
{
    public class SearchService<T>
    {
        /// <summary>
        /// Filters a collection based on a search term and a list of properties to search.
        /// </summary>
        /// <param name="source">The collection to filter.</param>
        /// <param name="searchTerm">The search term.</param>
        /// <param name="propertySelectors">A list of property selectors to search.</param>
        /// <returns>A filtered collection.</returns>
        public IEnumerable<T> Search(IEnumerable<T> source, string searchTerm, params Func<T, string>[] propertySelectors)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return source; // Return the full list if the search term is empty
            }

            return source.Where(item =>
                propertySelectors.Any(selector =>
                    selector(item)?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false
                )
            );
        }
    }
}
