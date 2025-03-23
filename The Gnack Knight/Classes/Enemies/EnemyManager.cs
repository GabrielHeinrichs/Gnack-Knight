using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using The_Gnack_Knight.Classes.Bullets;

namespace The_Gnack_Knight.Classes.Enemies
{
    /// <summary>
    /// This is where all of the enemies will be managed. It can contain numerous types of enemies
    /// </summary>
    public class EnemyManager
    {
        
        public List<Enemy> enemies = new List<Enemy>(); // List of active enemies
        private Player player;
        private BulletManager bulletManager;
        private GraphicsDevice graphicsDevice; // Reference to the graphics device for rendering
        private Texture2D basicEnemyTexture; // Texture used for spawning basic enemies
        //private Spawner spawner;
        //private Player player;

        public EnemyManager() {} 
        public EnemyManager(Player player, BulletManager bulletManager, GraphicsDevice graphicsDevice, Texture2D basicEnemyTexture)
        {
            this.player = player;
            this.bulletManager = bulletManager;
            this.graphicsDevice = graphicsDevice;
            this.basicEnemyTexture = basicEnemyTexture ?? CreateDefaultTexture(); // Ensure texture is never null
        }

        /// <summary>
        /// Spawns an enemy based on the provided type and position.
        /// </summary>
        public void SpawnEnemy(float x, float y, string type)
        {
            Enemy newEnemy = null;

            if (type == "BasicEnemy")
            {
                newEnemy = new BasicEnemy(basicEnemyTexture, new Vector2(x, y), null); // Player is set to null for now
            }

            if (newEnemy != null)
            {
                enemies.Add(newEnemy); // Add enemy to the list of active enemies
                bulletManager.SubscribeToEnemy(newEnemy, player);
            }

        }


        /// <summary>
        /// Updates all active enemies.
        /// </summary>
        public void Update(GameTime gameTime)
        {
            for (int i = enemies.Count - 1; i >= 0; i--) // Iterate in reverse to safely remove elements
            {
                enemies[i].Update(gameTime);
                if (enemies[i].IsDestroyed) // Check if enemy should be removed
                {
                    enemies.RemoveAt(i); // Remove destroyed enemies
                }
            }
        }

        /// <summary>
        /// Draws all active enemies.
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var enemy in enemies)
            {
                enemy.Draw(spriteBatch);
            }
        }

        /// <summary>
        /// Creates a default white texture if no valid texture is provided.
        /// </summary>
        /// <returns>A simple 1x1 white texture.</returns>
        private Texture2D CreateDefaultTexture()
        {
            Texture2D texture = new Texture2D(graphicsDevice, 1, 1);
            texture.SetData(new[] { Color.White });
            return texture;
        }


        public List<Enemy> GetEnemies() {
            return this.enemies;
        }
        
        private Texture2D CreateCircleTexture(int radius, Color color)
        {
            int diameter = radius * 2;
            Texture2D texture = new Texture2D(this.graphicsDevice, diameter, diameter);
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
    }
}