
using System;
using System.Collections.Generic;

namespace MetaDataSearch.ConsoleApp.Entrities
{
    public class Organization
    {

        public int _id { get; set; }
        public string url { get; set; }
        public string external_id { get; set; }
        public string name { get; set; }
        public List<string> domain_names { get; set; }
        public DateTime created_at { get; set; }
        public string details { get; set; }
        public bool shared_tickets { get; set; }
        public List<string> tags { get; set; }



    }
}
