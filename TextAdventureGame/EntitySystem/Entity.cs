using System.Runtime.Serialization;
using Artefact.InventorySystem;
using Artefact.InventorySystem.ItemClasses;

namespace Artefact.EntitySystem
{
    [DataContract]
    public class Entity
    {
        public Entity()
        {
            
        }
        
        public Entity(string name, Level lvl, Inventory inv, Health hp, Equipment eq) // For Loading known entities; e.g saved player, preset enemies
        {
            Name = name;
            LVL = lvl;
            INV = inv;
            HP = hp;
            EQ = eq;
        }

        public Entity(string name, float maxHealth, Weapon startingWeapon, Armour startingArmour) // For new entity initialisation
        {
            Name = name;
            LVL = new Level();
            INV = new Inventory();
            HP = new Health(maxHealth, maxHealth);
            EQ = new Equipment(INV, startingArmour, startingWeapon);
        }
        
        [DataMember]
        public string Name { get; private set; }
        
        [DataMember]
        public Level LVL { get; private set; }
        
        [DataMember]
        public Inventory INV { get; private set; }
        
        [DataMember]
        public Health HP { get; private set; }
        
        [DataMember]
        public Equipment EQ { get; private set; }
        
    }
}
