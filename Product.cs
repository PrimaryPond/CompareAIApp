using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareAI
{

    internal class Product
    {
        public string productName = "";
        public float productPrice = 0;
        public float productRating = 0;
        public string productDesc = "";
        public string productImgPath = "";
        public Dictionary<string, string> OtherInformation = new Dictionary<String, String>();

        public Product(string name, float price, float rating, string description, string imgPath) {
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
