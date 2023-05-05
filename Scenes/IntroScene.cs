using Inventory_Management_Project.Core;
using System.Linq;

namespace Inventory_Management_Project.Scenes
{
    public sealed class IntroScene : Scene
    {
        private readonly List<DifficultyLevel> difficulties = new List<DifficultyLevel>
        {
            new DifficultyLevel("Easy Peasy ", 1000),
            new DifficultyLevel("Test Your Mettle", 750),
            new DifficultyLevel("No Pain, No Gain", 500),
            new DifficultyLevel("Insanity Awaits", 250),
        };

        public IntroScene(Player player, SceneManager sceneManager, DisplayManager displayManager) : base(player, sceneManager, displayManager)
        {

        }

        public override void Draw()
        {
            base.Draw();

            _displayManager.DisplayMessage("What should I call you?");

            var playerName = _displayManager.GetInputFromPlayer();

            _player.AssignName(playerName?.Trim() ?? "Unknown");

            _displayManager.DisplayEmptyLine();

            var selectedDifficulty = _displayManager.GetMenuOptionFromPlayer($"How challenging would you like your adventure, {_player.Name}?", difficulties);

            _displayManager.DisplayEmptyLine();
            _displayManager.DisplayInfo($"You chose the {selectedDifficulty.Label} difficulty. You'll start with {selectedDifficulty.StartingGold} GP");

            _player.AddGold(selectedDifficulty.StartingGold);

            _displayManager.WaitForAnyInputFromPlayer();

            _sceneManager.ChangeScene<MainMenuScene>();
        }
    }
}
