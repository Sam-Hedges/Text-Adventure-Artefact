namespace Artefact.InventorySystem.ItemClasses
{
    public class Weapon : Item
    {

        public float Damage { get; private set; }
        public float Durability { get; private set; }

        public Weapon(int ID, string name, ItemType itemType, int quantity, float value, int maxStackQuantity, string description, float damage, float durability)
            : base(ID, name, itemType, quantity, value, maxStackQuantity, description)
        {
            Damage = damage;
            Durability = durability;
        }

        public Weapon(Weapon weapon)
            : base(weapon)
        {
            Damage = weapon.Damage;;
            Durability = weapon.Durability;
        }


    }
}
