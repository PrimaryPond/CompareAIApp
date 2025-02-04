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

        public Product(string name, double price, double rating, string description, string imgPath) {
            this.productName = name;
            this.productPrice = price;
            this.productRating = rating;
            this.productDesc = description;
            this.productImgPath = imgPath;
        }

        public void AddOtherInfo(String key, String value)
        {
            OtherInformation.Add(key, value);
        }

        public Dictionary<string,string>.KeyCollection GetKeys()
        {
            return OtherInformation.Keys;
        }

    }
}
