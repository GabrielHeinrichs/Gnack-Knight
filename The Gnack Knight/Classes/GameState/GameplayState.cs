using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using The_Gnack_Knight.Classes;
using The_Gnack_Knight.Classes.Abstract;
using The_Gnack_Knight.Classes.Bullets;
using The_Gnack_Knight.Classes.Enemies;

namespace The_Gnack_Knight.Classes.GameState
{
    public class GameplayState : GameState
    {
        private InputHandler inputHandler;
        private BulletManager bulletManager;
        private EnemyManager enemyManager;
        private Spawner spawner;
        private Player player;
        private GUI gui;
        private SpriteFont font;
        private float elapsedTime = 0f;
        private bool isGameOver = false;

        public GameplayState(GameStateManager stateManager, ContentManager content, SpriteBatch spriteBatch, TextureLoader textures, GraphicsDeviceManager graphics)
            : base(stateManager, content, spriteBatch, textures, graphics)
        {
        }

        public override void LoadContent()
        {
            font = _content.Load<SpriteFont>("Arial");
            gui = new GUI(spriteBatch);

            player = new Player(textures.Get("Black-Dot"), new Vector2(100, 100));
            inputHandler = new InputHandler(player);
            bulletManager = new BulletManager(graphics.GraphicsDevice);
            enemyManager = new EnemyManager(player, bulletManager, graphics.GraphicsDevice, textures.Get("Red"));
            spawner = new Spawner(enemyManager);

            bulletManager.SubscribeToPlayer(player);
            gui.SetFontLives(font);
        }

        public override void Update(GameTime gameTime)
        {
            if (isGameOver)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    _stateManager.ExitGame();
                }
                return;
            }

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            elapsedTime += deltaTime;

            // Handle player input
            inputHandler.Execute();

            player.UpdateCooldown(gameTime);

            if (player.Health <= 0)
            {
                isGameOver = true;
            }

            enemyManager.Update(gameTime);
            spawner.Update(deltaTime);
            bulletManager.Update(gameTime, enemyManager, player);

            gui.UpdateGUI(player.Health);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            spriteBatch.Draw(player.texture, player.Position, Color.White);

            foreach (Bullet bullet in bulletManager.GetBullets())
            {
                bullet.Update(new GameTime()); // Make sure bullets update before drawing
                spriteBatch.Draw(bullet.Texture, bullet.Position, Color.White);
            }

            foreach (Enemy enemy in enemyManager.GetEnemies())
            {
                enemy.Draw(spriteBatch);
            }

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
        }
    }
}