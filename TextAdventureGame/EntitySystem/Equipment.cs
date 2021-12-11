using Artefact.InventorySystem;
using Artefact.InventorySystem.ItemClasses;

namespace Artefact.EntitySystem
{
    public class Equipment
    {
        public Equipment() {}
        public Equipment(Inventory entityInventory, Armour armour, Weapon weapon)
        {
            this.entityInventory = entityInventory;
            Armour = armour;
            Weapon = weapon;
        }

        private Inventory entityInventory;
        public Armour Armour { get; private set; }
        public Weapon Weapon{ get; private set; }

        public void ChangeWeapon(Weapon weapon)
        {
            entityInventory.AddItem(Weapon, 1);

            Weapon = weapon;
            
            entityInventory.RemoveItem(weapon, 1);
        }
        
        public void ChangeArmour(Armour armour)
        {
            entityInventory.AddItem(Weapon, 1);

            Armour = armour;
            
            entityInventory.RemoveItem(armour, 1);
        }
    }
}
