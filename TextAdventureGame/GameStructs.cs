
namespace TextAdventureGame
{
    public struct Player
    {

    }

    public abstract class ObtainableItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int MaximumStackableQuantity { get; set; }

        protected ObtainableItem()
        {
            MaximumStackableQuantity = 1;
        }
    }

    public class Weapon : ObtainableItem
    {
        public Weapon()
        {
           
        }
        
        public float Damage;
        public float Durability;
    }

    public class Armour : ObtainableItem
    {
        public Armour()
        {

        }
    }

    public class  Key : ObtainableItem
    {
        public Key()
        {

        }
    }

    public class Powerup : ObtainableItem
    {
        public Powerup()
        {
            MaximumStackableQuantity = 10;
        }
    }

    public class Crafting : ObtainableItem
    {
        public Crafting()
        {
            MaximumStackableQuantity = 20;
        }
    }
}
