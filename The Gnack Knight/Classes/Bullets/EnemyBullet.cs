using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using The_Gnack_Knight.Classes.MovementPatterns;

namespace The_Gnack_Knight.Classes.Bullets
{
    // class for bullets fired by an enemy
    public class EnemyBullet: Bullet {

        // constructor for creating an enemy bulllet
        public  EnemyBullet(Texture2D texture, Vector2 position, bool IsEnemyBullet, Vector2 velocity)
        : base(texture, position, velocity, speed: 100, damage: 4, true, new WaveMovement()) {}

        // bullet is deactivated upon collision
        public override void OnCollision() {
            IsActive = false;
        }
    }
}