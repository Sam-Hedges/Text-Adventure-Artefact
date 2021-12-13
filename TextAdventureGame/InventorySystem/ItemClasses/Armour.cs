using System.Runtime.Serialization;

namespace Artefact.InventorySystem.ItemClasses
{
    [DataContract]
    public class Armour : Item
    {
        #region Constructors

        public Armour() {}
        
        public Armour(int ID, string name, ItemType itemType, int quantity, float value, int maxStackQuantity, string description, float protection, float durability)
            : base(ID, name, itemType, quantity, value, maxStackQuantity, description)
        {
            SetMaxStackQuantity(1);
            Protection = protection;
            Durability = durability;
        }
        public Armour(Armour item) 
            : base(item)
        {
            SetMaxStackQuantity(1);
            Protection = item.Protection;
            Durability = item.Durability;
        }

        #endregion

        #region Properties

        [DataMember]
        public float Protection { get; private set; }
        
        [DataMember]
        public float Durability { get; private set; }

        #endregion
    }
}
