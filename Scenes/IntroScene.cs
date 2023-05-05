using Inventory_Management_Project.Core;
using Inventory_Management_Project.Core.Menus;
using System.Linq;

namespace Inventory_Management_Project.Scenes
{
    public sealed class IntroScene : Scene
    {
        private readonly List<GenericDataMenuOption<Difficulty>> difficulties = new List<GenericDataMenuOption<Difficulty>>
        {
            new GenericDataMenuOption<Difficulty>("Easy Peasy", new Difficulty(Difficulty.DifficultyLevel.Easy, 1000)),
            new GenericDataMenuOption<Difficulty>("Test Your Mettle", new Difficulty(Difficulty.DifficultyLevel.Easy, 750)),
            new GenericDataMenuOption<Difficulty>("No Pain, No Gain", new Difficulty(Difficulty.DifficultyLevel.Easy, 500)),
            new GenericDataMenuOption<Difficulty>("Insanity Awaits", new Difficulty(Difficulty.DifficultyLevel.Easy, 250)),
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

            var selectedOption = _displayManager.GetMenuOptionFromPlayer($"How challenging would you like your adventure, {_player.Name}?", difficulties);

            _displayManager.DisplayEmptyLine();
            _displayManager.DisplayInfo($"You chose the {selectedOption.Label} difficulty. You'll start with {selectedOption.Data.StartingGold} GP");

            _player.SetDifficulty(selectedOption.Data);

            _displayManager.WaitForAnyInputFromPlayer();

            _sceneManager.ChangeScene<MainMenuScene>();
        }
    }
}
