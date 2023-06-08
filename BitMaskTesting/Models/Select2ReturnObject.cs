using Newtonsoft.Json;
using System.Collections.Generic;

namespace BitMaskTesting.Models
{
    public class Select2ReturnObject<T> where T : Select2ReturnBase
    {
        [JsonProperty("results")]
        public List<T> Results { get; set; }
    }

    public class Select2Item : Select2ReturnBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class Select2Group : Select2ReturnBase
    {
        [JsonProperty("children")]
        public List<Select2Item> Children { get; set; }
    }

    public class Select2ReturnBase
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
