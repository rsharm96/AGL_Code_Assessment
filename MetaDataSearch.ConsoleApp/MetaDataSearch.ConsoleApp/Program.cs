using MetaDataSearch.ConsoleApp.Entrities;
using System.Linq;

namespace MetaDataSearch.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SearchService<Organization> searchService = new SearchService<Organization>("shared_tickets", false);
            var jsonLoader = new JsonLoader<Organization>();

            var OrgList = jsonLoader.LodJsonData("organizations.json");

            var res = searchService.PerformSearch(OrgList).ToList();
        }

    }
}
