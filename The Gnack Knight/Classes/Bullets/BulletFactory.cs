using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace The_Gnack_Knight.Classes.Bullets
{
    // Factory pattern design where we create different types of bullets
    public class BulletFactory {
        public static Bullet CreateBullet(string type, Texture2D texture, Vector2 position, Vector2 velocity) {
            switch(type) {
                case "PlayerBullet":
                    return new PlayerBullet(texture, position, false, velocity);
                case "EnemyBullet":
                    return new EnemyBullet(texture, position, true, velocity);
                default:
                    throw new System.ArgumentException("Invalid bullet type");
            }
        }
    }
}