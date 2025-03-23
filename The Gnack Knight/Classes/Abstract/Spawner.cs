using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Gnack_Knight.Classes.Interface;
using The_Gnack_Knight.Classes.Enemies;

namespace The_Gnack_Knight.Classes.Abstract
{
    public class Spawner
    {

        private EnemyManager enemyManager; // Reference to the enemy manager to handle spawned enemies
        private List<WaveData> waves; // List of all waves to be processed
        private int currentWaveIndex; // Tracks the current wave
        private float elapsedTime; // Time tracker for spawning enemies

        // Constructor initializes the spawner with the enemy manager
        public Spawner(EnemyManager enemyManager)
        {
            this.enemyManager = enemyManager;
            this.waves = GetDefaultWaveData(); // Placeholder until JSON is added
            this.currentWaveIndex = 0;
            this.elapsedTime = 0f;
        }

        // Defines the default set of waves used for testing before JSON integration (Only using BasicEnemy for now)
        private List<WaveData> GetDefaultWaveData()
        {
            return new List<WaveData>
            {
                new WaveData
                {
                    WaveNumber = 1,
                    Delay = 0, // No delay before the first wave starts
                    Spawns = new List<SpawnData>
                    {
                        new SpawnData { X = 100, Y = 200, Time = 5, Type = "BasicEnemy" },
                        new SpawnData { X = 300, Y = 150, Time = 10, Type = "BasicEnemy" }
                    }
                },
                new WaveData
                {
                    WaveNumber = 2,
                    Delay = 15, // Waits 15 seconds before starting this wave
                    Spawns = new List<SpawnData>
                    {
                        new SpawnData { X = 500, Y = 100, Time = 20, Type = "BasicEnemy" }
                    }
                }
            };
        }

        // Updates the wave system and spawns enemies based on elapsed time
        public void Update(float deltaTime)
        {
            // Increment elapsed time
            elapsedTime += deltaTime;

            if (currentWaveIndex < waves.Count) // Ensure we still have waves left
            {
                WaveData currentWave = waves[currentWaveIndex];
                if (elapsedTime >= currentWave.Delay) // Start wave if delay time has passed
                {
                    // Iterate through the spawn list in reverse to allow safe removal
                    for (int i = currentWave.Spawns.Count - 1; i >= 0; i--)
                    {
                        if (elapsedTime >= currentWave.Spawns[i].Time) // Check if it's time to spawn
                        {
                            enemyManager.SpawnEnemy(currentWave.Spawns[i].X, currentWave.Spawns[i].Y, currentWave.Spawns[i].Type);
                            currentWave.Spawns.RemoveAt(i); // Remove the enemy from the spawn queue
                        }
                    }

                    // If all enemies in the wave are spawned, move to the next wave
                    if (currentWave.Spawns.Count == 0)
                    {
                        currentWaveIndex++;
                        elapsedTime = 0f; // Reset timer for next wave delay
                    }
                }
            }
        }
    }

    // Represents a wave of enemies
    public class WaveData
    {
        public int WaveNumber { get; set; } // Wave identifier
        public float Delay { get; set; } // Time delay before this wave starts
        public List<SpawnData> Spawns { get; set; } // List of enemy spawns for this wave
    }

    // Represents a single enemy spawn event
    public class SpawnData
    {
        public float X { get; set; } // X-coordinate for enemy spawn location
        public float Y { get; set; } // Y-coordinate for enemy spawn location
        public float Time { get; set; } // Time at which enemy should spawn
        public string Type { get; set; } // Type of enemy to spawn
    }
}