using Microsoft.Xna.Framework.Input;
using System.Numerics;

namespace The_Gnack_Knight.Classes
{
    public class InputHandler
    {
        private Player player;

        public InputHandler(Player player)
        {
            this.player = player;
        }

        public void Execute()
        {
            KeyboardState keyboard = Keyboard.GetState();

            MakePlayerMove(keyboard);
            MakePlayerAim(keyboard);
            MakePlayerShoot(keyboard);
        }

        private void MakePlayerMove(KeyboardState keyboard)
        {
            // Determine if running
            int distance = keyboard.IsKeyDown(Keys.LeftShift) ? this.player.runSpeed : this.player.walkSpeed;

            // Make a displacement vector
            Vector2 discplacement = new Vector2(0f, 0f);
            if (keyboard.IsKeyDown(Keys.W)) discplacement.Y -= distance;
            if (keyboard.IsKeyDown(Keys.S)) discplacement.Y += distance;
            if (keyboard.IsKeyDown(Keys.A)) discplacement.X -= distance;
            if (keyboard.IsKeyDown(Keys.D)) discplacement.X += distance;

            // Move the player by the displacement
            player.Move(discplacement);
        }

        private void MakePlayerAim(KeyboardState keyboard)
        {
            float up = 0f;
            float down = 0f;
            float left = 0f;
            float right = 0f;

            int i = 0; // Divides the degrees by the amount of keys being pressed.
            if (keyboard.IsKeyDown(Keys.Up)) { up = 270f; i++; }
            if (keyboard.IsKeyDown(Keys.Down)) { down = 90f; i++; }
            if (keyboard.IsKeyDown(Keys.Left)) { left = 180f; i++; }
            if (keyboard.IsKeyDown(Keys.Right)) { right = 360f; i++; }

            if (i != 0) // If there is input
            {
                // Calculate the direction of aim.
                float AimingDirection = up + down + left + right;
                if (right != 0f && down != 0f) { AimingDirection -= 360f; }; // Handles an exception to the calculations.

                AimingDirection /= i;

                player.SetAim(AimingDirection);
            }
        }

        private void MakePlayerShoot(KeyboardState keyboard)
        {
            // Ensure that two opposing keys are not being pressed to shoot.
            if (!(keyboard.IsKeyDown(Keys.Up) && keyboard.IsKeyDown(Keys.Down)))
            {
                if (!(keyboard.IsKeyDown(Keys.Left) && keyboard.IsKeyDown(Keys.Right)))
                {
                    // Ensures that user wants to shoot.
                    if (keyboard.IsKeyDown(Keys.Up) || keyboard.IsKeyDown(Keys.Down) || keyboard.IsKeyDown(Keys.Left) || keyboard.IsKeyDown(Keys.Right))
                    {
                        player.Shoot();
                    }
                }
            }
        }
    }
}
