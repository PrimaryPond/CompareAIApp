using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareAI
{

    internal class Product
    {
        public string productName { get; set; }
        public double productRating { get; set; }
        public double productPrice { get; set; }
        public string productDesc { get; set; }
        public string productImgPath = "";
        public Dictionary<string, string> OtherInformation = new Dictionary<String, String>();

        public Product(string productName, double productPrice, double productRating, string productDesc, string productImgPath) {
            this.productName = productName;
            this.productPrice = productPrice;
            this.productRating = productRating;
            this.productDesc = productDesc;
            this.productImgPath = productImgPath;
        }

        public void AddOtherInfo(String key, String value)
        {
            OtherInformation.Add(key, value);
        }

        public Dictionary<string,string>.KeyCollection GetKeys()
        {
            return OtherInformation.Keys;
        }

        override
        public string ToString() { return productName; }

    }
}
