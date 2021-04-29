using System;

namespace Test.Player
{
    class Player : Entity
    {
        private int xyz;
        private bool flag { get; set; };
        private long timer { get; set; };
        private long lastime { get; set; };
        private int column { get; set; };
        //private Inventory inventory;
        private int experience { get; set; };
        private int maxExperience { get; set; };
        private int maxSpell { get; set; };
        private int spellRemain { get; set; };
        private bool magicAttacking { get; set; };


        public Player(int x, int y, Id id, CombatSystem combat, int level, int hp, int attack, int magicAttack, int defence, AbsFloor floor)
        {
            /*super(x, y, id, combat, level, floor);
            this.setHp(hp);
            this.setMaxHp(hp);
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