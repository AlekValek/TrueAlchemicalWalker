using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            for (int i = 0; i < obstacles.Count; i++) ChangeCoordForOne(changeX, changeY, obstacles[i].listOfObstaclePositions);
            ChangeCoordForOne(changeX, changeY, nonPlayPlants.listOfNonPlayPlantsPositions);
            ChangeCoordForOne(changeX, changeY, new List<Vector2> { background.Position });
            ChangeCoordForOne(changeX, changeY, new List<Vector2> { inventory.Position });
            ChangeCoordForOne(changeX, changeY, new List<Vector2> { workbench.Position });
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
