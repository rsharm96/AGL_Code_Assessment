using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AGL.Assessment.Entities
{
    public class Pet
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }
}
