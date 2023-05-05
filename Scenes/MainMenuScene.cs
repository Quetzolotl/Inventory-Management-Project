using Inventory_Management_Project.Core;
using Inventory_Management_Project.Core.Menus;
using Inventory_Management_Project.Scenes.Shop;
using Microsoft.Extensions.Logging;

namespace Inventory_Management_Project.Scenes
{
    public sealed class MainMenuScene : Scene
    {
        private readonly List<SceneMenuOption> _menuOptions = new List<SceneMenuOption>
        {
            new SceneMenuOption("Shop", typeof(ShopMainScene)),
            new SceneMenuOption("Exit", typeof(ExitGameScene))
        };

        public MainMenuScene(Player player, SceneManager sceneManager, DisplayManager displayManager) : base(player, sceneManager, displayManager)
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