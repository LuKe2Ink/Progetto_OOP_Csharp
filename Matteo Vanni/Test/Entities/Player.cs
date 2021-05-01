using System;
using Entity;

namespace Test.Entities
{
    
    class Player : Entity
    {
        private bool Flag { get; set; };
        private long Timer { get; set; };
        private long Lastime { get; set; };
        private int Column { get; set; };
        //private Inventory inventory { get; set; };
        private int Experience { get; set; };
        private int MaxExperience { get; set; };
        private int MaxSpell { get; set; };
        private int SpellRemain { get; set; };
        private bool MagicAttacking { get; set; };


        public Player(int x, int y, CombatSystem combat, int level, int hp, int attack, int magicAttack, int defence)/*, AbsFloor floor, Id id, CombatSystem combat)//*/
        {
            Eentity e=new Entity(x, y, combat, level);
            e.Hp=hp;
            e.MaxHp=hp;
            
            this.setAttack(attack);
            this.setMagicAttack(magicAttack);
            this.setDefence(defence);
            this.setAttribute(Attribute.FIRE);
            this.inventory = new Inventory();

            this.column = 0;
            this.timer = 0;

            final ResourceLoader resource = new ResourceLoader();

            this.setAttacking(false);
            hpBar = ImageIO.read(resource.getStreamImage("hpbar"));

            sprite = new SpriteSheet(ImageIO.read(resource.getStreamImage("player")));
            this.setBox(new AaBb(new Point(this.cordX, this.cordY), 1, 2));
            this.imgMatrix = new BufferedImage[4][3];

            spellRemain = maxSpell;

            for (int row = 0; row< 4; row++) {
              for (int column = 0; column< 3; column++) {
                imgMatrix[row][column] = getSprite().grabImage(column + 1, row + 1, 34, 60);
              }
            }//*/
            xyz = 2;
        }
    }

}