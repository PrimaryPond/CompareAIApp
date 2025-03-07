
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;
namespace CompareAI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : Application
    {
        public IConfiguration Configuration { get; private set; }
        public static IServiceProvider ServiceProvider { get; private set; }
        protected override void OnStartup(StartupEventArgs e)
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                //.AddJsonFile($"appsettings.{GetEnvironmentName()}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
            var mainWindow = ServiceProvider.GetRequiredService<ResultsPage>();
            mainWindow.Show();

            
        }
        
        private void ConfigureServices(IServiceCollection services)
        {
            // Register your services
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<ApiKeyManager>();
            services.AddTransient<ResultsPage>();
            // Add other services...
        }
    }
    public class ApiKeyManager
    {
        private readonly IConfiguration _configuration;
        public ApiKeyManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetApiKey()
        {
            return _configuration.GetSection("ApiKeys")["Gemini"];
        }
    }
}