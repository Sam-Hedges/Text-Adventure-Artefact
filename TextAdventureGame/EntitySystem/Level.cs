using System.Runtime.Serialization;

namespace Artefact.EntitySystem
{
    [DataContract]
    public class Level
    {
        #region Constructors

        public Level() {}
        
        public Level(int level = 1, float exp = 0f)
        {
            CurrentLevel = level;
            EXP = exp;
            EXPTarget = CurrentLevel * 25f; // EXP target increments by 25 for each level of entity
        }

        #endregion

        #region Properties

        [DataMember]
        public int CurrentLevel { get; private set; }
        
        [DataMember]
        public float EXP { get; private set; }
        
        [DataMember]
        public float EXPTarget { get; private set; }

        #endregion

        #region Methods

        void AddEXP(float exp)
        {
            EXP += exp;

            while (EXP >= EXPTarget)
            {
                CurrentLevel += 1;
                
                EXP -= EXPTarget;
                
                EXPTarget = CurrentLevel * 25f;

                EXP = EXP < 0 ? 0 : EXP; // Backup to insure EXP is never below zero
            }
        }

        #endregion
    }
}
