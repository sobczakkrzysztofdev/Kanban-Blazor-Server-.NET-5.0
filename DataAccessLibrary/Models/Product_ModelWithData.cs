using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.Models
{
    public class Product_ModelWithData
    {
        public int PRODUCT_ID { get; set; }
        public string PRODUCT_NAME { get; set; }
        public string PRODUCT_NUMBER { get; set; }
        public string PRODUCT_COMMENT { get; set; }
        public string PRODUCT_PHOTO { get; set; }

    }

    public class ProductData
    {
        public List<Product_ModelWithData> Data
        {
            get { return data; }
            set { data = value; }
        }

        private List<Product_ModelWithData> data = new List<Product_ModelWithData> {
            new Product_ModelWithData() { PRODUCT_ID = 1, PRODUCT_NAME = "RED", PRODUCT_NUMBER = "R1246", PRODUCT_PHOTO = "/Files/red.png"},
            new Product_ModelWithData() { PRODUCT_ID = 1, PRODUCT_NAME = "YELLOW", PRODUCT_NUMBER = "Y624752", PRODUCT_PHOTO = "/Files/yellow.png"},
            new Product_ModelWithData() { PRODUCT_ID = 1, PRODUCT_NAME = "GREEN", PRODUCT_NUMBER = "G48275", PRODUCT_PHOTO = "/Files/green.png"},
            new Product_ModelWithData() { PRODUCT_ID = 1, PRODUCT_NAME = "BLUE", PRODUCT_NUMBER = "B495687", PRODUCT_PHOTO = "/Files/blue.png"},
            new Product_ModelWithData() { PRODUCT_ID = 1, PRODUCT_NAME = "WHITE", PRODUCT_NUMBER = "W85957", PRODUCT_PHOTO = "/Files/white.png"},
        };
    }
}
