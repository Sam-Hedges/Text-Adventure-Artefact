namespace Artefact.EntitySystem
{
    public class Level
    {
        public Level() {}
        
        public Level(int level = 1, float exp = 0f)
        {
            CurrentLevel = level;
            EXP = exp;
            EXPTarget = CurrentLevel * 25f; // EXP target increments by 25 for each level of entity
        }

        public int CurrentLevel { get; private set; }
        public float EXP { get; private set; }
        public float EXPTarget { get; private set; }

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
        
    }
}
