using System;
using System.Runtime.Serialization;

namespace Artefact.EntitySystem
{
    public enum HealthID
    {
        Damage,
        Heal
    }
    
    [DataContract]
    public class Health
    {
        #region Constructors

        public Health() {}
        public Health(float currentHealth, float maxHealth)
        {
            CurrentHealth = currentHealth;
            MaxHealth = maxHealth;
        }

        #endregion

        #region Properties

        [DataMember]
        public float CurrentHealth { get; private set; }
        
        [DataMember]
        public float MaxHealth { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// Alters the health by the changeAmount and returns false if the health goes reaches zero
        /// </summary>
        /// <param name="changeAmount"></param>
        /// <param name="HPID"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public bool ChangeHealth(float changeAmount, HealthID HPID)
        {
            switch (HPID)
            {
                case HealthID.Damage:
                {
                    float tempHp = CurrentHealth - changeAmount;
                    
                    CurrentHealth = tempHp <= 0 ? 0 : tempHp;
                    
                    return CurrentHealth != 0; 
                }
                case HealthID.Heal:
                {
                    float tempHp = CurrentHealth + changeAmount;

                    CurrentHealth = tempHp >= MaxHealth ? MaxHealth : tempHp;

                    return true;
                }
                default:
                    throw new ArgumentOutOfRangeException(nameof(HPID), HPID, "Not valid HealthID");
            }
        }

        #endregion
    }
}
