using System.Runtime.Serialization;
using Artefact.InventorySystem;
using Artefact.InventorySystem.ItemClasses;

namespace Artefact.EntitySystem
{
    [DataContract]
    public class Entity
    {
        #region Constructors

        public Entity() { } // Empty constructor for XML DataContract Serialization 
        
        public Entity(Entity entity) // For Loading known entities; e.g saved player, preset enemies
        {
            Name = entity.Name;
            LVL = entity.LVL;
            INV = entity.INV;
            HP = entity.HP;
            EQ = entity.EQ;
            Progress = entity.Progress;
        }

        public Entity(string name, float maxHealth, Weapon startingWeapon, Armour startingArmour) // For new entity initialisation
        {
            Name = name;
            LVL = new Level();
            INV = new Inventory();
            HP = new Health(maxHealth, maxHealth);
            EQ = new Equipment(INV, startingArmour, startingWeapon);
            Progress = 0;
        }
        

        #endregion
        
        #region Properties

        [DataMember] public string Name { get; private set; }
        [DataMember] public Level LVL { get; private set; }
        [DataMember] public Inventory INV { get; private set; }
        [DataMember] public Health HP { get; private set; }
        [DataMember] public Equipment EQ { get; private set; }

        [DataMember] public int Progress { get; private set; }

        #endregion

        public void SetProgress(int i)
        {
            Progress = i;
        }
    }
}
