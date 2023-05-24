namespace IntShopDomain.Models
{
        public class Product
        {
            public int ProductID { get; set; }

            public string Product_name { get; set; } = string.Empty;

            public string Product_description { get; set; } = string.Empty;

            public decimal? Price { get; set; } 

            public decimal? Assessment { get; set; }
        
            public int? TestID { get; set; } 

        }
}
