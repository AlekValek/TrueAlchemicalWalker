using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using TrueAlchemicalWalker.Items;
using Microsoft.Xna.Framework.Input;

namespace TrueAlchemicalWalker
{
    public class Arrows
    {
        public Player player;
        public int Height { get; set; } = 30;
        public int Width { get; set; } = 30;
        public Arrows(Player player)
        {
            this.player = player;
        }
        public List<Vector2> ListOfArrowsPosition()
        {
            List<Vector2> positions = new()
            {
                new Vector2(56, 88),
                new Vector2(148, 118),
                new Vector2(242, 88),
            };
            return positions;
        }
        public bool IsMouseInsideArrow(MouseState mouseState, int numberOfItem)
        {
            return Math.Min(player.Position.Y + player.Texture.Height, ListOfArrowsPosition()[numberOfItem].Y + Height)
                >= Math.Max(player.Position.Y, ListOfArrowsPosition()[numberOfItem].Y)
                && Math.Min(player.Position.X + player.Texture.Width, ListOfArrowsPosition()[numberOfItem].X + Width)
                >= Math.Max(player.Position.X, ListOfArrowsPosition()[numberOfItem].X)

                && mouseState.Y >= ListOfArrowsPosition()[numberOfItem].Y && (mouseState.Y <= ListOfArrowsPosition()[numberOfItem].Y + Height)
                && mouseState.X >= ListOfArrowsPosition()[numberOfItem].X && (mouseState.X <= ListOfArrowsPosition()[numberOfItem].X + Width)
               && (mouseState.RightButton == ButtonState.Pressed);
        }
    }
}
