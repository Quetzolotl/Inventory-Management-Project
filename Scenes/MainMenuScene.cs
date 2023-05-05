using Inventory_Management_Project.Core;

namespace Inventory_Management_Project.Scenes
{
    public class MainMenuScene : Scene
    {

        public MainMenuScene(SceneManager sceneManager, DisplayManager displayManager) : base(sceneManager, displayManager)
        {

        }

        public override void Draw()
        {
            _displayManager.Clear();

            _displayManager.DisplayWarning("Not implemented");

            _displayManager.WaitForAnyInputFromPlayer(true);
        }
    }
}