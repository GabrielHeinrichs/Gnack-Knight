using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using The_Gnack_Knight.Classes.Abstract;

namespace The_Gnack_Knight.Classes
{
    public class Player : Character
    {
        // private health below is unused so I commented it out
        //private int health;
        private int damage;

        // default number of lives is three
        public int Health { get; private set; } = 3; // Encapsulated health property
        public int Damage { get; private set; } // Encapsulated damage property

        public bool IsVulnerable { get; private set; } = false;
        private float invulnderabilityTimer = 0f;

        public readonly int walkSpeed;
        public readonly int runSpeed;

        public Player(Texture2D texture, Vector2 position, int walkSpeed = 1, int runSpeed = 2, float shootCooldown = 0.5f)
            : base(texture, (int)position.X, (int)position.Y, 5, 5, 5, 5) // Calls base constructor properly
        {
            this.texture = texture;
            this.Position = position;

            this.health = 25;
            this.damage = 1;

            this.walkSpeed = walkSpeed;
            this.runSpeed = runSpeed;
            this.shootCooldown = shootCooldown;
        }

        public void Move(Vector2 displacement)
        {
            this.Position += displacement;
        }

        public void SetAim(float direction)
        {
            AimingDirection = direction;
        }

        public void UpdateCooldown(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            timeSinceLastShot += deltaTime;

            if (IsVulnerable)
            {
                invulnderabilityTimer -= deltaTime;
                if (invulnderabilityTimer < 0)
                {
                    IsVulnerable = false;
                }
            }
        }

        public override void Shoot()
        {
            if (timeSinceLastShot >= shootCooldown)
            {
                timeSinceLastShot = 0f;
                base.Shoot();
            }
        }

        public void Respawn()
        {
            Position = new Vector2(400, 450);
        }

        public void TakeDamage()
        {
            if (!IsVulnerable && Health > 0)
            {
                Health--;
                IsVulnerable = true;

                // five seconds of invulnerability
                invulnderabilityTimer = 5f;
                Respawn();
            }
        }

    }
}
