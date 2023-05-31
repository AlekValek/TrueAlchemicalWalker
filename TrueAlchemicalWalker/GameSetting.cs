using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Drawing.Printing;
using TrueAlchemicalWalker.Controllers;
using TrueAlchemicalWalker.Items;

namespace TrueAlchemicalWalker
{
    public class GameSetting
    {
        private Player player;
        private Background background;
        public MultipleItemsController multipleItemsController;
        public NonPlayPlants nonPlayPlants;
        public Point WindowSize { get; set; } = new Point(1900, 972);
        public int countOfObstacle { get; set; } = 10;
        public int countOfNonPlayPLants { get; set; } = 20;
        public float speed { get; set; } = 5f;
        public int gameDifficulty { get; set; } = 5;
        public int activeCrafting { get; set; } = 2;
        public List<List<int>> ListOfCraftingCost = new List<List<int>>()
        {
            new List<int>() { 1, 2, 3 },
            new List<int>() { 2, 1, 1 },
            new List<int>() { 3, 1, 2 }
        };
        public List<int> GetActiveCraft()
        {
            return ListOfCraftingCost[activeCrafting];
        }
        public GameSetting(Player player, Background background)
        {
            this.player = player;
            this.background = background;
        }
        public void SetGraphics(GraphicsDeviceManager graphics, GameSetting gameSettings)
        {
            graphics.PreferredBackBufferWidth = gameSettings.WindowSize.X;
            graphics.PreferredBackBufferHeight = gameSettings.WindowSize.Y;
            graphics.ApplyChanges();
        }

        public void LoadContent(GameSetting gameSettings)
        {
            player.Position = new Vector2((gameSettings.WindowSize.X - player.Texture.Width) / 2, (gameSettings.WindowSize.Y - player.Texture.Height) / 2);
            background.Position = Vector2.Zero;
        }
        public void GetDictionaryPlants(Player player, List<Obstacle> obstacles)
        {
            for (int i = 0; i < obstacles.Count; i++)
                player.dictionaryOfAllPlants.Add(obstacles[i].Name, 11);
        }
        public void GetDictionaryNewPlants(Player player, List<Obstacle> obstacles)
        {
            for (int i = 0; i < obstacles.Count; i++)
                player.dictionaryOfAllNewPlants.Add(obstacles[i].Name, gameDifficulty * GetActiveCraft()[i]);
        }
    }
}
