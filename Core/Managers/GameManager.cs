﻿using Inventory_Management_Project.Scenes;
using Inventory_Management_Project.Scenes.Shop;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_Project.Core.Managers
{
    public sealed class GameManager
    {
        private readonly SceneManager _sceneManager;
        private readonly DisplayManager _displayManager;
        private readonly IServiceProvider _serviceProvider;

        public GameManager(SceneManager sceneManager, DisplayManager displayManager, IServiceProvider serviceProvider)
        {
            _sceneManager = sceneManager;
            _displayManager = displayManager;
            _serviceProvider = serviceProvider;

            InitializeScenes();
        }

        public void Start()
        {
            try
            {
                _sceneManager.ChangeScene<IntroScene>();
            }
            catch (Exception ex)
            {
                _displayManager.DisplayError($"There was an unexpected problem. {ex.Message}");

                var shouldShowMoreInfo = _displayManager.GetYesNoFromPlayer("Would you like more info?");

                if (shouldShowMoreInfo)
                {
                    _displayManager.DisplayError(ex.StackTrace ?? "No additional info");
                    _displayManager.WaitForAnyInputFromPlayer();
                }
            }
        }

        private void InitializeScenes()
        {
            _sceneManager.AddScene(_serviceProvider.GetRequiredService<ExitGameScene>());
            _sceneManager.AddScene(_serviceProvider.GetRequiredService<IntroScene>());
            _sceneManager.AddScene(_serviceProvider.GetRequiredService<MainMenuScene>());
            _sceneManager.AddScene(_serviceProvider.GetRequiredService<ShopMainScene>());
            _sceneManager.AddScene(_serviceProvider.GetRequiredService<ShopSellToPlayerScene>());
            _sceneManager.AddScene(_serviceProvider.GetRequiredService<ShopBuyFromPlayerScene>());
            _sceneManager.AddScene(_serviceProvider.GetRequiredService<InventoryScene>());
        }
    }
}
