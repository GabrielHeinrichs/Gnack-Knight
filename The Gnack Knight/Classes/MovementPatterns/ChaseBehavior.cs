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
    public class ChaseBehavior : IEnemyMovementPattern
    {
        private Player player;

        public ChaseBehavior(Player targetPlayer)
        {
            player = targetPlayer;
        }

        public void Move(Enemy enemy)
        {
            //Vector2 direction = (player.position - enemy.position).Normalize();
            //enemy.position += direction * enemy.Speed;

            // Get direction from enemy to player
            ///Vector2 direction = player.position - enemy.position;

            // Normalize the direction to keep speed consistent
            ///if (direction.LengthSquared() > 0)
                ///direction.Normalize();

            // Scale movement by speed and delta time for smooth motion
            //float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            //enemy.position += direction * enemy.Speed * deltaTime;
            ///enemy.position += direction * enemy.Speed;
        }
    }
}
