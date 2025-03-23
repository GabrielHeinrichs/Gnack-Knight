using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace The_Gnack_Knight.Classes.Abstract
{
    /*
     * This class represents anything on the screen that has health and deals damage.
     * Will be used as an abstract bvase class.
     */
    public abstract class Character : Entity 
    {
        // Public fields
        public int health;
        public int damage;
        public float AimingDirection { get; protected set; } = 270f; // Degrees (0-359)
        public float AimDirection { get; private set; }
        public event Action<Vector2, float> OnShoot; 
        public Entity target;

        protected float shootCooldown = 1.5f; // Seconds between shots
        protected float timeSinceLastShot = 0f;


        // Default constructor, shouldn't be used.
        public Character(Texture2D texture, int x, int y, int rightCollider, int leftCollider, int topCollider, int bottomCollider)
            : base(texture, new Vector2(x, y), rightCollider, leftCollider, topCollider, bottomCollider)
        {
            this.health = 0;
            this.damage = 0;
        }

        // Parameterized constructor
        public Character(Texture2D texture, int health, int damage)
            : base(texture, new Vector2(0, 0), 5, 5, 5, 5) // Ensures Entity is initialized properly
        {
            this.texture = texture;
            this.health = health;
            this.damage = damage;
        }

        // Will notify a subscribed class of this class wanting to shoot.
        public virtual void Shoot()
        {
            OnShoot?.Invoke(this.Position, this.AimingDirection);
        }

        public void Aim(Entity entity)
        {
            if (entity == null) return; // Prevents NullReferenceException
            Vector2 direction = entity.Position - this.Position;
            direction.Normalize(); // Get a unit vector
            AimDirection = (float)System.Math.Atan2(direction.Y, direction.X); // Store as radians
            target = entity;
        }
    }
}
