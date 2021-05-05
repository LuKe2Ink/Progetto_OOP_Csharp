using System;
using System.Drawing;

namespace Test.Entities
{
    /// <summary>
    /// Manage all the attack and the decrese of some stats
    /// </summary>
    class CombatSystem
    {
        private Enemy enemy;
        private Player player;

        /// <summary>
        /// The class costructor
        /// </summary>
        public CombatSystem() { }

        /// <summary>
        /// Add the player stats to the class
        /// </summary>
        /// <param name="p"> the player</param>
        public void AddPlayer(ref Player p)
        {
            player = p;
        }

        /// <summary>
        /// Add the enemy stats to the class
        /// </summary>
        /// <param name="e"> the enemy</param>
        public void AddEnemy(ref Enemy e)
        {
            enemy = e;
        }

        /// <summary>
        /// Manage the action of player attacking
        /// </summary>
        public void PlayerAttack()
        {
            AaBb attack_box = null;
            int x = (int)player.GetX();
            int y = (int)player.GetY();
            switch (player.GetDirection())
            {
                case Entity.Direction.UP:
                    attack_box = new AaBb(new Point(x, y - 1), 1, 2);
                    break;
                case Entity.Direction.DOWN:
                    attack_box = new AaBb(new Point(x, y + 1), 1, 2);
                    break;
                case Entity.Direction.RIGHT:
                    attack_box = new AaBb(new Point(x + 1, y), 1, 2);
                    break;
                case Entity.Direction.LEFT:
                    attack_box = new AaBb(new Point(x - 1, y), 1, 2);
                    break;
            }

            if (attack_box.Collides(enemy.GetBox()))
            {
                enemy.SetHp(enemy.GetHp() - (player.GetAttack() - enemy.GetDefence()));
                if (enemy.IsDead())
                    player.AddExp(enemy.GetExpGuaranteed());
            }
        }

        /// <summary>
        /// Manage the action of enemy attacking
        /// </summary>
        public void EnemyAttack()
        {
            AaBb attack_box = null;
            switch (enemy.GetDirection())
            {
                case Entity.Direction.UP:
                    attack_box = new AaBb(new Point(enemy.GetX(), enemy.GetY() - 1), 1, 2);
                    break;
                case Entity.Direction.DOWN:
                    attack_box = new AaBb(new Point(enemy.GetX(), enemy.GetY() + 1), 1, 2);
                    break;
                case Entity.Direction.RIGHT:
                    attack_box = new AaBb(new Point(enemy.GetX() + 1, enemy.GetY()), 1, 2);
                    break;
                case Entity.Direction.LEFT:
                    attack_box = new AaBb(new Point(enemy.GetX() - 1, enemy.GetY()), 1, 2);
                    break;
            }
            if (attack_box.Collides(player.GetBox()))
                player.SetHp(player.GetHp() - (enemy.GetAttack() - player.GetDefence()));
        }

        /// <summary>
        /// Manage the action of player using a magic
        /// </summary>
        public void PlayerMagicAttack()
        {
            if (player.GetSpell() > 0)
            {
                bool flag = false;
                AaBb[] magicBoxes = {
                    new AaBb(new Point(player.GetX() - 1, player.GetY() - 1), 1, 1),
                    new AaBb(new Point(player.GetX(), player.GetY() - 1), 1, 1),
                    new AaBb(new Point(player.GetX() + 1, player.GetY() - 1), 1, 1),
                    new AaBb(new Point(player.GetX() - 1, player.GetY()), 1, 1),
                    new AaBb(new Point(player.GetX() + 1, player.GetY()), 1, 1),
                    new AaBb(new Point(player.GetX() + 1, player.GetY() + 1), 1, 1),
                    new AaBb(new Point(player.GetX() - 1, player.GetY() + 1), 1, 1),
                    new AaBb(new Point(player.GetX() - 1, player.GetY() + 2), 1, 1),
                    new AaBb(new Point(player.GetX(), player.GetY() + 2), 1, 1),
                    new AaBb(new Point(player.GetX() + 1, player.GetY() + 2), 1, 1)};

                foreach (AaBb x in magicBoxes)
                {
                    if (x.Collides(enemy.GetBox()))
                        flag = true;
                }

                if (flag)
                {
                    enemy.SetHp(enemy.GetHp() - player.GetMagicAttack());
                    if (enemy.IsDead())
                        player.AddExp(enemy.GetExpGuaranteed());
                }

                player.SetSpell();
            }
        }
    }
}
