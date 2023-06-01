using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TrueAlchemicalWalker
{
    public class WinWinWin
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D texture;
        float radians = (float)Math.PI - (float)Math.PI * 30 / 180;
        float rotate = 0f;
        float speed = 4f;
        public void RicochetMechanic(GameSetting setting, Vector2 position)
        {
            position.X += speed * (float)Math.Cos(radians);
            position.Y += speed * (float)Math.Sin(radians);
            rotate += 0.25f;
            if ((position.X > setting.WindowSize.X) || (position.X < 0))
                radians *= -1;

            if ((position.Y > setting.WindowSize.Y) || (position.Y < 0))
                radians = -1;
        }
        public void Draw (SpriteBatch spriteBatchб, Vector2 position)
        {
            spriteBatch.Draw(texture, position, null, Color.White, rotate,
            new Vector2(texture.Width / 2f, texture.Height / 3.1f * 1f),
            0.8f,
            SpriteEffects.FlipVertically,
            0);
        }

    }
}
