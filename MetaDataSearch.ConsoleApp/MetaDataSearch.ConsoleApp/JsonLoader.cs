using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace MetaDataSearch.ConsoleApp
{
    public class JsonLoader<T> where T : class
    {

        public IList<T> LodJsonData(string fileName)
        {
            var jsonString = File.ReadAllText(string.Format(@".\appdata\{0}", fileName));
            var result = JsonConvert.DeserializeObject<IList<T>>(jsonString);
            return result;
        }

    }
}
