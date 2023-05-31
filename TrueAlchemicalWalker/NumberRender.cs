using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TrueAlchemicalWalker
{
    public class NumberRenderer
    {
        private Texture2D[] numberTextures;

        public NumberRenderer(ContentManager content)
        {
            numberTextures = new Texture2D[10];

            for (int i = 0; i < 10; i++)
            {
                numberTextures[i] = content.Load<Texture2D>($"digit{i}");
            }
        }

        public void DrawNumber(SpriteBatch spriteBatch, int number, Vector2 position)
        {
            var numberString = number.ToString();

            for (int i = 0; i < numberString.Length; i++)
            {
                var digit = int.Parse(numberString[i].ToString());

                if (digit >= 0 && digit <= 9)
                {
                    var texture = numberTextures[digit];
                    var digitPosition = new Vector2(position.X + i * texture.Width, position.Y);
                    spriteBatch.Draw(texture, digitPosition, Color.White);
                }
            }
        }
    }
}
