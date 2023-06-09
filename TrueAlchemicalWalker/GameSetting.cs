﻿using Microsoft.Xna.Framework;
using System;
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
        public int countOfNonPlayPLants { get; set; } = 10;
        public float speed { get; set; } = 5f;
        public int gameDifficulty { get; set; } = 2;
        public int activeCrafting { get; set; } = new Random().Next(0, 4);

        public List<List<int>> ListOfCraftingCost = new List<List<int>>()
        {
            new List<int>() { 1, 2, 3 },
            new List<int>() { 1, 1, 1 },
            new List<int>() { 3, 1, 2 },
            GenerateRandomCraftingCost()
        };

        public static List<int> GenerateRandomCraftingCost()
        {
            var random = new Random();
            var randomCraftingCost = new List<int>();

            for (int i = 0; i < 3; i++)
            {
                int randomValue = random.Next(0, 4);
                randomCraftingCost.Add(randomValue);
            }
            return randomCraftingCost;
        }
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
            //var random = new Random();

            //var maxX = gameSettings.WindowSize.X - player.Texture.Width;
            //var maxY = gameSettings.WindowSize.Y - player.Texture.Height;
            //var x = random.Next(0, maxX + 1);
            //var y = random.Next(0, maxY + 1);
            //player.Position = new Vector2(x, y);
            //player.Position = Vector2.Zero;
            background.Position = Vector2.Zero;
        }

        public void GetCountOfObstacle(List<Obstacle> obstacles)
        {
            for (int i = 0; i < obstacles.Count; i++)
                obstacles[i].CountOfObstacle = GetActiveCraft()[i] * gameDifficulty;
        }
        public void GetDictionaryPlants(Player player, List<Obstacle> obstacles)
        {
            for (int i = 0; i < obstacles.Count; i++)
                player.dictionaryOfAllPlants.Add(obstacles[i].Name, 0);
        }
        public void GetDictionaryNewPlants(Player player, List<Obstacle> obstacles)
        {
            for (int i = 0; i < obstacles.Count; i++)
                player.dictionaryOfAllNewPlants.Add(obstacles[i].Name, gameDifficulty * GetActiveCraft()[i]);
        }
    }
}
