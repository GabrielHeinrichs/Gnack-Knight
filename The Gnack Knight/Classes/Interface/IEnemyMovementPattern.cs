using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Gnack_Knight.Classes.Abstract;
using The_Gnack_Knight.Classes.Enemies;

namespace The_Gnack_Knight.Classes.Interface
{
    public interface IEnemyMovementPattern
    {
        public void Move(Enemy enemy);
    }
}
