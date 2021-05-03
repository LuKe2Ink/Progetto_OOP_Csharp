using System;
using System.Drawing;
namespace Test
{
    abstract class Entity : GameObject
    {
        /*protected SpriteSheet sprite="Resource/";
        protected BufferedImage[][] imgMatrix;
        private BufferedImage img;
        protected BufferedImage hpBar;//*/

        public Image img; //= Image.FromFile("");
        public Image[,] imgMatrix;
        public Image HpBar;

        //public SpriteSheet sprite = "Resources/";


        protected int X { get; set; }
        protected int Y { get; set; }
        protected AaBb Box { get; set; }
        public int Level { get; set; }
        public int Hp { get; set; }
        public int MaxHp { get; set; }
        public int Attack { get; set; }
        public int MagicAttack { get; set; }
        public int Defence { get; set; }
        public bool Movement { get; set; } // false the entity steady, true is moving
        public bool Attacking { get; set; }
        public Direction direction { get; set; }
        public Entity(int x, int y, int level, ID id) : base(x, y, id)
        {
            X = x;
            Y = y;
            Level = level;
            //Combat = combat;
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
                Attacking = false;
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
