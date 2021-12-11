namespace Artefact.EntitySystem
{
    public class Health
    {
        public Health() {}
        public Health(float currentHealth, float maxHealth)
        {
            CurrentHealth = currentHealth;
            MaxHealth = maxHealth;
        }
        
        public float CurrentHealth { get; private set; }
        public float MaxHealth { get; private set; }

        public void ChangeHealth(float newHealth) 
        {
        
        }
    }
}
