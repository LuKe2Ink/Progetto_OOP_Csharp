using System;
using CombatSystem;
namespace Test.Entities
{
    abstract class Entity
    {
        protected int X { get; set; };
        protected int Y { get; set; };
        protected AaBb Box { get; set; };
        private int Level { get; set; };
        private int Hp { get; set; };
        private int MaxHp { get; set; };
        private int Attack { get; set; };
        private int MagicAttack { get; set; };
        private int Defence { get; set; };
        private bool Movement { get; set; }; // false the entity steady, true is moving
        private bool Attacking { get; set; };

        private CombatSystem Combat { get; set; };

        
        public Entity(int x, int y, CombatSystem combat, int level)
        {
            X = x;
            Y = y;
            Level = level
            Combat = combat;
        }

        /**
         * dead entity.
         *
         * @return boolean true if is dead, false if not
         */
        public bool IsDead()
        {
            if (Hp <= 0)
            {
                SetAttacking(false);
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
         * Change entity stats on level up(for player) or level change(for enemy and
         * boss)
         */
        public abstract void AugmStat();
    }
}
