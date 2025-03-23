using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using The_Gnack_Knight.Classes;
using The_Gnack_Knight.Classes.Enemies;

namespace The_Gnack_Knight.Classes.Bullets
{
    // This class manages bullets within the game. This includes spawning, updating, and handling behaviors
    public class BulletManager
    {
        
        public List<Bullet> bullets = new List<Bullet>();
        private Texture2D bulletTexture;
        private GraphicsDevice graphicsDevice;

        // default constructor
        public BulletManager() {}

        // constructor that initializes bullet textures
        public BulletManager(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
            bulletTexture = CreateCircleTexture(10, Color.Black);
        }

        // subscribes to the player's shooting event to spawn player bullets
        public void SubscribeToPlayer(Player player)
        {
            player.OnShoot += (position, direction) => SpawnPlayerBullet(position, direction);
        }

        // spanws a bullet for the player in the direction they are aiming
        public void SpawnPlayerBullet(Vector2 position, float aimingDirection)
        {
            // Convert aiming direction (degrees) to a unit vector
            Vector2 bulletVelocity = new Vector2(
                (float)Math.Cos(MathHelper.ToRadians(aimingDirection)),
                (float)Math.Sin(MathHelper.ToRadians(aimingDirection))
            );

            // Normalize to ensure consistent speed
            bulletVelocity.Normalize();
            bulletVelocity *= 5f; // Adjust speed as needed

            Bullet newBullet = new PlayerBullet(
                CreateCircleTexture(3, Color.Black),
                position,
                false,
                bulletVelocity
            );

            bullets.Add(newBullet);
        }

        // updates all the bullets in the game using the list of bullets. Removes inactive ones.
        public void Update(GameTime gameTime, EnemyManager enemyManager, Player player) {
            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                bullets[i].Update(gameTime);

                bool hitEnemy = false;

                // Check if this is a player bullet
                if (!bullets[i].IsEnemyBullet)
                {
                    foreach (var enemy in enemyManager.GetEnemies())
                    {
                        if (bullets[i].GetHitbox().Intersects(enemy.GetHitbox()))
                        {
                            Console.WriteLine($"[HIT DETECTED] Bullet hit {enemy.GetType().Name} at {enemy.Position}");
                            hitEnemy = true;
                            break;  // Stop checking other enemies, bullet is destroyed
                        }
                    }

                    if (hitEnemy)
                    {
                        bullets.RemoveAt(i);
                        continue;  //  Skip the rest of the loop for this bullet
                    }
                }

                //  Enemy bullets can only hit the player
                if (bullets[i].IsEnemyBullet && bullets[i].GetHitbox().Intersects(player.GetHitbox()))
                {
                    Console.WriteLine("[HIT] Enemy bullet hit Player");
                    player.TakeDamage();
                    bullets.RemoveAt(i);
                    continue;  // Skip the rest, bullet is gone
                }

                // Finally check if bullet is inactive (like offscreen)
                if (!bullets[i].IsActive)
                {
                    bullets.RemoveAt(i);
                }
            }
        }

        // retrieves all active bullets from the list of bullets
        public List<Bullet> GetBullets() {
            return bullets;
        }
        
        // creates a circular texture for the bullets
        private Texture2D CreateCircleTexture(int radius, Color color)
        {
            int diameter = radius * 2;
            Texture2D texture = new Texture2D(graphicsDevice, diameter, diameter);
            Color[] data = new Color[diameter * diameter];

            for (int y = 0; y < diameter; y++)
            {
                for (int x = 0; x < diameter; x++)
                {
                    int dx = x - radius;
                    int dy = y - radius;
                    if (dx * dx + dy * dy <= radius * radius)
                        data[y * diameter + x] = color;
                    else
                        data[y * diameter + x] = Color.Transparent;
                }
            }

            texture.SetData(data);
            return texture;
        }

        // subscribes to an enemy's shooting event to spawn bullets aimed at the player
        public void SubscribeToEnemy(Enemy enemy, Player player)
        {
            enemy.OnShoot += (position) => SpawnEnemyBullet(position, player);
        }

        // spawns bullets from an enemy and aims at the player
        public void SpawnEnemyBullet(Vector2 position, Player player)
            {
                Vector2 direction = player.Position - position;
                direction.Normalize();
                direction *= 3f;

                Bullet newBullet = new EnemyBullet(
                    CreateCircleTexture(3, Color.Black),
                    position,
                    true,
                    direction
                );

                bullets.Add(newBullet);
            }
    }
}