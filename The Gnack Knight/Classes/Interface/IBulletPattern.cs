using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using The_Gnack_Knight.Classes.Bullets;

namespace The_Gnack_Knight.Classes.Interface
{
    // determines how bullets are fired, independent of movement
    public interface IBulletPattern {
        void Fire(Vector2 position, List<Bullet> bullets, Texture2D texture);
    }
}