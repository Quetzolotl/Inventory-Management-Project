using Inventory_Management_Project.Core;
using Inventory_Management_Project.Core.Extensions;
using Inventory_Management_Project.Core.Items;
using Inventory_Management_Project.Core.Managers;
using Inventory_Management_Project.Core.Menus;
using Inventory_Management_Project.Core.Shops;

namespace Inventory_Management_Project.Scenes.Shop
{
    public sealed class ShopSellToPlayerScene : Scene
    {
        private readonly WeaponShop _shop;

        private readonly SceneMenuOption _backSceneMenuOption;

        public ShopSellToPlayerScene(WeaponShop shop, Player player, SceneManager sceneManager, DisplayManager displayManager) : base(player, sceneManager, displayManager)
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

                if (!_shop.Weapons.Any())
                {
                    _displayManager.DisplayWarning("Uh oh, it looks like I'm fresh out of stock. Come back later and I should be resupplied");

                    _displayManager.WaitForAnyInputFromPlayer();

                    _sceneManager.ChangeScene(_backSceneMenuOption.SceneType);
                    return;
                }

                var weaponMenuOptions = _shop.Weapons.ToGenericDataMenuOptions(w => $"{w.Name} ({w.Price}gp)");
                var allMenuOptions = new List<IMenuOption>(weaponMenuOptions.Cast<IMenuOption>())
                {
                    _backSceneMenuOption
                };

                var selectedOption = _displayManager.GetMenuOptionFromPlayer($"You have {_player.Gold}gp. What weapon would you like to look at?", allMenuOptions);

                if (selectedOption is SceneMenuOption selectedSceneOption)
                {
                    _sceneManager.ChangeScene(selectedSceneOption.SceneType);
                    return;
                }
                else if (selectedOption is GenericDataMenuOption<Weapon> selectedWeaponOption)
                {
                    var selectedWeapon = selectedWeaponOption.Data;

                    _displayManager.Clear();

                    _displayManager.DisplayMessage($"Ah, the {selectedWeapon.Name}! Here is what my suppliers say about it:");

                    _displayManager.DisplayInfo(selectedWeapon.Description ?? "Huh, I don't seem to really know anything about it");

                    _displayManager.DisplayEmptyLine();
                    
                    var shouldBuyWeapon = _displayManager.GetYesNoFromPlayer($"Would you like to buy it for {selectedWeapon.Price}gp (you have {_player.Gold}gp)?");

                    _displayManager.DisplayEmptyLine();

                    if (shouldBuyWeapon)
                    {
                        if (_player.Gold >= selectedWeapon.Price)
                        {
                            _player.RemoveGold(selectedWeapon.Price);
                            _shop.RemoveWeapon(selectedWeapon);
                            _player.AddItem(selectedWeapon);

                            _displayManager.DisplayInfo($"A {selectedWeapon.Name} was added to your inventory and {selectedWeapon.Price} has been removed from your gold. You have {_player.Gold}gp left");
                        }
                        else
                        {
                            _displayManager.DisplayWarning("I'm sorry, friend, but it doesn't look like you have enough to cover that. Perhaps another weapon will meet your needs");
                        }

                        _displayManager.WaitForAnyInputFromPlayer();
                    }
                }
            } while (true);
        }
    }
}