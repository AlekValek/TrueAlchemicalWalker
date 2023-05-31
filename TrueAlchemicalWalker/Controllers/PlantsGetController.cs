using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using TrueAlchemicalWalker.Controllers;
using TrueAlchemicalWalker.Items;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace TrueAlchemicalWalker
{
    public class PlantsGetController
    {
        private Player player;
        private Background background;
        private List<Obstacle> obstacles;
        private GameSetting settings;
        public MultipleItemsController multipleItemsController;
        public NonPlayPlants nonPlayPlants;

        public PlantsGetController(Player player, Background background, List<Obstacle> obstacles, NonPlayPlants nonPlayPlants, GameSetting settings)
        {
            this.player = player;
            this.background = background;
            this.obstacles = obstacles;
            this.nonPlayPlants = nonPlayPlants;
            this.settings = settings;
        }

        public void Update(MouseState mouseState)
        {
            for (int i = 0; i < obstacles.Count; i++)
                GetItems(mouseState, obstacles[i]);
        }

        private void GetItems(MouseState mouseState, Obstacle obstacle)
        {
            for (int i = obstacle.listOfObstaclePositions.Count - 1; i >= 0; i--)
            {
                if (IsPressed(mouseState, obstacle.Texture, obstacle.listOfObstaclePositions[i]))
                {
                    obstacle.listOfObstaclePositions.RemoveAt(i);
                    player.dictionaryOfAllPlants[obstacle.Name]++;
                }
            }
        }
        public bool IsPressed(MouseState mouseState, Texture2D ItemTexture, Vector2 itemPosition)
        {
            return Math.Min(player.Position.Y + player.Texture.Height, itemPosition.Y + ItemTexture.Height)
                >= Math.Max(player.Position.Y, itemPosition.Y)
                && Math.Min(player.Position.X + player.Texture.Width, itemPosition.X + ItemTexture.Width)
                >= Math.Max(player.Position.X, itemPosition.X)

                   && (mouseState.Y >= itemPosition.Y && mouseState.Y <= (itemPosition.Y + ItemTexture.Height))
                   && (mouseState.X >= itemPosition.X && mouseState.X <= (itemPosition.X + ItemTexture.Width))
                   && (mouseState.RightButton == ButtonState.Pressed);
        }
    }
}
