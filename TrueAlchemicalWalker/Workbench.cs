using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using TrueAlchemicalWalker.Items;
using Microsoft.Xna.Framework.Input;

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
        public Workbench(Background background, SpriteBatch spriteBatch, List<Obstacle> obstacles)
        {
            this.background = background;
            this.spriteBatch = spriteBatch;
            this.obstacles = obstacles;
            random = new Random();
        }

        public void GenerateRandomPosition()
        {
            int maxX = background.Texture.Width - workbenchTexture.Width;
            int maxY = background.Texture.Height - workbenchTexture.Height;
            int x = random.Next(0, maxX + 1);
            int y = random.Next(0, maxY + 1);
            Position = new Vector2(x, y);
        }
        
        public void CraftNewItem (Player player, MouseState mouseState, GameSetting setting, List<Obstacle> obstacles)
        {
            arrows = new Arrows(player);
            var currentNumber = GetNumberOfItem(mouseState, arrows);
            if (currentNumber != -1)
            {
                if (player.dictionaryOfAllPlants[obstacles[currentNumber].Name] >= setting.GetActiveCraft()[currentNumber] 
                    && player.dictionaryOfAllNewPlants[obstacles[currentNumber].Name] > 0)
                {
                    player.dictionaryOfAllPlants[obstacles[currentNumber].Name] -= setting.GetActiveCraft()[currentNumber];
                    player.dictionaryOfAllNewPlants[obstacles[currentNumber].Name] -= 1;
                }
            }
        }

        public int GetNumberOfItem(MouseState mouseState, Arrows arrows)
        {
            for (var i = 0; i < arrows.ListOfArrowsPosition().Count; i++)
                if (arrows.IsMouseInsideArrow(mouseState, i)) return i;
            return -1;
        }

        public void Draw(Player player, ContentManager content)
        {
            numberRenderer = new NumberRenderer(content);
            arrows = new Arrows(player);
            spriteBatch.Draw(Texture, Position, Color.White);
            for (var i = 0; i < ListOfNumberPosition().Count; i++)
            {
                numberRenderer.DrawNumber(spriteBatch, player.dictionaryOfAllPlants[obstacles[i].Name], Position + ListOfNumberPosition()[i]);
            }
            for (var i = 0; i < ListOfNewNumberPosition().Count; i++)
            {
                numberRenderer.DrawNumber(spriteBatch, player.dictionaryOfAllNewPlants[obstacles[i].Name], Position + ListOfNumberPosition()[i]);
            }

        }
    }
}
