using Microsoft.VisualBasic.Devices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using TrueAlchemicalWalker.Controllers;
using TrueAlchemicalWalker.Items;

namespace TrueAlchemicalWalker
{
    public class PlayerController
    {
        private Player player;
        private List<Obstacle> obstacles;
        private Background background;
        private Inventory inventory;
        private Workbench workbench;
        private GameSetting settings;
        public MultipleItemsController multipleItemsController;
        public NonPlayPlants nonPlayPlants;

        public PlayerController(Player player, Background background, List<Obstacle> obstacles, 
            NonPlayPlants nonPlayPlants, GameSetting settings, Inventory inventory, Workbench workbench)
        {
            this.player = player;
            this.obstacles = obstacles;
            this.nonPlayPlants = nonPlayPlants;
            this.settings = settings;
            this.background = background;
            this.inventory = inventory;
            this.workbench = workbench;
        }
        public void Update(KeyboardState keyboardState)
        {
            multipleItemsController = new MultipleItemsController(obstacles, nonPlayPlants, background, inventory, workbench);

            if (keyboardState.IsKeyDown(Keys.Left) && (player.Position.X > 0))
            {
                if (background.Position.X == 0
                    || (settings.WindowSize.X - background.Position.X < background.Texture.Width && player.Position.X + player.Texture.Width / 2 > settings.WindowSize.X / 2))
                {
                    player.Position = new Vector2(player.Position.X - settings.speed, player.Position.Y);
                }
                else
                {
                    multipleItemsController.ChangeCoord(settings.speed, 0);
                }
            }
            else if (keyboardState.IsKeyDown(Keys.Right) && player.Position.X + player.Texture.Width < settings.WindowSize.X)
            {
                if ((background.Position.X == 0 && player.Position.X + player.Texture.Width / 2 < settings.WindowSize.X / 2)
                    || (settings.WindowSize.X - background.Position.X > background.Texture.Width))
                {
                    player.Position = new Vector2(player.Position.X + settings.speed, player.Position.Y);
                }
                else
                {
                    multipleItemsController.ChangeCoord(-settings.speed, 0);
                }
            }

            if (keyboardState.IsKeyDown(Keys.Up) && (player.Position.Y > 0))
            {
                if (background.Position.Y == 0
                    || (settings.WindowSize.Y - background.Position.Y < background.Texture.Height && player.Position.Y + player.Texture.Height / 2 > settings.WindowSize.Y / 2))
                {
                    player.Position = new Vector2(player.Position.X, player.Position.Y - settings.speed);
                }
                else
                {
                    multipleItemsController.ChangeCoord(0, settings.speed);
                }
            }
            else if (keyboardState.IsKeyDown(Keys.Down) && player.Position.Y + player.Texture.Height < settings.WindowSize.Y)
            {
                if ((background.Position.Y == 0 && player.Position.Y + player.Texture.Height / 2 < settings.WindowSize.Y / 2)
                    || (settings.WindowSize.Y - background.Position.Y > background.Texture.Height))
                {
                    player.Position = new Vector2(player.Position.X, player.Position.Y + settings.speed);
                }
                else
                {
                    multipleItemsController.ChangeCoord(0, -settings.speed);
                }
            }
        }

    }
}