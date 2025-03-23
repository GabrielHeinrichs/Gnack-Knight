using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace The_Gnack_Knight.Classes.Abstract
{
    /*
     * This class simply represents anything on screen that has a hitbox and sprite.
     * Will be used as an abstract base class.
     */
    public abstract class Entity
    {
        // Public fields
        public Texture2D texture;
        public Vector2 Position {get; set;}

        // Default constructor, shouldn't be used.
        public Entity()
        {
            this.texture = null;
            this.Position = new Vector2(0, 0);
        }

        // Parameterized constructor
        public Entity(Texture2D texture, Vector2 position, int rightCollider, int leftCollider, int topCollider, int bottomCollider)
        {
            this.texture = texture;
            this.Position = position;
        }

        // Centralized hitbox method
        public virtual Rectangle GetHitbox()
        {
            int inflateAmount = 3; // Makes hitbox bigger
            Rectangle hitbox = new Rectangle((int)Position.X, (int)Position.Y, texture?.Width ?? 0, texture?.Height ?? 0);
            hitbox.Inflate(inflateAmount, inflateAmount);
            return hitbox;
        }
    }
}
