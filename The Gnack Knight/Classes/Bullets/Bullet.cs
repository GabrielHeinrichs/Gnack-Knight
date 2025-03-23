using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using The_Gnack_Knight.Classes.Abstract;
using The_Gnack_Knight.Classes.Interface;

namespace The_Gnack_Knight.Classes.Bullets
{
    // Base class for all bullet types
    public abstract class Bullet : Entity
    {
        // Public fields
        public Texture2D Texture { get; set; }
        public Vector2 Velocity { get; set; }
        public float Acceleration { get; set; }
        public float Speed { get; set; }
        public int Damage { get; set; }

        // Whether the bullet is active or not
        public bool IsActive { get; set; }
        // Checks if it is an enemies bullet
        public bool IsEnemyBullet { get; private set; }

        // Determines the movement of the bullet.
        protected IMovementPattern movementPattern;

        // Parameterized constructor
        public Bullet(Texture2D texture, Vector2 position, Vector2 velocity, float speed, int damage, bool isEnemyBullet, IMovementPattern movementPattern) {
            Texture = texture;
            Position = position;
            Velocity = velocity;
            Speed = speed;
            Damage = damage;
            IsActive = true;
            IsEnemyBullet = isEnemyBullet;
            this.movementPattern = movementPattern;
        }

        // Is called with every new frame.
        public virtual void Update(GameTime gameTime) {
            movementPattern.Move(this, gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch) {
            if (IsActive) 
            {
                spriteBatch.Draw(Texture, Position, Color.White);
            }
        }

        public abstract void OnCollision();

        /// <summary>
        /// Checks if this bullet collides with a given entity.
        /// </summary>
        /// <param name="entity">The entity to check collision against.</param>
        /// <returns>True if collision detected, otherwise false.</returns>
        public bool CheckCollision(Entity entity)
        {
            return this.GetHitbox().Intersects(entity.GetHitbox());
        }
    }
}
