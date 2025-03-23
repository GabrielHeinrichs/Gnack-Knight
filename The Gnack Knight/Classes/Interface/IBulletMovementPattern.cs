using Microsoft.Xna.Framework;
using The_Gnack_Knight.Classes.Bullets;

namespace The_Gnack_Knight.Classes.Interface
{
    public interface IBulletMovementPattern
    {
        void Move(Bullet bullet, GameTime gameTime);
    }
}
