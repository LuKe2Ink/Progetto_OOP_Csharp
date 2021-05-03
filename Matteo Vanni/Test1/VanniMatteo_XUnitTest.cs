using System;
using Xunit;

namespace Progetto_OOP_CSharp_MIO
{
    public class UnitTest1
    {
        [TestClass]
        public class UnitTest1
        {
            Player player;
            KeyEventArgs key;
            List<AaBb> collisions;
            KeyInput inputKey;
            [TestInitialize]
            public void TestInit()
            {
                player = new Player(0, 0, 1, 100, 10, 10, 10, ID.Player);
                key = new KeyEventArgs(Keys.W);//new KeyInput(game, KeyEvent.KEY_PRESSED, System.currentTimeMillis(), 0, KeyEvent.VK_1, '0');
                collisions = new List<AaBb>();
                inputKey = new KeyInput(new List<GameObject>());
            }

            [TestMethod]
            public void Player_test()
            {
                Assert.AreEqual(player.MaxHp, player.Hp);
                Assert.False(player.IsDead());
                player.addExp(60);// level up beacuse the player need 50 exp
                Assert.AreEqual(2, player.Level);
                player.addExp(20);
                //Assert.AreNotEqual(3, player.Level);

                /* the player level up and the stats increase */
                Assert.IsTrue(player.Hp > 100);
                Assert.IsTrue(player.Attack > 10);
                Assert.IsTrue(player.MagicAttack > 10);
                Assert.IsTrue(player.Defence > 10);

                /*try to simulate the keys pressed on the keyboard*/
                /* movement*/

                player.Input(key, collisions);
                Assert.AreEqual(Direction.UP, player.direction);

                key = new KeyEventArgs(Keys.A);
                player.Input(key, collisions);
                Assert.AreEqual(Direction.LEFT, player.direction);

                key = new KeyEventArgs(Keys.S);
                player.Input(key, collisions);
                Assert.AreEqual(Direction.DOWN, player.direction);

                key = new KeyEventArgs(Keys.D);
                player.Input(key, collisions);
                Assert.AreEqual(Direction.RIGHT, player.direction);

                /* attacking test */
                key = new KeyEventArgs(Keys.J);
                player.Input(key, collisions);
                Assert.IsTrue(player.Attacking);

                key = new KeyEventArgs(Keys.K);
                player.Input(key, collisions);
                Assert.IsTrue(player.MagicAttacking);

                Assert.Equals(0, player.SpellRemain);
                player.Hp = 0;
                Assert.IsTrue(player.IsDead());

            }

            [TestMethod]
            public void KeyInputTest()
            {

                key = new KeyEventArgs(Keys.W);
                inputKey.KeyPressed(key);
                key = new KeyEventArgs(Keys.A);
                inputKey.KeyPressed(key);
                key = new KeyEventArgs(Keys.S);
                inputKey.KeyPressed(key);
                key = new KeyEventArgs(Keys.D);
                inputKey.KeyPressed(key);
            }
        }
    }

}
}
