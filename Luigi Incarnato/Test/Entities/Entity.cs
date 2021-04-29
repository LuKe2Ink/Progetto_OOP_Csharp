using System;

namespace Test.Entities
{
    abstract class Entity
    {
        protected int x;
        protected int y;
        protected AaBb box;
        private int level;
        private int hp;
        private int maxHp;
        private int attack;
        private int magicAttack;
        private int defence;

        private bool movement; // false the entity steady, true is moving
        private bool attacking;

        private CombatSystem combat;

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

        /*
         * @return level
         */
        public int GetLevel()
        {
            return level;
        }

        /*
         * @return health point
         */
        public int GetHp()
        {
            return hp;
        }

        /*
         * @return attack
         */
        public int GetAttack()
        {
            return attack;
        }

        /*
         * @return magic attack
         */
        public int GetMagicAttack()
        {
            return magicAttack;
        }

        /*
         * @return defense
         */
        public int GetDefence()
        {
            return defence;
        }

        /*
         * @return collision box
         */
        public AaBb GetBox()
        {
            return box;
        }

        /*
         * @return max health point
         */
        public int GetMaxHp()
        {
            return maxHp;
        }

        /*
         * @return boolean when entity is moving or not
         */
        public bool IsMoving()
        {
            return movement;
        }

        /*
         * @return boolean when entity is attacking or not
         */
        public bool IsAttacking()
        {
            return attacking;
        }

        /*
         * Set entity level
         * 
         * @param level
         */
        public void SetLevel(int level)
        {
            this.level = level;
        }

        /*
         * Set entity health point
         * 
         * @param hp
         */
        public void SetHp(int hp)
        {
            this.hp = hp;
        }

        /*
         * Set entity attack damage
         * 
         * @param attack
         */
        public void SetAttack(int attack)
        {
            this.attack = attack;
        }

        /*
         * Set entity magic attack damage
         * 
         * @param magic_attack
         */
        public void SetMagicAttack(int magicAttack)
        {
            this.magicAttack = magicAttack;
        }

        /*
         * Set entity defense
         * 
         * @param defence
         */
        public void SetDefence(int defence)
        {
            this.defence = defence;
        }

        /*
         * Set entity collision box
         * 
         * @param box
         */
        public void SetBox(AaBb box)
        {
            this.box = box;
        }

        /*
         * Set entity maximum health point
         * 
         * @param max_hp
         */
        public void SetMaxHp(int maxHp)
        {
            this.maxHp = maxHp;
        }

        /*
         * Set entity movement
         * 
         * @param movement
         */
        public void SetMovement(bool movement)
        {
            this.movement = movement;
        }

        /*
         * Set attack state on entity
         * 
         * @param attacking
         */
        public void SetAttacking(bool attacking)
        {
            this.attacking = attacking;
        }

        public CombatSystem getCombat()
        {
            return combat;
        }
    }
}
