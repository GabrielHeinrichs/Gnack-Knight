using Microsoft.Xna.Framework;
using The_Gnack_Knight.Classes;
using The_Gnack_Knight.Classes.Abstract;
using The_Gnack_Knight.Classes.Interface;

namespace The_Gnack_Knight.Classes.MovementPatterns
{
    public class LinearMovement : IMovementPattern
    {
        private Vector2 direction;
        private float speed;

        public LinearMovement(Vector2 direction, float speed)
        {
            this.direction = direction;
            this.speed = speed;
        }

        public void Move(Entity entity, GameTime gameTime)
        {
            var newPosition = entity.Position;
            newPosition.X += direction.X * speed;
            newPosition.Y += direction.Y * speed;
            entity.Position = newPosition;
        }
    }
}