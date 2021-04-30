using System;

namespace Test.Entities
{
    abstract class Entity
    {
        protected int x { get; set; };
        protected int y { get; set; };
        protected AaBb box { get; set; };
        private int level { get; set; };
        private int hp { get; set; };
        private int maxHp { get; set; };
        private int attack { get; set; };
        private int magicAttack { get; set; };
        private int defence { get; set; };

        private bool movement { get; set; }; // false the entity steady, true is moving
        private bool attacking { get; set; };

        private CombatSystem combat { get; set; };

        /**
         * Entity constructor.
         *
         * @param x      Horizontal starting position
         * 
         * @param y      Vertical starting position
         * 
         * @param id     Id for the entity taken from ID enum class
         * 
         * @param combat Combat system for the entity
         * 
         * @param level  Entity level for stats augmentation
         * 
         * @param floor  Used to take level and position
         * 
         * 
         */
        public Entity(int x, int y, CombatSystem combat, int level)
        {
            this.x = x;
            this.y = y;
            this.SetLevel(level);
            this.combat = combat;
        }

        /**
         * dead entity.
         *
         * @return boolean true if is dead, false if not
         */
        public bool IsDead()
        {
            if (this.hp <= 0)
            {
                this.SetAttacking(false);
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
