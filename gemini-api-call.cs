using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WpfApp1;

class GeminiApiClient
{
    private static string API_KEY = "YOUR_GEMINI_API_KEY";
    private static string API_URL = "";

    public static async Task startAPI(ApiKeyManager api)
    {
        API_KEY = api.GetApiKey();
        API_URL = "https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent?key=" + API_KEY;

        try 
        {
            MessageBox.Show(API_URL);
            string response = await GetIphoneInformation();
            MessageBox.Show("done");
            File.WriteAllText(Environment.CurrentDirectory + "\\..\\..\\..\\lib\\hello.txt", response);
            System.Diagnostics.Debug.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n--------------------\n\\n\n\n");
            System.Diagnostics.Debug.WriteLine(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static async Task<string> GetIphoneInformation()
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
                                text = "provide information about the iphone 13, including specifications, reviews, and defining features."
                            }
                        }
                    }
                }
            };

            var json = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(API_URL, content);
            
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
