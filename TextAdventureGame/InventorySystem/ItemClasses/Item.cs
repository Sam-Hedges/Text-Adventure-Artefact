using System.Runtime.Serialization;

namespace Artefact.InventorySystem.ItemClasses
{ 
    public enum ItemType
    {
        Weapon,
        Armour,
        Key,
        Powerup
    }

    [DataContract]
    public class Item
    {
        #region Properties
        [DataMember]
        public int ID { get; private set; }
        
        [DataMember]
        public string Name { get; private set; }
        
        [DataMember]
        public ItemType ItemType { get; private set; }
        
        [DataMember]
        public int MaxStackQuantity { get; private set; }
        
        [DataMember]
        public int Quantity { get; private set; }
        
        [DataMember]
        public float Value { get; private set; }
        
        [DataMember]
        public string Description { get; private set; }

        #endregion

        #region Constructors
        public Item() {}
        
        public Item(int ID, string name, ItemType itemType, int quantity, float value, int maxStackQuantity, string description)
        {
            this.ID = ID;
            Name = name;
            ItemType = itemType;
            Value = value;
            Quantity = quantity;
            MaxStackQuantity = maxStackQuantity;
            Description = description;
        }

        public Item(Item item)
        {
            ID = item.ID;
            Name = item.Name;
            ItemType = item.ItemType;
            Value = item.Value;
            Quantity = item.Quantity;
            MaxStackQuantity = item.MaxStackQuantity;
            Description = item.Description;
        }

        #endregion

        #region Methods
        public void SetMaxStackQuantity(int value)
        {
            MaxStackQuantity = value;
        }

        public void SetQuantity(int value)
        {
            Quantity = value;
        }

        public void AddToQuantity(int value)
        {
            Quantity += value;

        }

        #endregion
    }
}