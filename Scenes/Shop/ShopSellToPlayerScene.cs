using Inventory_Management_Project.Core;

namespace Inventory_Management_Project.Scenes.Shop
{
    public sealed class ShopSellToPlayerScene : Scene
    {
        public ShopSellToPlayerScene(SceneManager sceneManager, DisplayManager displayManager) : base(sceneManager, displayManager)
        {
        }

        public override void Draw()
        {
            base.Draw();

            _displayManager.DisplayWarning("Not Implemented");

            _displayManager.WaitForAnyInputFromPlayer(true);
        }
    }
}