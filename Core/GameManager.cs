using Inventory_Management_Project.Scenes;
using Inventory_Management_Project.Scenes.Shop;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_Project.Core
{
    public sealed class GameManager
    {
        private readonly SceneManager _sceneManager;
        private readonly IServiceProvider _serviceProvider;

        public GameManager(SceneManager sceneManager, IServiceProvider serviceProvider)
        {
            _sceneManager = sceneManager;
            _serviceProvider = serviceProvider;

            InitializeScenes();
        }

        public void Start()
        {
            _sceneManager.ChangeScene<IntroScene>();
        }

        private void InitializeScenes()
        {
            _sceneManager.AddScene(_serviceProvider.GetRequiredService<ExitGameScene>());
            _sceneManager.AddScene(_serviceProvider.GetRequiredService<IntroScene>());
            _sceneManager.AddScene(_serviceProvider.GetRequiredService<MainMenuScene>());
            _sceneManager.AddScene(_serviceProvider.GetRequiredService<ShopMainScene>());
            _sceneManager.AddScene(_serviceProvider.GetRequiredService<ShopSellToPlayerScene>());
        }

        private void OnExitGameRequested()
        {
            Environment.Exit(0);
        }
    }
}
