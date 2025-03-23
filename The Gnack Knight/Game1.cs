using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using The_Gnack_Knight.Classes;
using The_Gnack_Knight.Classes.Abstract;
using The_Gnack_Knight.Classes.Bullets;
using The_Gnack_Knight.Classes.Enemies;

namespace The_Gnack_Knight
{
    public class Game1 : Game
    {
        private TextureLoader textures; // Handles loading all textures in the game
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private InputHandler inputHandler; // Manages player input

        private GUI gui;

        private BulletManager bulletManager; // Handles bullets fired by the player
        private EnemyManager enemyManager; // Manages enemy spawning and updating
        private Spawner spawner;  // Controls enemy wave spawning
        private Player player; // The main player character

        private SpriteFont font;
        private float elapsedTime = 0f; // Tracks time for game events
        private bool isGameOver = false;

        public Game1()
        {
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics = new GraphicsDeviceManager(this);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            // Load texture manager and create necessary game objects
            textures = new TextureLoader(Content);
            spriteBatch = new SpriteBatch(GraphicsDevice);


            gui = new GUI(spriteBatch);

            // Initialize player with a loaded texture
            player = new Player(textures.Get("Black-Dot"), new Vector2(100, 100));
            inputHandler = new InputHandler(player);
            bulletManager = new BulletManager(GraphicsDevice);


            // Initialize enemy manager with a valid enemy texture
            enemyManager = new EnemyManager(player, bulletManager, GraphicsDevice, textures.Get("Red"));

            // Initialize spawner and pass the enemy manager
            spawner = new Spawner(enemyManager);

            // Subscribe the player to the bullet manager for shooting mechanics
            bulletManager.SubscribeToPlayer(player);

            // TODO: Subscribe the enemies and bosses to bullet manager too

            /*EnemyFactory.defaultGruntTexture = textures.Get("Black-Dot");
            enemyManager.SpawnEnemy(EnemyFactory.CreateGrunt(new Vector2(50, 50)));
           */
            base.Initialize();
        }

        protected override void LoadContent()
        {
            font = Content.Load<SpriteFont>("Arial");

            gui.SetFontLives(font);

            // TODO: use Content to load your game content here
        }

        // Is called every frame of the game.
        protected override void Update(GameTime gameTime)
        {
            if (isGameOver)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    Exit();
                }
                return;
            }

            // TODO: Add your update logic here
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            elapsedTime += deltaTime;

            // Update player mechanics
            player.UpdateCooldown(gameTime);

            if (player.Health <= 0)
            {
                isGameOver = true;
            }

            inputHandler.Execute();

            // Update active enemies
            enemyManager.Update(gameTime);

            // Update spawner to control enemy spawning
            spawner.Update(deltaTime);

            bulletManager.Update(gameTime, enemyManager, player);

            // changed player.health to player.Health
            gui.UpdateGUI(player.Health);

            base.Update(gameTime);
        }

        // Draws every frame of the game.
        // Use this to draw: spriteBatch.Draw(texture, position, Color.White);
        // With the Color.White, it does not change the tint of the sprite.
        // Code between spriteBatch.Begin() and End();
        protected override void Draw(GameTime gameTime)
        {
            // TODO: Add your drawing code here

            // Clear the screen
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            // Draw the player character
            spriteBatch.Draw(player.texture, player.Position, Color.White);

            // Draws every bullet managed by bulletManager.
            foreach (Bullet bullet in bulletManager.GetBullets())
            {
                bullet.Update(gameTime);
                spriteBatch.Draw(bullet.Texture, bullet.Position, Color.White);
            }

            // Draw all active enemies
            foreach (Enemy enemy in enemyManager.GetEnemies())
            {
                enemy.Draw(spriteBatch);
            }

            // Draw elapsed time text on the screen
            string timeText = $"Time Survived: {elapsedTime:F2}";
            spriteBatch.DrawString(font, timeText, new Vector2(10, 40), Color.White);

            gui.DrawGUI(textures.Get("Red"), player.Health);

            if (isGameOver)
            {
                string gameOverText = "Game Over\nPress ESC to Exit";
                Vector2 textSize = font.MeasureString(gameOverText);
                Vector2 position = new Vector2(
                    graphics.PreferredBackBufferWidth / 2 - textSize.X / 2,
                    graphics.PreferredBackBufferHeight / 2 - textSize.Y / 2
                );

                spriteBatch.DrawString(font, gameOverText, position, Color.Red);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
