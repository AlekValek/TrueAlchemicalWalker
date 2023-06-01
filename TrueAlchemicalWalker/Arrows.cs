using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using TrueAlchemicalWalker.Items;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace TrueAlchemicalWalker
{
    public class Arrows
    {
        public int Height { get; set; } = 30;
        public int Width { get; set; } = 30;
        public List<Rectangle> ListOfArrowsPosition(Vector2 workbanchPosition)
        {
            List<Rectangle> positions = new()
            {
                new Rectangle(new Point(56, 88) + new Point ((int)workbanchPosition.X, (int)workbanchPosition.Y), new Point(30, 30)),
                new Rectangle (new Point(148, 118) + new Point ((int)workbanchPosition.X, (int)workbanchPosition.Y), new Point(30, 30)),
                new Rectangle (new Point(242, 88) + new Point ((int)workbanchPosition.X, (int)workbanchPosition.Y), new Point(30, 30)),
            };
            return positions;
        }
        public bool IsMouseInsideArrow(MouseState mouseState, int numberOfItem, Player player, Vector2 workbanchPosition)
        {
            var flag = ListOfArrowsPosition(workbanchPosition)[numberOfItem].Intersects(new Rectangle((int)player.Position.X, (int)player.Position.Y, (int)player.Position.X, (int)player.Position.Y))
                    && ListOfArrowsPosition(workbanchPosition)[numberOfItem].Contains(new Point (mouseState.X, mouseState.Y))
                   && (mouseState.RightButton == ButtonState.Pressed);
            Debug.WriteLine(flag);
            return flag;
        }
    }
}