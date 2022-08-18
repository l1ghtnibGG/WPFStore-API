using System;
using System.Collections.Generic;

namespace StoreWPF
{
    [Serializable]
    internal class StoreData
    {
        public List<Product> Products { get; set; }

        public static StoreData Data;
    }
}