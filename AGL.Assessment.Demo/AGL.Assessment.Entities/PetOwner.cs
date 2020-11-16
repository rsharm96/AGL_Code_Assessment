using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AGL.Assessment.Entities
{
    public class PetOwner
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "gender")]
        public string Gender { get; set; }
        [JsonProperty(PropertyName = "age")]
        public int Age { get; set; }
        [JsonProperty(PropertyName = "pets")]
        public List<Pet> Pets { get; set; }
    }
}
