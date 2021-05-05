using System;
using Test.Entities;
using Xunit;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void CombatSystem()
        {
            CombatSystem combat = new();
            Player player = new(1, 0, combat, 1, 100, 20, 10, 50);
            Enemy enemy = new(2, 0, combat, 1, 100, 20, 10, player);
            enemy.SetDirection(Entity.Direction.LEFT);
            combat.AddEnemy(ref enemy);
            combat.AddPlayer(ref player);

            //the player attack the enemy with a normal attack
            player.GetCombat().PlayerAttack();
            Assert.Equal(90, enemy.GetHp());

            //the player attack the enemy with a magic attack
            player.GetCombat().PlayerMagicAttack();
            Assert.Equal(40, enemy.GetHp());

            //the player has finished the "spells" and it can't magic attack
            player.GetCombat().PlayerMagicAttack();
            Assert.Equal(40, enemy.GetHp());

            //the player attack the enemy without "looking" at it
            player.SetDirection(Entity.Direction.LEFT);
            player.GetCombat().PlayerAttack();
            Assert.Equal(40, enemy.GetHp());

            //the enemy attack the player
            enemy.GetCombat().EnemyAttack();
            Assert.Equal(90, player.GetHp());

            //the enemy attack the player without "looking" at it
            enemy.SetDirection(Entity.Direction.RIGHT);
            enemy.GetCombat().EnemyAttack();
            Assert.Equal(90, player.GetHp());

            player.SetDirection(Entity.Direction.RIGHT);
            player.GetCombat().PlayerAttack();
            player.GetCombat().PlayerAttack();
            player.GetCombat().PlayerAttack();
            player.GetCombat().PlayerAttack();
            Assert.Equal(0, enemy.GetHp());

            Assert.True(enemy.IsDead());

        }
    }
}
