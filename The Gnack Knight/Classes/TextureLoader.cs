using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace The_Gnack_Knight.Classes
{
    public class TextureLoader
    {
        private ContentManager content; // Reference to the content manager for loading assets
        private Dictionary<string, Texture2D> textures; // Stores all loaded textures


        public TextureLoader(ContentManager content)
        {
            this.content = content;
            this.textures = new Dictionary<string, Texture2D>();
            LoadAllTextures(); // Load all textures on initialization
        }

        private void LoadAllTextures()
        {
            List<string> textureNames = ["Black-Dot", "Red"];
            foreach(string texture in textureNames)
            {
                textures.Add(texture, content.Load<Texture2D>(texture));
            }
        }

        public Texture2D Get(string textureName)
        {
            return textures[textureName];
        }
    }
}
