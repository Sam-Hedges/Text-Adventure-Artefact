using System.Runtime.Serialization;
using Artefact.InventorySystem;
using Artefact.InventorySystem.ItemClasses;

namespace Artefact.EntitySystem
{
    [DataContract]
    public class Equipment
    {
        #region Constructors

        public Equipment() {}
        public Equipment(Inventory entityInventory, Armour armour, Weapon weapon)
        {
            _entityInventory = entityInventory;
            Armour = armour;
            Weapon = weapon;
        }
        
        #endregion

        #region Properties

        [DataMember]
        private Inventory _entityInventory;
        
        [DataMember]
        public Armour Armour { get; private set; }
        
        [DataMember]
        public Weapon Weapon{ get; private set; }

        #endregion

        #region Methods

        public void ChangeWeapon(Weapon weapon)
        {
            _entityInventory.AddItem(new Weapon(weapon), 1);
            
            _entityInventory.RemoveItem(weapon, 1);
        }
        
        public void ChangeArmour(Armour armour)
        {
            _entityInventory.AddItem(new Armour(armour), 1);

            _entityInventory.RemoveItem(armour, 1);
        }

        #endregion
    }
}
