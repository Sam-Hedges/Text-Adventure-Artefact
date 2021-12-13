using System.Runtime.Serialization;

namespace Artefact.InventorySystem.ItemClasses
{
    [DataContract]
    public class Powerup : Item
    {
        #region Constructors

        public Powerup() {}
        public Powerup(int ID, string name, ItemType itemType, int quantity, float value, int maxStackQuantity, string description)
            : base(ID, name, itemType, quantity, value, maxStackQuantity, description)
        {
            SetMaxStackQuantity(10);
        }
        public Powerup(Powerup item) 
            : base(item)
        {
            SetMaxStackQuantity(10);
        }

        #endregion
        
        
    }
}
