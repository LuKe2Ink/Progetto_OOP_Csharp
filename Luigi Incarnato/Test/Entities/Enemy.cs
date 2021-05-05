using System;
using System.Drawing;

namespace Test.Entities
{
    /// <summary>
    /// The class with all stats of the player
    /// </summary>
    class Enemy : Entity
    {
        private int expGuaranteed;
        private Player player;

        /// <summary>
        /// The costructor class
        /// </summary>
        /// <param name="x"> The coordinate x</param>
        /// <param name="y"> The coordinate y</param>
        /// <param name="combat"> Manage all the attack and parameter during combat</param>
        /// <param name="l"> The current level of floor or the current level of player</param>
        /// <param name="maxHp"> The actuall max-hp</param>
        /// <param name="attack"> The actuall attack value</param>
        /// <param name="defence"> The actuall defence value</param>
        /// <param name="magic">The actuall magic attack value</param>
        public Enemy(int x, int y, CombatSystem combat, int l, int maxHp, int attack, int defence, Player p)
            : base(x, y, combat, l)
        {
            box = new AaBb(new Point(x, y), 1, 2);
            player = p;
            SetMaxHp(maxHp);
            SetHp(maxHp);
            SetAttack(attack);
            SetDefence(defence);
            expGuaranteed = 30 + (GetLevel() * 10);
        }

        /// <summary>
        /// Manage the guaranteed experience
        /// </summary>
        /// <returns> the actuale guaranteed experience</returns>
        public int GetExpGuaranteed()
        {
            return expGuaranteed;
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
    }
}
