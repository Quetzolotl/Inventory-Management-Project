﻿
using Inventory_Management_Project.Core;
using Inventory_Management_Project.Scenes;
using Inventory_Management_Project.Scenes.Shop;
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

            // Core
            serviceCollection.AddSingleton<GameManager>();
            serviceCollection.AddSingleton<SceneManager>();

            serviceCollection.AddTransient<DisplayManager>();
            serviceCollection.AddTransient<IDataService, FileSystemDataService>();

            serviceCollection.AddSingleton<Player>();

            // Scenes - This should also be registered in the Game Manager
            serviceCollection.AddSingleton<ExitGameScene>();
            serviceCollection.AddSingleton<IntroScene>();
            serviceCollection.AddSingleton<MainMenuScene>();
            serviceCollection.AddSingleton<ShopMainScene>();
            serviceCollection.AddSingleton<ShopSellToPlayerScene>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}