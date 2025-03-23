using Microsoft.Xna.Framework;
using The_Gnack_Knight.Classes.Abstract;

namespace The_Gnack_Knight.Classes.Interface
{
    public interface IMovementPattern
    {
        void Move(Entity entity, GameTime gameTime); //gametime will help with other movement pattern types beyond linear
    }
}
