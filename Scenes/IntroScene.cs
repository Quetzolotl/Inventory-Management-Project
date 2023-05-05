using Inventory_Management_Project.Core;
using System.Linq;

namespace Inventory_Management_Project.Scenes
{
    public sealed class IntroScene : Scene
    {
        private readonly List<DifficultyLevel> difficulties = new List<DifficultyLevel>
        {
            new DifficultyLevel("Easy", 1000),
            new DifficultyLevel("Medium", 750),
            new DifficultyLevel("Hard", 500),
            new DifficultyLevel("Extreme", 250),
        };

        public IntroScene(SceneManager sceneManager, DisplayManager displayManager) : base(sceneManager, displayManager)
        {

        }

        public override void Draw()
        {
            _displayManager.Clear();

            _displayManager.DisplayMessage("Welcome to Kiu's Emporium!");

            var selectedDifficulty = _displayManager.GetMenuOptionFromPlayer("Please select a difficulty", difficulties);

            _displayManager.DisplayInfo($"You chose the {selectedDifficulty.Label} difficulty. You'll start with {selectedDifficulty.StartingGold} GP");

            _displayManager.WaitForAnyInputFromPlayer(true);

            _sceneManager.ChangeScene<MainMenuScene>();
        }
    }
}
