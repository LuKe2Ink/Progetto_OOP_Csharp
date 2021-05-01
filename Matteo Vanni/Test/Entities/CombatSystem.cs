using System;
namespace Test.Entities
{
         class CombatSystem
    {
        private Player Player { get; set; };
        private Enemy Enemy { get; set; };
        private ArrayList<Enemy> Enemies { get; set; };
        private Boss Boss { get; set; };
        private AaBb DirectionBox { get; set; };
        private bool Collide { get; set; };
        private AaBb PunchBox { get; set; };
        private int DungeonLevel { get; set; };

        private long Timer { get; set; };
        private long Lastime { get; set; };
        private String EnemyString { get; set; };
        private String BossString { get; set; };

        private AaBb[] MagicBoxes { get; set; };

      /**
       * Constructor.
       *
       * @throws IOException If a function that handler
       *                     call doesn't read a file
       *                     
       * @throws LineUnavailableException   If a function that handler
       *                                    call doens't open a line beacuse
       *                                    it's unavailable
       *                                    
       * @throws UnsupportedAudioFileException  If an audio file isn't supported
       */
      public CombatSystem(double effect) {

        EnemyString = "enemy";
        BossString = "boss";
    
        DungeonLevel = 1;
        Enemies = new ArrayList<>();
      }

  
      /**
       * Add entity Player.
       *
       * @param player this need for all player parameter
       */
      public void addPlayer(Player player) {
        Player = player;
        PunchBox = new AaBb(new Point(player.getX() - 1, player.getY()), 1, 2);
      }

      /**
       * Add entity enemy.
       *
       * @param enemy this need for all enemy parameter
       */
      public void addEnemy(final Enemy enemy) {
        this.enemies.add(enemy);
      }

      public void removeEnemy(final Enemy enemy) {
        this.enemies.remove(enemy);
      }

      /**
       * Add entity boss.
       *
       * @param boss this need for all boss parameter
       */
      public void addBoss(final Boss boss) {
        this.boss = boss;
      }

      /**
       * Generate player attack sprites.
       *
       * @param g Graphics2D
       */
      public void render(final Graphics2D g) {

        timer += System.currentTimeMillis() - lastime;
        if (this.player != null) {
          if (this.player.isAttacking()) {
            g.drawImage(punchImg, (this.punchBox.getX() - player.getFloor().getOffsetX()) * 32,
                (this.punchBox.getY() - player.getFloor().getOffsetY()) * 32, null);
          }

          if (this.player.isMagicAttacking()) {
            if (timer <= 500) {
              for (final AaBb box : this.magicBoxes) {
                g.drawImage(flameImg, (box.getX() - player.getFloor().getOffsetX()) * 32,
                    (box.getY() - player.getFloor().getOffsetY() - 1) * 32, null);
              }

            } else {
              this.player.setMagicAttacking(false);
            }
          } else if (!this.player.isMagicAttacking()) {
            timer = 0;
          }
        }

        lastime = System.currentTimeMillis();
      }

