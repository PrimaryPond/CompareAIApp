using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows;

namespace CompareAI
{
    internal class General
    {
        public static List<Product> Products = new List<Product>();
        public static Product productSelectOne;
        public static Product productSelectTwo;
        private static ApiKeyManager _apiKeyManager = null;

        public static string APICall(string prompt)
        {


            return "";

            /*
             {
                

             }
             
             
             
             
             
             */
        }
        public static void setApi(ApiKeyManager api)
        {
            _apiKeyManager = api;
        }
        public static string serialize()
        {
            string jsonString = JsonSerializer.Serialize(Products);

            return jsonString;

        }

        public static void deserialize(string json)
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.IncludeFields = true;
            List<Product>? attempt = JsonSerializer.Deserialize<List<Product>>(json, options);

            if (attempt != null) {
                Products = attempt;
            }
        }

        
    }
}
