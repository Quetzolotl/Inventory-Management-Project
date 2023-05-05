using Inventory_Management_Project.Core;
using Inventory_Management_Project.Core.Menus;
using Microsoft.Extensions.Logging;

namespace Inventory_Management_Project.Scenes
{
    public sealed class MainMenuScene : Scene
    {
        private readonly List<SceneMenuOption> _menuOptions = new List<SceneMenuOption>
        {
            new SceneMenuOption("Shop", typeof(ShopScene))
        };

        public MainMenuScene(SceneManager sceneManager, DisplayManager displayManager) : base(sceneManager, displayManager)
        {

        }

        public override void Draw()
        {
            base.Draw();

            var selectedOption = _displayManager.GetMenuOptionFromPlayer("Where would you like to go?", _menuOptions);

            _sceneManager.ChangeScene(selectedOption.SceneType);
        }
    }
}