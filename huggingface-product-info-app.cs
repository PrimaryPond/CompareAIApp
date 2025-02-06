using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProductInfoApp
{
    public class ProductInfoService
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private const string HuggingFaceApiUrl = "https://api-inference.huggingface.co/models/facebook/opt-350m";

        public async Task<string> GetProductInformationAsync(string productName, string apiKey)
        {
            _httpClient.DefaultRequestHeaders.Authorization = 
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

            try
            {
                var prompt = $"Provide detailed information about the product: {productName}. " +
                             "Include description, key features, potential uses, and any notable characteristics.";

                var requestBody = new
                {
                    inputs = prompt,
                    parameters = new { max_new_tokens = 250 }
                };

                var jsonRequest = JsonSerializer.Serialize(requestBody);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(HuggingFaceApiUrl, content);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                var responseArray = JsonSerializer.Deserialize<string[]>(responseBody);

                return responseArray?[0] ?? "No information available.";
            }
            catch (Exception ex)
            {
                return $"Error retrieving product information: {ex.Message}";
            }
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            var productService = new ProductInfoService();

            Console.Write("Enter your Hugging Face API Key: ");
            var apiKey = Console.ReadLine();

            while (true)
            {
                Console.Write("Enter a product name (or 'exit' to quit): ");
                var productName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(productName) || productName.ToLower() == "exit")
                    break;

                try
                {
                    var productInfo = await productService.GetProductInformationAsync(productName, apiKey);
                    Console.WriteLine("\nProduct Information:");
                    Console.WriteLine(productInfo);
                    Console.WriteLine("\n-------------------\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}
