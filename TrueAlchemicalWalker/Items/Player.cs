using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace TrueAlchemicalWalker.Items
{
    public class Player
    {
        private Texture2D spriteTexture;
        public Vector2 Position { get; set; }
        public float Speed { get; set; } = 5f;
        public Dictionary<string, int> dictionaryOfAllPlants;
        public Dictionary<string, int> dictionaryOfAllNewPlants;

        public Texture2D Texture
        {
            get { return spriteTexture; }
            set { spriteTexture = value; }
        }
        public Player()
        {
            dictionaryOfAllPlants = new Dictionary<string, int>();
            dictionaryOfAllNewPlants = new Dictionary<string, int>();
        }
        //public void GenerateRandomPositions(GameSetting settings, Background background)
        //{
        //    Random random = new Random();
        //    var x = random.Next(0, background.Texture.Width - Texture.Width);
        //    var y = random.Next(0, background.Texture.Height - Texture.Height);
        //    Position = new Vector2(x, y);
        //}
    }
}

