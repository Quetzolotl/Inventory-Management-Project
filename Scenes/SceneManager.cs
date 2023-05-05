using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_Project.Scenes
{
    public sealed class SceneManager
    {
        private Scene? _currentScene;

        public void ChangeScene(Type sceneType)
        {
            if (!_scenes.TryGetValue(sceneType, out var newScene))
            {
                throw new ArgumentException($"A scene of type {sceneType} was not found in the Scene Manager");
            }

            if (newScene == null)
            {
                throw new Exception($"A scene of type {sceneType} was found in the Scene Manager but it was null");
            }

            _currentScene = newScene;

            _currentScene.Draw();
        }

        public void ChangeScene<TScene>()
        {
            ChangeScene(typeof(TScene));
        }

        public void DrawCurrentScene()
        {
            _currentScene?.Draw();
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
    }
}
