using System;
using System.Drawing;

namespace Test.Entities
{


    /// <summary>
    /// The abstract class that init alla the entity
    /// </summary>
    abstract class Entity
    {
        /// <summary>
        /// The enum for the direction of the entity
        /// </summary>
        public enum Direction
        {
            UP,
            DOWN,
            RIGHT,
            LEFT
        }
        
        public int coordx;
        public int coordy;
        protected AaBb box;
        protected int level;
        private int hp;
        private int maxHp;
        private int attack;
        private int magicAttack;
        private int defence;
        private Direction direction;

        private readonly CombatSystem combatSys;

        /// <summary>
        /// The costructor of this class
        /// </summary>
        /// <param name="x"> The coordinate x</param>
        /// <param name="y"> The coordinate y</param>
        /// <param name="combat"> Manage all the attack and parameter during combat</param>
        /// <param name="l"> The current level of floor or the current level of player</param>
        public Entity(int x, int y, CombatSystem combat, int l)
        {
            direction = Direction.RIGHT;
            coordx = x;
            coordy = y;
            level = l;
            combatSys = combat;
        }

        /// <summary>
        /// Control the entity death
        /// </summary>
        /// <returns>true if hp below 0, false if hp above 0</returns>
        public bool IsDead()
        {

            if (hp <= 0)
                return true;

            else
                return false;


        }

        /// <summary>
        /// Manage the hp
        /// </summary>
        /// <returns> the current amount of hp</returns>
        public int GetHp()
        {
            return hp;
        }

        /// <summary>
        /// Manage the attack parameter
        /// </summary>
        /// <returns> the current value of attack</returns>
        public int GetAttack()
        {
            return attack;
        }

        /// <summary>
        /// Manage the magic attack parameter
        /// </summary>
        /// <returns> the current value of magic attack</returns>
        public int GetMagicAttack()
        {
            return magicAttack;
        }

        /// <summary>
        /// Manage the defence parameter
        /// </summary>
        /// <returns> the current value of defence</returns>
        public int GetDefence()
        {
            return defence;
        }

        /// <summary>
        /// Manage the box
        /// </summary>
        /// <returns> the current box of the entity</returns>
        public AaBb GetBox()
        {
            return box;
        }

        /// <summary>
        /// Manage the max-hp
        /// </summary>
        /// <returns> the current value of the max-hp </returns>
        public int GetMaxHp()
        {
            return maxHp;
        }

        /// <summary>
        /// Manage the level
        /// </summary>
        /// <returns> the current level of the entity</returns>
        public int GetLevel()
        {
            return level;
        }

        /// <summary>
        /// Manage the combat variable
        /// </summary>
        /// <returns> </returns>
        public CombatSystem GetCombat()
        {
            return combatSys;
        }

        /// <summary>
        /// Manage the direction of entity
        /// </summary>
        /// <returns> where the enity is looking up</returns>
        public Direction GetDirection()
        {
            return direction;
        }

        /// <summary>
        /// Manage the hp
        /// </summary>
        /// <param name="hp"> set the new current hp</param>
        public void SetHp(int hp)
        {
            this.hp = hp;
        }

        /// <summary>
        /// Manage the attack value
        /// </summary>
        /// <param name="attack">  set the new current attack value</param>
        public void SetAttack(int attack)
        {
            this.attack = attack;
        }

        /// <summary>
        /// Manage the magick attack value
        /// </summary>
        /// <param name="magicAttack"> set the new current magic attack value</param>
        public void SetMagicAttack(int magicAttack)
        {
            this.magicAttack = magicAttack;
        }

        /// <summary>
        /// Manage the defence
        /// </summary>
        /// <param name="defence"> set the new current defence</param>
        public void SetDefence(int defence)
        {
            this.defence = defence;
        }

        /// <summary>
        /// Manage the new Max-hp
        /// </summary>
        /// <param name="maxHp"> set the new current max-hp</param>
        public void SetMaxHp(int maxHp)
        {
            this.maxHp = maxHp;
        }

        /// <summary>
        /// Manage the level
        /// </summary>
        /// <param name="l"> set the new current level</param>
        public void SetLevel(int l)
        {
            level = l;
        }

        /// <summary>
        /// Manage the direction
        /// </summary>
        /// <param name="dir"> set the new current direction</param>
        public void SetDirection(Direction dir)
        {
            direction = dir;
        }

    }
}
