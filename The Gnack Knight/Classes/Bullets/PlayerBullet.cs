using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using The_Gnack_Knight.Classes.MovementPatterns;

namespace The_Gnack_Knight.Classes.Bullets
{
    // class for bullets fired by the player
    public class PlayerBullet : Bullet 
    {
        // constructor for creating a player bullet
        public PlayerBullet(Texture2D texture, Vector2 position, bool IsEnemyBullet, Vector2 velocity)
            : base(texture, position, velocity, speed: 5, damage: 5, false, new LinearMovement(velocity, 5f)) {}

        // bullet is deactivated upon collision
        public override void OnCollision()
        {
            IsActive = false;
        }
    }
}