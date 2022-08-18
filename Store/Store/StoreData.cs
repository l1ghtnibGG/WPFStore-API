using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Store
{
    [Serializable]
    public class StoreData
    {
        public List<Product> Products { get; set; }
    }
}
