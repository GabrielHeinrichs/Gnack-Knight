using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using The_Gnack_Knight.Classes.Abstract;
using The_Gnack_Knight.Classes.Interface;
using The_Gnack_Knight.Classes.MovementPatterns;

namespace The_Gnack_Knight.Classes.Enemies
{
    /// <summary>
    /// This class is an abstract class for all enemies we will create
    /// </summary>
    public abstract class Enemy : Character, ISpawner
    {
        protected IMovementPattern enemyMovementPattern; //every enemy will have a movement pattern, this can change over time

        /// <summary>
        /// Property to check if the enemy should be removed from the game.
        /// Enemy is considered destroyed when its health reaches 0.
        /// </summary>
        public bool IsDestroyed => health <= 0;

        // Public fields
        public new event Action<Vector2> OnShoot;
        public bool IsActive { get; set; } // Is the enemy still alive ///
        public Texture2D Texture => texture; // Getter for the texture property ////
        public float SpawnInterval { get; set; }
        public float DespawnInterval { get; set; }
        public float ElapsedTime { get; set; }

        // Default constructor, shouldn't be used.
        public Enemy() : base(null, 0, 0, 0, 0, 0, 0) { }

        // public bool IsActive; //Is the enemy still alive

        // Parameterized constructor
        public Enemy(Texture2D texture, Vector2 position, Player player)
            : base(texture, (int)position.X, (int)position.Y, 5, 5, 5, 5)
        {
            this.texture = texture;

            this.health = 25;
            this.damage = 1;
            IsActive = true;
            target = player;

            // ✅ Set a default movement pattern to avoid null exceptions
            enemyMovementPattern = new StationaryMovement(); // Or whatever default movement you want
        }

        public virtual void Update(GameTime gameTime)
        {
            enemyMovementPattern.Move(this, gameTime);
            Aim(target);
            timeSinceLastShot += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timeSinceLastShot >= shootCooldown)
            {
                Shoot();
                timeSinceLastShot = 0f;
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (IsActive) 
            {
                spriteBatch.Draw(texture, Position, Color.White);
            }
        }

        public void Spawn(Vector2 position)
        {
            Position = position;
            IsActive = true;
            Console.WriteLine($"Enemy spawned at position: {position}");
        }

        public void Despawn()
        {
            Position = new Vector2(-texture.Width, -texture.Height); // Move enemy off-screen
            IsActive = false;
            Console.WriteLine("Enemy despawned.");
        }

        public override void Shoot()
        {
            OnShoot?.Invoke(this.Position);
        }


        // // Will notify a subscribed class of this class wanting to shoot.
        // public override void Shoot()
        // {
        //     OnShoot?.Invoke(this.position);
        // }

        //create enemy

        //create movement pattern
        //public void PresetMovementPattern_1()

        //create bullet tracking system
    }
}