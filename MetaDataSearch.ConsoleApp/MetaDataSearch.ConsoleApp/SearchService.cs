using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MetaDataSearch.ConsoleApp
{
    public class SearchService<T> where T : class
    {
        private SearchCriteria searchCriteria;

        public SearchService(string searchProperty, object searchValue)
        {
            searchCriteria = typeof(T).GetProperties().Where(x => x.Name == searchProperty)
                                    .Select(prop => new SearchCriteria
                                    {
                                        PropertyName = prop.Name,
                                        PropertyType = prop.PropertyType.Name,
                                        SearchValue = prop.PropertyType.IsGenericType ? Convert.ChangeType(searchValue, prop.PropertyType.GetGenericArguments()[0])
                                                                                                       : Convert.ChangeType(searchValue, prop.PropertyType)
                                    }).FirstOrDefault();
        }

        public IEnumerable<T> PerformSearch(IEnumerable<T> searchList)
        {
            var prop = typeof(T).GetProperty(searchCriteria.PropertyName);

            if (prop != null)
            {
                return searchList.Where(x =>
                     prop.PropertyType.IsGenericType ? ((IList)prop.GetValue(x)).Contains(searchCriteria.SearchValue)
                     : prop.GetValue(x).Equals(searchCriteria.SearchValue));
            }
            return null;
        }

    }
}
