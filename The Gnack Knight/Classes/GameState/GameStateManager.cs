using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace The_Gnack_Knight.Classes.GameState
{
    public class GameStateManager
    {
        private GameState currentState;

        public void ChangeState(GameState newState)
        {
            currentState = newState;
            currentState.LoadContent();
        }

        public void Update(GameTime gameTime)
        {
            currentState?.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState?.Draw(spriteBatch);
        }

        public void ExitGame()
        {
            System.Environment.Exit(0);
        }
    }
}