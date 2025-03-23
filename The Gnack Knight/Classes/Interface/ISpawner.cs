using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Gnack_Knight.Classes.Interface
{
    public interface ISpawner
    {
        void Spawn(Vector2 position);
        void Despawn();
        bool IsActive { get; set; }
        Texture2D Texture { get; }
        Vector2 Position { get; set; }
        float SpawnInterval { get; set; }
        float DespawnInterval { get; set; }
        float ElapsedTime { get; set; }
    }
}
