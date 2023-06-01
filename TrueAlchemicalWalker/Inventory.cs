using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using TrueAlchemicalWalker.Items;

namespace TrueAlchemicalWalker
{
    public class Inventory
    {
        public Dictionary<string, int> dictionaryOfAllPlants;
        public List<Obstacle> obstacles;
        public Texture2D inventoryTexture;
        public SpriteBatch spriteBatch;
        public NumberRenderer numberRenderer;
        private readonly Random random;
        private readonly Background background;
        public List<Vector2> listOfNumberPosition()
        {
            List<Vector2> positions = new()
            {
                new Vector2(44, 151),
                new Vector2(127, 151),
                new Vector2(201, 151),
            };
            return positions;
        }
        public Texture2D Texture
        {
            get { return inventoryTexture; }
            set { inventoryTexture = value; }
        }
        public Vector2 Position { get; set; }

        public Inventory(Background background, SpriteBatch spriteBatch, List<Obstacle>obstacles)
        {
            this.background = background;
            this.spriteBatch = spriteBatch;
            this.obstacles = obstacles;
            random = new Random();
        }

        public void GenerateRandomPosition()
        {
            int maxX = background.Texture.Width - inventoryTexture.Width;
            int maxY = background.Texture.Height - inventoryTexture.Height;
            int x = random.Next(0, maxX + 1);
            int y = random.Next(0, maxY + 1);
            Position = new Vector2(x, y);
        }

        public void Draw(Dictionary<string, int> dictionaryOfAllPlants, ContentManager content) 
        {
            numberRenderer = new NumberRenderer(content);
            spriteBatch.Draw(inventoryTexture, Position, Color.White);
            for (var i = 0; i < listOfNumberPosition().Count; i++ )
                numberRenderer.DrawNumber(spriteBatch, dictionaryOfAllPlants[obstacles[i].Name] /*obstacles[i].CountOfObstacle*/, Position + listOfNumberPosition()[i]);
        }

    }
}
