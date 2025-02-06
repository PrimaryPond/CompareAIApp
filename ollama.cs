using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OllamaProductInfoApp
{
    public class ProductInfoService
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private const string OllamaApiUrl = "http://localhost:11434/api/generate";

        public ProductInfoService()
        {
            
        }

        public static async Task<string> GetProductInformationAsync(string productName)
        {
            try
            {
                var prompt = $"Provide detailed information about the product: {productName}. " +
                             "Include description, key features, potential uses, and any notable characteristics.";

                var requestBody = new
                {
                    model = "llama2",
                    prompt = prompt,
                    stream = false
                };

                var jsonRequest = JsonSerializer.Serialize(requestBody);
                var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(OllamaApiUrl, content);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                var responseObject = JsonSerializer.Deserialize<OllamaResponse>(responseBody);

                return responseObject?.Response ?? "No information available.";
            }
            catch (Exception ex)
            {
                return $"Error retrieving product information: {ex.Message}";
            }
        }
    }

    public class OllamaResponse
    {
        public string Response { get; set; }
    }
    /*
    class Program
    {
        static async Task Main(string[] args)
        {
            var productService = new ProductInfoService();

            while (true)
            {
                Console.Write("Enter a product name (or 'exit' to quit): ");
                var productName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(productName) || productName.ToLower() == "exit")
                    break;

                try
                {
                    var productInfo = await productService.GetProductInformationAsync(productName);
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
    }*/
}
