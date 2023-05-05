using Inventory_Management_Project.Core;
using Inventory_Management_Project.Core.Menus;
using System.Linq;

namespace Inventory_Management_Project.Scenes
{
    public sealed class IntroScene : Scene
    {
        private readonly IEnumerable<GenericDataMenuOption<Difficulty>> _difficultyMenuOptions;

        public IntroScene(Player player, SceneManager sceneManager, DisplayManager displayManager, IDataService dataService) : base(player, sceneManager, displayManager)
        {
            var difficulties = dataService.LoadData<IEnumerable<Difficulty>>("difficulties");

            difficulties ??= new List<Difficulty>();

            _difficultyMenuOptions = difficulties.Select(d => new GenericDataMenuOption<Difficulty>(d.DisplayName, d));
        }

        public override void Draw()
        {
            base.Draw();

            _displayManager.DisplayMessage("What should I call you?");

            var playerName = _displayManager.GetInputFromPlayer();

            _player.AssignName(playerName?.Trim() ?? "Unknown");

            _displayManager.DisplayEmptyLine();

            var selectedOption = _displayManager.GetMenuOptionFromPlayer($"How challenging would you like your adventure, {_player.Name}?", _difficultyMenuOptions);

            _displayManager.DisplayEmptyLine();
            _displayManager.DisplayInfo($"You chose the {selectedOption.Label} difficulty. You'll start with {selectedOption.Data.StartingGold} GP");

            _player.SetDifficulty(selectedOption.Data);

            _displayManager.WaitForAnyInputFromPlayer();

            _sceneManager.ChangeScene<MainMenuScene>();
        }
    }
}
