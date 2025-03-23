using System;
using Microsoft.Xna.Framework;
using The_Gnack_Knight.Classes.Abstract;
using The_Gnack_Knight.Classes.Interface;

namespace The_Gnack_Knight.Classes.MovementPatterns;

/// <summary>
/// Makes the bullet waver as it moves.
/// </summary>
public class WaveMovement : IMovementPattern
{
    private float waveAmp = 5f;  // Amplitude
    private float waveFreq = 0.1f; // Frequency
    private float speed = 10f;  // Base movement speed

    public void Move(Entity entity, GameTime gameTime)
    {
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

        // Time-dependent oscillation
        float waveOffset = (float)Math.Sin(entity.Position.Y * waveFreq) * waveAmp;

        // Update position
        entity.Position += new Vector2(waveOffset * deltaTime, speed * deltaTime);
    }
}