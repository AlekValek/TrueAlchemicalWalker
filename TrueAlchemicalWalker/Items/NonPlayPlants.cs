using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace TrueAlchemicalWalker.Items
{
    public class NonPlayPlants
    {
        public Vector2 Position { get; set; }
        public List<Vector2> listOfNonPlayPlantsPositions;
        private Texture2D _nonPlayPLantsTexture;
        public Texture2D Texture
        {
            get { return _nonPlayPLantsTexture; }
            set { _nonPlayPLantsTexture = value; }
        }

        public void GenerateRandomPositions(GameSetting gameSetting, Background background)
        {
            listOfNonPlayPlantsPositions = new List<Vector2>();
            Random random = new Random();
            for (int i = 0; i < gameSetting.countOfObstacle; i++)
            {
                int x = random.Next(0, background.Texture.Width - _nonPlayPLantsTexture.Width);
                int y = random.Next(0, background.Texture.Height - _nonPlayPLantsTexture.Height);
                listOfNonPlayPlantsPositions.Add(new Vector2(x, y));
            }
        }
    }
}