      /**
       * Used when player make an attack.
       */
      public void playerAttack() {
        collide = false;

        switch (this.player.getDirection()) {
          case DOWN:
            directionBox = new AaBb(new Point(player.getX(), player.getY() + 1), 1, 2);
  
            if (!this.enemies.isEmpty()) {
              enemies.forEach(x -> {
                if (directionBox.collides(x.getBox())) {
                  collide = true;
                  enemy = x;
                }
              });
              this.damagePlayer(enemyString, collide);
            } else if (this.dungeonLevel % 5 == 0 && boss != null) {
              if (directionBox.collides(this.boss.getBox())) {
                this.collide = true;
                this.damagePlayer(bossString, collide);
              }
            }
  
            punchBox = new AaBb(new Point(player.getX(), player.getY() + 1), 1, 2);
  
            break;
  
          case LEFT:
            directionBox = new AaBb(new Point(player.getX() - 1, player.getY()), 1, 2);
  
            if (!this.enemies.isEmpty()) {
              enemies.forEach(x -> {
                if (directionBox.collides(x.getBox())) {
                  collide = true;
                  enemy = x;
                }
              });
              this.damagePlayer(enemyString, collide);
            } else if (this.dungeonLevel % 5 == 0 && boss != null) {
              if (directionBox.collides(this.boss.getBox())) {
                this.collide = true;
                this.damagePlayer(bossString, collide);
              }
            }
  
            punchBox = new AaBb(new Point(player.getX() - 1, player.getY() - 1), 1, 2);
  
            break;
  
          case RIGHT:
            directionBox = new AaBb(new Point(player.getX() + 1, player.getY()), 1, 2);
  
            if (!this.enemies.isEmpty()) {
              enemies.forEach(x -> {
                if (directionBox.collides(x.getBox())) {
                  collide = true;
                  enemy = x;
                }
              });
              this.damagePlayer(enemyString, collide);
            } else if (this.dungeonLevel % 5 == 0 && boss != null) {
              if (directionBox.collides(this.boss.getBox())) {
                this.collide = true;
                this.damagePlayer(bossString, collide);
              }
            }
  
            punchBox = new AaBb(new Point(player.getX() + 1, player.getY() - 1), 1, 2);
  
            break;
  
          case UP:
            directionBox = new AaBb(new Point(player.getX(), player.getY() - 1), 1, 2);
  
            if (!this.enemies.isEmpty()) {
              enemies.forEach(x -> {
                if (directionBox.collides(x.getBox())) {
                  collide = true;
                  enemy = x;
                }
              });
              this.damagePlayer(enemyString, collide);
            } else if (this.dungeonLevel % 5 == 0 && boss != null) {
              if (directionBox.collides(this.boss.getBox())) {
                this.collide = true;
                this.damagePlayer(bossString, collide);
              }
            }
  
            punchBox = new AaBb(new Point(player.getX(), player.getY() - 2), 1, 2);
  
            break;
      
          default:
            break;
        }
      }

      /**
       * Used when player take damage from enemy/boss.
       *
       * @param type    type of enemy that damage the player
       * @param collide boolean that control if the player box collides with entity
       *                attack
       */
      public void damagePlayer(final String type, final boolean collide) {
        if (this.player.getFloor().getMap().get(directionBox.getpos()).gettype() 
            != TileType.OFF) {
          if (type.equals(bossString)) {
            if (!boss.isDead()) {
              if (collide) {
                boss.setHp(boss.getHp() - (player.getAttack() - boss.getDefence()));

                if (!punchSound.isRunning()) {
                  punchSound.loop(1);
                }

                if (boss.isDead()) {
                  this.player.addExp(this.boss.getExpGuaranteed());
                  boss.getBossFloor().exitCreate(boss.getBox().getpos());
                }
              }
            }
          } else if (type.equals(enemyString)) {
            if (collide) {
              enemy.setHp(enemy.getHp() - (player.getAttack() - enemy.getDefence()));

              if (!punchSound.isRunning()) {
                punchSound.loop(1);
              }

              if (enemy.isDead()) {
                this.player.addExp(this.enemy.getExpGuaranteed());
                this.removeEnemy(enemy);
              }
            }
          }
        }
      }

