using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace The_Gnack_Knight.Classes
{
    public class GUI
    {
        private Rectangle healthBar;
        SpriteBatch spriteBatch;

        // show lives
        private SpriteFont fontLives;

        public GUI(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
        }

        public void UpdateGUI(int health)
        {
            healthBar = new Rectangle(50, 20, health, 20);
        }

        public void DrawGUI(Texture2D healthTexture, int lives)
        {
            spriteBatch.Draw(healthTexture, new Vector2(10f, 10f), healthBar, Color.White);

            if (fontLives != null)
            {
                spriteBatch.DrawString(fontLives, $"Lives: {lives}", new Vector2(10f, 70f), Color.White);
            }
        }

        public void SetFontLives(SpriteFont spriteFont)
        {
            this.fontLives = spriteFont;
        }
    }
}
