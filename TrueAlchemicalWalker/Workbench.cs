using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using TrueAlchemicalWalker.Items;
using Microsoft.Xna.Framework.Input;
using System.Linq;

namespace TrueAlchemicalWalker
{
    public class Workbench
    {
        public List<Obstacle> obstacles;
        public Texture2D workbenchTexture;
        public SpriteBatch spriteBatch;
        public NumberRenderer numberRenderer;
        public Random random;
        public Background background;
        public Arrows arrows;
        public bool flag;
        public MouseState previousMouseState;
        public Vector2 Position { get; set; }
        public List<Vector2> ListOfNumberPosition()
        {
            List<Vector2> positions = new()
            {
                new Vector2(22, 45),
                new Vector2(111, 66),
                new Vector2(205, 45),
            };
            return positions;
        }
        public List<Vector2> ListOfNewNumberPosition()
        {
            List<Vector2> positions = new()
            {
                new Vector2(22, 134),
                new Vector2(111, 162),
                new Vector2(205, 134),
            };
            return positions;
        }
        public Texture2D Texture
        {
            get { return workbenchTexture; }
            set { workbenchTexture = value; }
        }
        public Workbench(Background background, SpriteBatch spriteBatch, List<Obstacle> obstacles, Arrows arrows)
        {
            this.background = background;
            this.spriteBatch = spriteBatch;
            this.obstacles = obstacles;
            this.arrows = arrows;
            random = new Random();
            flag = true;
            previousMouseState = new MouseState();
        }

        public void GenerateRandomPosition(Inventory inventory)
        {
            var maxX = background.Texture.Width - workbenchTexture.Width;
            var maxY = background.Texture.Height - workbenchTexture.Height;
            var x = random.Next(0, maxX + 1);
            var y = random.Next(0, maxY + 1);
            while (new Rectangle(x, y, workbenchTexture.Width, workbenchTexture.Height)
                .Intersects(new Rectangle((int)inventory.Position.X, (int)inventory.Position.X, inventory.Texture.Width, inventory.Texture.Width)))
            {
                x = random.Next(0, maxX + 1);
                y = random.Next(0, maxY + 1);
            }
            Position = new Vector2(x, y);
        }
        
        public void CraftNewItem (Player player, MouseState mouseState, GameSetting setting, List<Obstacle> obstacles, Arrows arrows)
        {
            if (previousMouseState != mouseState || flag)
            {
                var currentNumber = GetNumberOfItem(mouseState, arrows, player);
                if (currentNumber != -1)
                {
                    if (player.dictionaryOfAllPlants[obstacles[currentNumber].Name] >= setting.GetActiveCraft()[currentNumber]
                        && player.dictionaryOfAllNewPlants[obstacles[currentNumber].Name] > 0)
                    {
                        player.dictionaryOfAllPlants[obstacles[currentNumber].Name] -= setting.GetActiveCraft()[currentNumber];
                        player.dictionaryOfAllNewPlants[obstacles[currentNumber].Name] -= 1;
                    }
                }
                flag = false;
            }
            previousMouseState = mouseState;
        }

        public int GetNumberOfItem(MouseState mouseState, Arrows arrows, Player player)
        {
            for (var i = 0; i < arrows.ListOfArrowsPosition(Position).Count; i++)
                if (arrows.IsMouseInsideArrow(mouseState, i, player, Position))
                    return i;
            return -1;
        }

        public bool IsAllDone(Player player, List<Obstacle> obstacles)
        {
            var result = 0;
            for (var i = 0; i < obstacles.Count; i++)
                result += player.dictionaryOfAllNewPlants[obstacles[i].Name];
            return (result == 0);
        }

        public void Draw(Player player, ContentManager content, GameSetting setting)
        {
            numberRenderer = new NumberRenderer(content);
            spriteBatch.Draw(Texture, Position, Color.White);
            for (var i = 0; i < setting.GetActiveCraft().Count; i++)
                numberRenderer.DrawNumber(spriteBatch, setting.GetActiveCraft()[i], Position + ListOfNumberPosition()[i]);

            for (var i = 0; i < ListOfNewNumberPosition().Count; i++)
                numberRenderer.DrawNumber(spriteBatch, player.dictionaryOfAllNewPlants[obstacles[i].Name], Position + ListOfNewNumberPosition()[i]);

        }
    }
}
