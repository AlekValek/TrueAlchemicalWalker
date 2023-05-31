using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TrueAlchemicalWalker.Items
{
    public class Background
    {
        private Texture2D _backgroundTexture;

        public Vector2 Position { get; set; }

        public Texture2D Texture
        {
            get { return _backgroundTexture; }
            set { _backgroundTexture = value; }
        }
    }
}
