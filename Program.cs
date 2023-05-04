
using Inventory_Management_Project.Core;
using Inventory_Management_Project.Scenes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Inventory_Management_Project
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices();

            var gameManager = serviceProvider.GetService<GameManager>();
            gameManager?.Start();
        }

        private static ServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<GameManager>();
            serviceCollection.AddSingleton<SceneManager>();
            serviceCollection.AddSingleton<DisplayManager>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}