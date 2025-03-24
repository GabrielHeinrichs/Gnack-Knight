using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Gnack_Knight.Classes.GameState
{
    public abstract class GameState
    {
        protected GameStateManager _stateManager;
        protected ContentManager _content;

        protected TextureLoader textures; // Handles loading all textures in the game
        protected GraphicsDeviceManager graphics;
        protected SpriteBatch spriteBatch;

        public GameState(GameStateManager stateManager, ContentManager content, SpriteBatch spriteBatch, TextureLoader textures, GraphicsDeviceManager graphics)
        {
            _stateManager = stateManager;
            _content = content;

            this.textures = textures;
            this.graphics = graphics;
            this.spriteBatch = spriteBatch;
        }

        public abstract void LoadContent();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
