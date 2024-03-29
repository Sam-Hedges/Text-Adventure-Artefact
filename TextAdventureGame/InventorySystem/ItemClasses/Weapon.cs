﻿using System.Runtime.Serialization;

namespace Artefact.InventorySystem.ItemClasses
{
    [DataContract]
    public class Weapon : Item
    {
        public Weapon() {}
        
        public Weapon(int ID, string name, ItemType itemType, int quantity, float value, int maxStackQuantity, string description, float damage, float durability)
            : base(ID, name, itemType, quantity, value, maxStackQuantity, description)
        {
            Damage = damage;
            Durability = durability;
        }

        public Weapon(Weapon item)
            : base(item)
        {
            Damage = item.Damage;
            Durability = item.Durability;
        }
        
        [DataMember]
        public float Damage { get; private set; }
        
        [DataMember]
        public float Durability { get; private set; }
        
    }
}
