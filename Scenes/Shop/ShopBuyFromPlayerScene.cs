using Inventory_Management_Project.Core;
using Inventory_Management_Project.Core.Extensions;
using Inventory_Management_Project.Core.Items;
using Inventory_Management_Project.Core.Managers;
using Inventory_Management_Project.Core.Menus;
using Inventory_Management_Project.Core.Shops;

namespace Inventory_Management_Project.Scenes.Shop
{
    public sealed class ShopBuyFromPlayerScene : Scene
    {
        private readonly WeaponShop _shop;

        private readonly SceneMenuOption _backSceneMenuOption;

        public ShopBuyFromPlayerScene(WeaponShop shop, Player player, SceneManager sceneManager, DisplayManager displayManager) : base(player, sceneManager, displayManager)
        {
            _shop = shop;

            _backSceneMenuOption = new SceneMenuOption("Back", typeof(ShopMainScene));
        }

        public override void Draw()
        {
            base.Draw();

            do
            {
                _displayManager.Clear();

                var allPlayersWeapons = _player.Inventory.OfType<Weapon>();

                if (!allPlayersWeapons.Any())
                {
                    _displayManager.DisplayWarning("Hmm, I don't see anything that I'd want to buy. Come back when you have some weapons to offload");

                    _displayManager.WaitForAnyInputFromPlayer();

                    _sceneManager.ChangeScene(_backSceneMenuOption.SceneType);
                    return;
                }

                var weaponMenuOptions = allPlayersWeapons.ToGenericDataMenuOptions(w => $"{w.Name} ({w.Price}gp)");
                var allMenuOptions = new List<IMenuOption>(weaponMenuOptions.Cast<IMenuOption>())
                {
                    _backSceneMenuOption
                };

                var selectedOption = _displayManager.GetMenuOptionFromPlayer("What weapon would you like to sell?", allMenuOptions);

                if (selectedOption is SceneMenuOption selectedSceneOption)
                {
                    _sceneManager.ChangeScene(selectedSceneOption.SceneType);
                    return;
                }
                else if (selectedOption is GenericDataMenuOption<Weapon> selectedWeaponOption)
                {
                    var selectedWeapon = selectedWeaponOption.Data;

                    _displayManager.Clear();

                    var shouldSellWeapon = _displayManager.GetYesNoFromPlayer($"Are you sure you would like to sell your {selectedWeapon.Name} for {selectedWeapon.Price}gp?");

                    _displayManager.DisplayEmptyLine();

                    if (shouldSellWeapon)
                    {
                        _player.AddGold(selectedWeapon.Price);
                        _player.RemoveItem(selectedWeapon);
                        _shop.AddWeapon(selectedWeapon);

                        _displayManager.DisplayInfo($"A {selectedWeapon.Name} was removed to your inventory and {selectedWeapon.Price} has been added to your gold. You now have {_player.Gold}gp");

                        _displayManager.WaitForAnyInputFromPlayer();
                    }
                }
            } while (true);
        }
    }
}