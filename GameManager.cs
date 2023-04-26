using Inventory_Management_Project.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_Project
{
    public class GameManager
    {
        private readonly Type _defaultSceneType = typeof(MainMenuScene);

        private readonly SceneManager _sceneManager;

        private bool isInGame = false;

        public GameManager(SceneManager sceneManager)
        {
            _sceneManager = sceneManager;
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

        private static void InitializeScenes(SceneManager _sceneManager)
        {
            _sceneManager.AddScene<MainMenuScene>();
        }

        private void OnExitGameRequested()
        {
            isInGame = false;
        }
    }
}
