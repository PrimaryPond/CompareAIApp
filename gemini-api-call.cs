using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CompareAI;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WpfApp1;
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
                            ""description"": ""The name of the product""
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
                        ""productDesc"": {{
                            ""type"": ""string"",
                            ""description"": ""The product description""
                        }}
                    }},
                    ""required"": [
                        ""productName"",
                        ""productReviews"",
                        ""productRating"",
                        ""productDesc""
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
          ""type"": ""array"",
          ""items"": {{
            ""type"": ""object"",
            ""properties"": {{
              ""product_name"": {{
                ""type"": ""string"",
                ""description"": ""The name of the product.""
              }},
              ""reason"": {{
                ""type"": ""string"",
                ""description"": ""A brief explanation of why this product is considered one of the best based on functionality.""
              }},
              ""features"": {{
                ""type"": ""array"",
                ""items"": {{
                  ""type"": ""string"",
                   ""description"": ""A list of features that are beneficial.""
                }}
              }}
            }},
            ""required"": [
              ""product_name"",
              ""reason"",
              ""features""
            ]
          }},
          ""minItems"": 7,
          ""maxItems"": 7,
          ""description"": ""A list of the 7 best products based on functionality, along with a short description of why they are included.""
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
           
            
            var json = JsonConvert.SerializeObject(requestBody);
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
                throw new HttpRequestException($"API call failed with status code: {response.StatusCode}");
            }
        }
    }
}
