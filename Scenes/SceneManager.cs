using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_Project.Scenes
{
    public sealed class SceneManager
    {
        public event Action? OnExitGameRequest;

        private Scene? _currentScene;

        public void ChangeScene<TScene>()
        {
            if (_currentScene != null)
            {
                _currentScene.OnExitGameRequest -= OnExitGameRequested;
            }

            if (!_scenes.TryGetValue(typeof(TScene), out var newScene))
            {
                throw new ArgumentException($"A scene of type {typeof(TScene)} was not found in the Scene Manager");
            }

            if (newScene == null)
            {
                throw new Exception($"A scene of type {typeof(TScene)} was found in the Scene Manager but it was null");
            }

            _currentScene = newScene;
            _currentScene.OnExitGameRequest += OnExitGameRequested;
        }

        public void DrawCurrentScene()
        {
            _currentScene?.Draw();
        }

        private void OnExitGameRequested()
        {
            OnExitGameRequest?.Invoke();
        }

        private readonly Dictionary<Type, Scene> _scenes = new Dictionary<Type, Scene>();
        public void AddScene(Scene scene)
        {
            if (_scenes.ContainsKey(scene.GetType()))
            {
                throw new ArgumentException($"A scene of type {scene.GetType()} has already been added to the scene manager", nameof(scene));
            }

            _scenes.Add(scene.GetType(), scene);
        }

        public void AddScene<TScene>() where TScene : Scene, new()
        {
            AddScene(new TScene());
        }
    }
}
