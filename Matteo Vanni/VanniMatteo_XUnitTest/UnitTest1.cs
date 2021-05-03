using System;
using Xunit;
using Test;
using System.Windows.Forms;
using System.Collections;

namespace VanniMatteo_XUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void VanniMatteo_XUnitTest()
        {
            Player player = new Player(0, 0, 1, 100, 10, 10, 10, ID.Player);
            KeyEventArgs key = new KeyEventArgs(Keys.W);//new KeyInput(game, KeyEvent.KEY_PRESSED, System.currentTimeMillis(), 0, KeyEvent.VK_1, '0');
            List<AaBB> collisions = new List<AaBb>();
            KeyInput inputKey = new KeyInput(new List<GameObject>());

            Assert.AreEqual(player.MaxHp, player.Hp);
            Assert.False(player.IsDead());
            player.addExp(60);// level up beacuse the player need 50 exp
            Assert.Equal(2, player.Level);
            
            player.addExp(50);
            Assert.NotEqual(3, player.Level);

            /* the player level up and the stats increase */
            Assert.True(player.Hp > 100);
            Assert.True(player.Attack > 10);
            Assert.True(player.MagicAttack > 10);
            Assert.True(player.Defence > 10);
            /*try to simulate the keys pressed on the keyboard*/
            /* movement*/

            player.Input(key, collisions);
            Assert.Equal(Direction.UP, player.direction);

            key = new KeyEventArgs(Keys.A);
            player.Input(key, collisions);
            Assert.Equal(Direction.LEFT, player.direction);

            key = new KeyEventArgs(Keys.S);
            player.Input(key, collisions);
            Assert.Equal(Direction.DOWN, player.direction);

            key = new KeyEventArgs(Keys.D);
            player.Input(key, collisions);
            Assert.Equal(Direction.RIGHT, player.direction);

            /* attacking test */
            key = new KeyEventArgs(Keys.J);
            player.Input(key, collisions);
            Assert.True(player.Attacking);

            key = new KeyEventArgs(Keys.K);
            player.Input(key, collisions);
            Assert.True(player.MagicAttacking);

            Assert.Equals(0, player.SpellRemain);
            player.Hp = 0;
            Assert.True(player.IsDead());
        }
        
    }
}