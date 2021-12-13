using System.Runtime.Serialization;

namespace Artefact.InventorySystem.ItemClasses
{
    [DataContract]
    public class Key : Item
    {
        #region Constructors

        public Key() {}
        public Key(int ID, string name, ItemType itemType, int quantity, float value, int maxStackQuantity, string description)
            : base(ID, name, itemType, quantity, value, maxStackQuantity, description)
        {
            SetMaxStackQuantity(1);
        }
        public Key(Key item) 
            : base(item)
        {
            SetMaxStackQuantity(1);
        }

        #endregion
        
        
    }
}
