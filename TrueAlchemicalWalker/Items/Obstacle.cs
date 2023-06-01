using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TrueAlchemicalWalker.Items
{
    public class Obstacle
    {
        public List<Vector2> listOfObstaclePositions;
        public Texture2D obstacleTexture;
        public string Name { get; set; }
        public int CountOfObstacle { get; set; }
        public Obstacle (string name, int countOfObstacle)
        {
            Name = name;
            CountOfObstacle = countOfObstacle;
        }
        public Texture2D Texture
        {
            get { return obstacleTexture; }
            set { obstacleTexture = value; }
        }

        public void GenerateRandomPositions(GameSetting settings, Background background, Obstacle obstacle, NonPlayPlants nonPlayPlants)
        {
            listOfObstaclePositions = new List<Vector2>();
            Random random = new Random();
            for (var i = 0; i < obstacle.CountOfObstacle; i++)
            {
                var x = random.Next(0, background.Texture.Width - obstacleTexture.Width);
                var y = random.Next(0, background.Texture.Height - obstacleTexture.Height);
                listOfObstaclePositions.Add(new Vector2(x, y));
            }
            GetNonPlayPlantsPosition(settings, nonPlayPlants);
        }
        public void GetNonPlayPlantsPosition(GameSetting settings, NonPlayPlants nonPlayPlants)
        {
            listOfObstaclePositions = new List<Vector2>();
            Random random = new Random();
            for (var i = 0; i < settings.countOfObstacle / 2; i++)
            {
                var x = (int)nonPlayPlants.listOfNonPlayPlantsPositions[random.Next(0, settings.countOfNonPlayPLants)].X;
                var y = (int)nonPlayPlants.listOfNonPlayPlantsPositions[random.Next(0, settings.countOfNonPlayPLants)].Y;
                listOfObstaclePositions.Add(new Vector2(x, y));
            }
        }
    }
}
