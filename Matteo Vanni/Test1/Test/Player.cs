using System;
using Test;
using System.Drawing;
//using System.Windows.Input;
using System.Windows;
using System.Windows.Forms;
using System.Collections.Generic;
namespace Test
{
    class Player : Entity
    {
        public bool Flag { get; set; }
        public long Timer { get; set; }
        public long Lastime { get; set; }
        public int Column { get; set; }
        public int Experience { get; set; }
        public int MaxExperience { get; set; }
        public int MaxSpell { get; set; }
        public int SpellRemain { get; set; }
        public bool MagicAttacking { get; set; }


        public Player(int x, int y, int level, int hp, int attack, int magicAttack, int defence, ID id) : base(x, y, level, id)
        {
            Attack = attack;
            MagicAttack = magicAttack;
            Defence = defence;
            Column = 0;
            Timer = 0;
            Attacking = false;
            Box = new AaBb(new Point(CordX, CordY), 1, 2); //Point(this.cordX, this.cordY), 1, 2);
            MaxSpell = 1;
            SpellRemain = MaxSpell;
        }


        private void LevelUp()
        {
            Level++;

            int expOverflow = Experience - MaxExperience;
            if (expOverflow > 0)
            {
                Experience = expOverflow;
            }
            else
            {
                Experience = 0;
            }
            setMaxExp();
            AugmStat();

        }

        public void addExp(int additionalExp)
        {
            Experience += additionalExp;
            if (Experience >= MaxExperience)
            {
                LevelUp();
            }
        }

        private void setMaxExp()
        {
            int newMaxExp = MaxExperience / 2;
            MaxExperience += newMaxExp;
        }

        public override void AugmStat()
        {
            Random rng = new Random();
            int minRange = 3;
            int maxRange = 6;
            int range = maxRange - minRange + 1;

            Attack += rng.Next(minRange, maxRange);

            Defence += rng.Next(minRange, maxRange);

            MagicAttack += rng.Next(minRange, maxRange);

            MaxHp += rng.Next(minRange, maxRange);

            Hp = MaxHp;

            if (Level % 5 == 0)
            {
                MaxSpell++;
            }
        }

        public override void Tick()
        {
            // TODO Auto-generated method stub
            System.DateTime moment = new System.DateTime();
            Timer += moment.Millisecond - Lastime;
            
            if (Timer >= 1500)
            {
                switch (direction)
                {
                    case Direction.LEFT:
                        //setImg(imgMatrix[1][this.column]);
                        break;

                    case Direction.DOWN:
                        //setImg(imgMatrix[0][this.column]);
                        break;

                    case Direction.RIGHT:
                        //setImg(imgMatrix[2][this.column]);
                        break;

                    case Direction.UP:
                        //setImg(imgMatrix[3][this.column]);
                        break;

                    default:
                        break;
                }
                if (this.Column == 2)
                {
                    this.Column = 0;
                }
                else
                {
                    this.Column++;
                }

                Lastime = System.DateTime.Now.Millisecond;
                Timer = 0;
            }
        }

        public override void Move()
        {
            Point pred = new Point(CordX + VelX, CordY + VelY);

            if (new AaBb(pred, 1, 1).Collides(new AaBb(new Point(Box.Pos.X + VelX, Box.Pos.Y + VelY), 1, 1)))
            {
                VelX = 0;
                VelY = 0;
            }
            else
            {
                if (Hp < MaxHp)
                {
                    Hp = Hp + Level;
                }
                int opvelx;
                int opvely;
                Rectangle screen = Screen.PrimaryScreen.Bounds;

                if (X - screen.Width / (32 * 2) > 0 && X + screen.Width / (32 * 2) < screen.Width / 32)
                {
                    opvelx = VelX;
                }
                else
                {
                    opvelx = 0;
                }

                if (Y -+ screen.Height / (32 * 2) > 0 && Y + screen.Height / (32 * 2) < screen.Height / 32)
                {
                    opvely = VelY;
                }
                else
                {
                    opvely = 0;
                }

                CordX += VelX;
                CordY += VelY;
                Box.Pos=new Point(CordX, CordY);

                /*
                 * Section with special tile from mapandtiles package
                 */
            }
        }

        public override void Render()
        {
            throw new NotImplementedException();
            /*Graphical class not to be tested*/
        }

        public override void Input(KeyEventArgs e, List<AaBb> collisions)
        {
            Flag = false;
            AaBb box1;
            collisions.Remove(Box);

            switch (e.KeyCode)
            {
                case Keys.W://su
                    //this.changeDirection(Direction.UP);
                    box1 = new AaBb(new Point(Box.Pos.X, Box.Pos.Y - 1), 1, 2);
                    collisions.ForEach(x => {
                        if (box1.Collides(x))
                        {
                            Flag = true;
                        }
                    });
                    if (!Flag)
                    {
                        VelY = -1;
                        Move();
                    }
                    break;
                case Keys.A://sinistra
                    //this.changeDirection(Direction.UP);
                    box1 = new AaBb(new Point(Box.Pos.X, Box.Pos.Y - 1), 1, 2);
                    collisions.ForEach(x => {
                        if (box1.Collides(x))
                        {
                            Flag = true;
                        }
                    });
                    if (!Flag)
                    {
                        VelX = -1;
                        Move();
                    }
                    break;
                case Keys.S://giu
                    //this.changeDirection(Direction.UP);
                    box1 = new AaBb(new Point(Box.Pos.X, Box.Pos.Y - 1), 1, 2);
                    collisions.ForEach(x => {
                        if (box1.Collides(x))
                        {
                            Flag = true;
                        }
                    });
                    if (!Flag)
                    {
                        VelY = 1;
                        Move();
                    }
                    break;
                case Keys.D://destra
                    //this.changeDirection(Direction.UP);
                    box1 = new AaBb(new Point(Box.Pos.X, Box.Pos.Y - 1), 1, 2);
                    collisions.ForEach(x => {
                        if (box1.Collides(x))
                        {
                            Flag = true;
                        }
                    });
                    if (!Flag)
                    {
                        VelX = 1;
                        Move();
                    }
                    break;
                
                case Keys.J:
                    Attacking = true;
                    //Combat.playerAttack();

                    break;

                case Keys.K:
                    if (SpellRemain != 0)
                    {
                        MagicAttacking = true;
                        //Combat.playerMagicAttack();
                    }
                    break;

                default:
                    break;
            }
            collisions.Add(Box);
        }
    }
}