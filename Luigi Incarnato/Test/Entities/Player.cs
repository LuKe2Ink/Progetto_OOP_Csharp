using System;
using System.Drawing;

namespace Test.Entities
{
    /// <summary>
    /// The class with all stats of the player
    /// </summary>
    class Player : Entity
    {
        private int maxSpell;
        private int remainSpell;
        private int experience;
        private int maxExperience = 50;

        /// <summary>
        /// The costructor of the class
        /// </summary>
        /// <param name="x"> The coordinate x</param>
        /// <param name="y"> The coordinate y</param>
        /// <param name="combat"> Manage all the attack and parameter during combat</param>
        /// <param name="l"> The current level of floor or the current level of player</param>
        /// <param name="maxHp"> The actuall max-hp</param>
        /// <param name="attack"> The actuall attack value</param>
        /// <param name="defence"> The actuall defence value</param>
        /// <param name="magic">The actuall magic attack value</param>
        public Player(int x, int y, CombatSystem combat, int l, int maxHp, int attack, int defence, int magic)
            : base(x, y, combat, l)
        {
            box = new AaBb(new Point(x, y), 1, 2);
            maxSpell = 1;
            remainSpell = 1;
            SetMagicAttack(magic);
            SetMaxHp(maxHp);
            SetHp(maxHp);
            SetAttack(attack);
            SetDefence(defence);
        }

        /// <summary>
        /// Manage the coordinate x
        /// </summary>
        /// <returns> the current coordinate x</returns>
        public int GetX()
        {
            return coordx;
        }

        /// <summary>
        /// Manage the coordinate y
        /// </summary>
        /// <returns> the current coordinate y</returns>
        public int GetY()
        {
            return coordy;
        }

        /// <summary>
        /// Manage the decrease of the spell when used
        /// </summary>
        public void SetSpell()
        {
            remainSpell--;
        }

        /// <summary>
        /// Manage the spell
        /// </summary>
        /// <returns> the remaining spell</returns>
        public int GetSpell()
        {
            return remainSpell;
        }

        /// <summary>
        /// Manage the levelling up of the player
        /// </summary>
        private void LevelUp()
        {
            SetLevel(GetLevel()+1);

            int expOverflow = GetActualExp() - this.GetMaxExp();
            if (expOverflow > 0)
                SetExperience(expOverflow);

            else
                SetExperience(0);

            SetMaxExp();
            // this.setMaxExp();

            /* stats augm. */
            AugmStat();

        }

        /// <summary>
        /// Manage the achieved exp
        /// </summary>
        /// <param name="additionalExp"> the amount of get exp</param>
        public void AddExp(int additionalExp)
        {
            this.experience += additionalExp;
            if (experience >= this.maxExperience)
                LevelUp();
        }

        /// <summary>
        /// Update the new current max-exp
        /// </summary>
        private void SetMaxExp()
        {
            int newMaxExp = maxExperience / 2;
            maxExperience = this.maxExperience + newMaxExp;
        }

        /// <summary>
        /// Manage the exp
        /// </summary>
        /// <returns> the current exp</returns>
        private int GetActualExp()
        {
            return experience;
        }

        /// <summary>
        /// Manage the max-exp
        /// </summary>
        /// <returns> the current max exp</returns>
        private int GetMaxExp()
        {
            return maxExperience;
        }

        /// <summary>
        /// Manage the experience
        /// </summary>
        /// <param name="exp"> the amount of experience</param>
        private void SetExperience(int exp)
        {
            experience = exp;
        }
    }
}
