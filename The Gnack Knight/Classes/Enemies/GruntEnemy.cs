using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace The_Gnack_Knight.Classes.Enemies
{
    public class GruntEnemy : Enemy
    {
        public GruntEnemy(Texture2D texture, int health, int damage) //: base(texture, health, damage)
        {
            //this.MovementPattern = new LinearMovement();
        }

        public GruntEnemy(Texture2D texture, int health, int damage, float speed) //: base(texture, health, damage, speed)
        {
            //this.MovementPattern = new LinearMovement();
        }

        public GruntEnemy(Texture2D texture, Vector2 pos) //: base(texture, 25, 1)
        {
            //this.MovementPattern = new LinearMovement();

            //this.position = pos;
            //this.Speed = 1;

        }

    }
}
