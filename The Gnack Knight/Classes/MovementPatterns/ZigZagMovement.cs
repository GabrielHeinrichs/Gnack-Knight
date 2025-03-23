using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Gnack_Knight.Classes.Abstract;
using The_Gnack_Knight.Classes.Enemies;
using The_Gnack_Knight.Classes.Interface;

namespace The_Gnack_Knight.Classes.MovementPatterns
{
    public class ZigZagMovement : IEnemyMovementPattern
    {
        // private int direction = 1; // 1 for right, -1 for left

        public void Move(Enemy enemy)
        {
            ///enemy.position += new Vector2(direction * enemy.Speed, enemy.Speed);

            // Reverse direction at screen edges
            ///if (enemy.position.X > 400 || enemy.position.X < 100)
            ///{
                ///direction *= -1;
            ///}
        }
    }
}
