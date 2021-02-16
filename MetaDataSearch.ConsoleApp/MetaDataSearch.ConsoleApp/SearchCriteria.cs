using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDataSearch.ConsoleApp
{
    public class SearchCriteria
    {
        public string PropertyName { get; set; }
        public string PropertyType { get; set; }
        public object SearchValue { get; set; }
    }
}
