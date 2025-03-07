﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CompareAI
{

    public class Product
    {
        public string productName { get; set; }
        public double productRating { get; set; }
        public double productPrice { get; set; }
        public string productShortDesc { get; set; }
        public string productLongDesc { get; set; }
        public List<string> OtherInformation { get; set; }
        public string productImgPath = "";

        [JsonConstructor]
        private Product() { }

        public Product(string productName, double productPrice, double productRating, string productShortDesc, string productLongDesc, List<string> OtherInformation)
        {
            this.productName = productName;
            this.productPrice = productPrice;
            this.productRating = productRating;
            this.productShortDesc = productShortDesc;
            this.productLongDesc = productLongDesc;
            this.OtherInformation = OtherInformation;

        }

        public Product(string productName, double productPrice, double productRating, string productShortDesc, string productImgPath) {
            this.productName = productName;
            this.productPrice = productPrice;
            this.productRating = productRating;
            this.productShortDesc = productShortDesc;
            this.productImgPath = productImgPath;
        }

        public Product(string productName, double productPrice, double productRating, string productShortDesc)
        {
            this.productName = productName;
            this.productPrice = productPrice;
            this.productRating = productRating;
            this.productShortDesc = productShortDesc;
            this.productLongDesc = productLongDesc;
            this.OtherInformation = null;
        }

        public void AddOtherInfo(String value)
        {
            OtherInformation.Add(value);
        }
        override
        public string ToString() { return productName; }

    }
}
