using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace The_Gnack_Knight.Classes.GameState
{
    public class MainMenuState : GameState
    {
        private SpriteFont font;
        private Texture2D spriteTexture;

        public MainMenuState(GameStateManager stateManager, ContentManager content, SpriteBatch spriteBatch, TextureLoader textures, GraphicsDeviceManager graphics)
            : base(stateManager, content, spriteBatch, textures, graphics) { }

        public override void LoadContent()
        {
            font = _content.Load<SpriteFont>("Arial");  // Load a font for text
            spriteTexture = _content.Load<Texture2D>("The-Gnack-Knight-3-23-2025.png");
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                _stateManager.ChangeState(new GameplayState(_stateManager, _content, spriteBatch, textures, graphics));
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            if (spriteTexture == null)
                Console.WriteLine("Texture not loaded!");

            spriteBatch.Draw(spriteTexture, new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 4, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 4), Color.White);

            spriteBatch.DrawString(font, "Press Enter to Start", new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 4, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 4), Color.White);

            spriteBatch.End();
        }
    }
}
