using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Test;
namespace XUnit_Test_Vanni
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
            player = new Player(1, 1, 1, 100, 10, 10, 10, ID.Player);
            collisions = new List<AaBb>();
            inputKey = new KeyInput(new List<GameObject>());
        } 

        [TestMethod]
        public void Player_test()
        {
            Assert.AreEqual(player.MaxHp, player.Hp);
            Assert.IsFalse(player.IsDead());

            player.addExp(60);// level up beacuse the player need 50 exp
            Assert.AreEqual(2, player.Level);
            player.addExp(20);
            Assert.AreNotEqual(3, player.Level);

            /* the player level up and the stats increase */
            Assert.IsTrue(player.Hp > 100);
            Assert.IsTrue(player.Attack > 10);
            Assert.IsTrue(player.MagicAttack > 10);
            Assert.IsTrue(player.Defence > 10);

            /*try to simulate the keys pressed on the keyboard*/
            /* movement*/
            key = new KeyEventArgs(Keys.W);
            player.Input(key, collisions);
            Assert.AreEqual(Direction.UP, player.Directions);

            key = new KeyEventArgs(Keys.A);
            player.Input(key, collisions);
            Assert.AreEqual(Direction.LEFT, player.Directions);
            
            key = new KeyEventArgs(Keys.S);
            player.Input(key, collisions);
            Assert.AreEqual(Direction.DOWN, player.Directions);

            key = new KeyEventArgs(Keys.D);
            player.Input(key, collisions);
            Assert.AreEqual(Direction.RIGHT, player.Directions);

            /* attacking test */
            key = new KeyEventArgs(Keys.J);
            player.Input(key, collisions);
            Assert.IsTrue(player.Attacking);

            key = new KeyEventArgs(Keys.K);
            player.Input(key, collisions);
            Assert.IsTrue(player.MagicAttacking);

            //Assert.Equals(0, player.SpellRemain);
            player.Hp = 0;
            Assert.IsTrue(player.IsDead());

        }

        [TestMethod]
        public void KeyInputTest()
        {

            key = new KeyEventArgs(Keys.W);
            
            //Multiple insert for Moves augment
            inputKey.KeyPressed(key, player);

            Assert.IsTrue(inputKey.IsPlayer);
            Assert.IsFalse(player.Attacking);
            Assert.IsFalse(player.Flag);
            Assert.IsTrue(inputKey.Moves>=2);//because the list is made out of 4 GameObject

            key = new KeyEventArgs(Keys.A);
            inputKey.KeyReleased(key, player);
            Assert.IsFalse(player.Attacking);
            Assert.IsFalse(player.Movement);
            Assert.IsTrue(player.VelY < 1);//Because W key is not released
            Assert.IsTrue(player.VelX == 0);

            //key = new KeyEventArgs(Keys.A);

        }
    }
}

