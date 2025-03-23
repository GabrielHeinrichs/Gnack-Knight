using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using The_Gnack_Knight.Classes.MovementPatterns;

namespace The_Gnack_Knight.Classes.Enemies
{
    /// <summary>
    /// This is a basic enemy that just stands still. Proof of concept mostly
    /// </summary>
    public  class BasicEnemy : Enemy
    {
        public BasicEnemy(Texture2D texture, Vector2 position, Player player) : base(texture,position, player)
        {
            // ✅ Set a default movement pattern to avoid null exceptions
            enemyMovementPattern = new StationaryMovement(); // Or whatever default movement you want
        }

        /// <summary>
        /// Draws the enemy on the screen, checking if texture is valid to avoid crashes.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch used for rendering.</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (this.texture != null) // Prevents crash if texture is missing
            {
                spriteBatch.Draw(this.texture, this.Position, Color.White);
            }
        }
    }
}