      /**
       * Used when the player use the magic attack.
       */
      public void playerMagicAttack() {
        this.player.setSpells();
        final AaBb[] magicBoxes = { 
            new AaBb(new Point(this.player.getX() - 1, this.player.getY() - 1), 1, 1),
            new AaBb(new Point(this.player.getX(), this.player.getY() - 1), 1, 1),
            new AaBb(new Point(this.player.getX() + 1, this.player.getY() - 1), 1, 1),
            new AaBb(new Point(this.player.getX() - 1, this.player.getY()), 1, 1),
            new AaBb(new Point(this.player.getX() + 1, this.player.getY()), 1, 1),
            new AaBb(new Point(this.player.getX() + 1, this.player.getY() + 1), 1, 1),
            new AaBb(new Point(this.player.getX() - 1, this.player.getY() + 1), 1, 1),
            new AaBb(new Point(this.player.getX() - 1, this.player.getY() + 2), 1, 1),
            new AaBb(new Point(this.player.getX(), this.player.getY() + 2), 1, 1),
            new AaBb(new Point(this.player.getX() + 1, this.player.getY() + 2), 1, 1) };

        this.magicBoxes = magicBoxes;

        if (this.dungeonLevel % 5 != 0 && !(this.enemies.isEmpty())) {
          for (final AaBb box : magicBoxes) {
            this.enemies.forEach(x -> {

              if (box.collides(x.getBox())) {
                collide = true;
                if (collide) {
                  this.magicDamage(x);
                }
              }

            });

          }

          this.enemies = removethedead(enemies);

        } else if (this.dungeonLevel % 5 == 0 && !this.boss.isDead()) {
          this.magicDamageBoss();
        }

      }

      /**
       * Used when player kill enemy with agic attack.
       *
       * @param e Enemy
       */
      public void magicDamage(final Enemy e) {
        this.enemy = e;
        enemy.setHp(enemy.getHp() - this.player.getMagicAttack());

        if (enemy.isDead()) {
          this.player.addExp(enemy.getExpGuaranteed());
        }
      }

      /**
       * Used in boss floor for the moving boss magic attack.
       */
      public void magicDamageBoss() {
        switch (this.player.getInventory().getPowerStone()) {
          case 1:
            boss.setHp(boss.getHp() - (this.player.getMagicAttack() / 2));
            break;
  
          case 2:
            boss.setHp((int) ((boss.getHp() - (this.player.getMagicAttack()) / 1.5)));
            break;
  
          case 3:
            boss.setHp(boss.getHp() - this.player.getMagicAttack());
            break;
      
          default:
            break;

        }

        if (boss.isDead()) {
          this.player.addExp(this.boss.getExpGuaranteed());
          boss.getBossFloor().exitCreate(boss.getBox().getpos());

        }
      }

      /**
       * Attack of the normal enemy.
       *
       * @param enemy attack from enemy to player
       */
      public void enemyAttack(final Enemy enemy) {
        if (enemy.getAttack() - player.getDefence() > 0) {
          player.setHp(player.getHp() - (enemy.getAttack() - player.getDefence()));
        }

        boneSound.loop(1);
      }

      /**
       * Attack of the boss.
       *
       * @param boss attack from boss to player
       */
      public void bossAttack(final Boss boss) {
        if (boss.getAttack() - player.getDefence() > 0)
        {
          player.setHp(player.getHp() - (boss.getAttack() - player.getDefence()));
        }

        bossSound.loop(1);
      }

      /**
       * Boss flame attack damage output.
       */
      public void flamesAttack() {
        player.setHp(player.getHp() - ((int) (player.getMaxHp() * 20 / 100)));
      }

      /**
       * Decrease boss stats when player take power stone.
       */
      public void lowerBossStats() {
        switch (player.getInventory().getPowerStone())
        {
          case 0:
            break;
  
          case 1:
            this.boss.setAttack(this.boss.getAttack() / 2);
            this.boss.setDefence(this.boss.getDefence() / 2);
            break;
  
          case 2:
            this.boss.setAttack(this.boss.getAttack() / 2);
            this.boss.setDefence(this.boss.getDefence() / 2);
            break;
  
          case 3:
            this.boss.setAttack(this.boss.getAttack() / 2);
            this.boss.setDefence(0);
            break;
      
          default:
            break;
        }
      }

      private List<Enemy> removethedead(final List<Enemy> enemies) {
        return enemies.stream().filter(x -> !x.isDead()).collect(Collectors.toList());
      }
}
}
}
