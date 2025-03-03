using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;
using CompareAI;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WpfApp1;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

class GeminiApiClient
{
    private static string API_KEY = "YOUR_GEMINI_API_KEY";
    private static string API_URL = "";

    public static async Task<string> startAPI(ApiKeyManager api, string productname)
    {
        API_KEY = api.GetApiKey();
        API_URL = "https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent?key=" + API_KEY;
        string requestData = $@"{{
            ""contents"": [
                {{
                    ""role"": ""user"",
                    ""parts"": [
                        {{
                            ""text"": ""Get information about {productname}.""
                        }}
                    ]
                }}
            ],
            ""generationConfig"": {{
                ""temperature"": 1,
                ""topK"": 40,
                ""topP"": 0.95,
                ""maxOutputTokens"": 8192,
                ""responseMimeType"": ""application/json"",
                ""responseSchema"": {{
                    ""type"": ""object"",
                    ""properties"": {{
                        ""productName"": {{
                            ""type"": ""string"",
                            ""description"": ""The name of the product, including the brand""
                        }},
                        ""productReviews"": {{
                            ""type"": ""integer"",
                            ""format"": ""int32"",
                            ""description"": ""The number of reviews""
                        }},
                        ""productRating"": {{
                            ""type"": ""number"",
                            ""format"": ""double"",
                            ""description"": ""The average rating""
                        }},
                        ""productShortDesc"": {{
                            ""type"": ""string"",
                            ""description"": ""The product description""
                        }},
                        ""productLongDesc"": {{
                            ""type"": ""string"",
                            ""description"": ""The product description""
                        }}
                    }},
                    ""required"": [
                        ""productName"",
                        ""productReviews"",
                        ""productRating"",
                        ""productShortDesc"",
                        ""productLongDesc""
                    ]
                    }}
                }}
            }}";

        try 
        {
            MessageBox.Show("starting");
            string response = await GetInformation(requestData, "provide information about the " + productname + ", including specifications, ratings, number of reviews, and defining features.");
            MessageBox.Show("done");
            File.WriteAllText(Environment.CurrentDirectory + "\\..\\..\\..\\lib\\hello.txt", response);
            System.Diagnostics.Debug.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n--------------------\n\\n\n\n");
            System.Diagnostics.Debug.WriteLine(response);
            return response;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        return "";


    }
    public static async Task<string> findmultipleproducts(ApiKeyManager api, string productname)
    {
        API_KEY = api.GetApiKey();
        API_URL = "https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent?key=" + API_KEY;
        string requestData = $@"{{
            ""contents"": [
                            {{
                                ""role"": ""user"",
                                ""parts"": [
                                    {{
                                        ""text"": ""Get information about the best {productname}.""
                                    }}
                                ]
                            }}
                        ],
                        ""generationConfig"": {{
                            ""temperature"": 1,
                            ""topK"": 40,
                            ""topP"": 0.95,
                            ""maxOutputTokens"": 8192,
                            ""responseMimeType"": ""application/json"",
                            ""responseSchema"": {{
          ""type"": ""array"",
          ""items"": {{
            ""type"": ""object"",
            ""properties"": {{
              ""productName"": {{
                ""type"": ""string"",
                ""description"": ""The specific name for the product.""
              }},
              ""OtherInformation"": {{
                ""type"": ""array"",
                ""items"": {{
                  ""type"": ""string"",
                   ""description"": ""A list of features that are beneficial.""
                }}
              }},
              ""productRating"": {{
                ""type"": ""number"",
                ""description"": ""The 5 star rating for the product(1-5).""
              }},
              ""productPrice"": {{
                ""type"": ""number"",
                ""description"": ""The average price for the product.""
              }},
              ""productShortDesc"": {{
                ""type"": ""string"",
                ""description"": ""A short description of the product.""
              }},
              ""productLongDesc"": {{
                ""type"": ""string"",
                ""description"": ""A paragaph description of the product.""
              }}
            }},
            ""required"": [
              ""productName"",
              ""OtherInformation"",
              ""productRating"",
              ""productPrice"",
              ""productShortDesc"",
              ""productLongDesc""
            ]
          }},
          ""minItems"": 3,
          ""maxItems"": 3,
          ""description"": ""A list of the 3 best products based on functionality, along with a short description of why they are included.""
        }}
    }}
}}";

        
        try
        {
            MessageBox.Show("starting");
            string response = await GetInformation(requestData, "provide information about the " + productname + ", including specifications, ratings, number of reviews, and defining features.");
            MessageBox.Show("done");
            File.WriteAllText(Environment.CurrentDirectory + "\\..\\..\\..\\lib\\hello.txt", response);
            System.Diagnostics.Debug.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n--------------------\n\\n\n\n");
            System.Diagnostics.Debug.WriteLine(response);
            return response;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        

        return "";
    }

    static async Task<string> GetInformation(string requestData, string prompt)
    {
        using (var client = new HttpClient())
        {
            var requestBody = new 
            {
                contents = new[] 
                {
                    new 
                    {
                        parts = new[] 
                        {
                            new 
                            {
                                text = prompt
                            }
                        }
                    }
                }
            };
           
            
            //var json = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(requestData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(API_URL, content);
            //var responseContent = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<dynamic>(responseContent);
                
                return result.candidates[0].content.parts[0].text.ToString();
            }
            else
            {
              
                throw new HttpRequestException($"API call failed with status code: {response.StatusCode} AND {response.Content}");
            }
        }
    }
}
