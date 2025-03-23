using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace The_Gnack_Knight.Classes.Enemies
{
    public class EnemyFactory
    {
        public static Texture2D defaultGruntTexture;

        public static Enemy CreateGrunt(Vector2 pos)
        {
            return new GruntEnemy(defaultGruntTexture, pos);
        }

        public static Enemy CreateGrunt(Texture2D texture, Vector2 position)
        {
            //return new GruntEnemy(texture, position, velocity);
            //return new GruntEnemy(texture, 100, 100, 1);
            throw new NotImplementedException();
        }
    }
}
