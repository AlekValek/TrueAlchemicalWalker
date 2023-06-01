using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using TrueAlchemicalWalker.Items;

namespace TrueAlchemicalWalker.Controllers
{
    public class MultipleItemsController
    {
        private List<Obstacle> obstacles;
        private NonPlayPlants nonPlayPlants;
        private Background background;
        private Inventory inventory;
        private Workbench workbench;

        public MultipleItemsController(List<Obstacle> obstacles, NonPlayPlants nonPlayPlants, 
            Background background, Inventory inventory, Workbench workbench)
        {
            this.obstacles = obstacles;
            this.nonPlayPlants = nonPlayPlants;
            this.background = background;
            this.inventory = inventory;
            this.workbench = workbench;
        }
        public void ChangeCoord(float changeX, float changeY)
        {
            for (int i = 0; i < obstacles.Count; i++) 
                ChangeCoordForOne(changeX, changeY, obstacles[i].listOfObstaclePositions);
            ChangeCoordForOne(changeX, changeY, nonPlayPlants.listOfNonPlayPlantsPositions);
            background.Position = new Vector2(background.Position.X + changeX, background.Position.Y + changeY);
            inventory.Position = new Vector2(inventory.Position.X + changeX, inventory.Position.Y + changeY);
            workbench.Position = new Vector2(workbench.Position.X + changeX, workbench.Position.Y + changeY);
        }

        private static void ChangeCoordForOne(float changeX, float changeY, List<Vector2> listOfItems)
        {
            for (int i = 0; i < listOfItems.Count; i++)
            {
                listOfItems[i] = new Vector2(listOfItems[i].X + changeX, listOfItems[i].Y + changeY);
            }
        }
    }
}
