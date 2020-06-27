using System;
using System.Collections.Generic;

namespace _ShopiXamarin.Data
{
    public class Product
    {
        public string Id { get; set; }

        public int CloudId { get; set; }

        public string ProductName { get; set; }

        public string Headline { get; set; }

        public decimal ListPrice { get; set; }

        public decimal StrikeOutPrice { get; set; }

        public bool InStock { get; set; }

        public bool IsShipmentFree { get; set; }

        public Picture Picture { get; set; }

        public List<Picture> Pictures { get; set; }

        public string Sku { get; set; }
    }
}
