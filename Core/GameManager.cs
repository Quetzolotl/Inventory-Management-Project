using Inventory_Management_Project.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_Project.Core
{
    public class GameManager
    {
        private readonly SceneManager _sceneManager;
        private readonly DisplayManager _displayManager;

        private bool isInGame = false;

        public GameManager(SceneManager sceneManager, DisplayManager displayManager)
        {
            _sceneManager = sceneManager;
            _displayManager = displayManager;
            _sceneManager.OnExitGameRequest += OnExitGameRequested;
            InitializeScenes(_sceneManager);
        }

        public void Start()
        {
            _sceneManager.ChangeScene<MainMenuScene>();

            isInGame = true;

            while (isInGame)
            {
                _sceneManager.DrawCurrentScene();
            }
        }

        private void InitializeScenes(SceneManager _sceneManager)
        {
            _sceneManager.AddScene(new MainMenuScene(_displayManager));
        }

        private void OnExitGameRequested()
        {
            isInGame = false;
        }
    }
}
