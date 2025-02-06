using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CompareAI
{
    internal class General
    {
        public static List<Product> Products = new List<Product>();
        public static string APICall(string prompt)
        {


            return "";

            /*
             {
                

             }
             
             
             
             
             
             */
        }

        public static string serialize()
        {
            string jsonString = JsonSerializer.Serialize(Products);

            return jsonString;

        }

        public static void deserialize(string json)
        {
            List<Product>? attempt = JsonSerializer.Deserialize<List<Product>>(json);

            if (attempt != null) {
                Products = attempt;
            }
        }

       




    }
}
