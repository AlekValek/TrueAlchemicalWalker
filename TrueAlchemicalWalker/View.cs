using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using TrueAlchemicalWalker.Items;

namespace TrueAlchemicalWalker
{
    public class SpriteRenderer
    {
        private Player player;
        private Background background;
        private List<Obstacle> obstacles;
        private Inventory inventory;
        private Workbench workbench;
        private NonPlayPlants trees;
        public SpriteBatch spriteBatch;
        private NonPlayPlants nonPlayPlants;

        public SpriteRenderer(Player player, Background background, List<Obstacle> obstacles, NonPlayPlants trees, SpriteBatch spriteBatch,
            Inventory inventory, Workbench workbench)
        {
            this.player = player;
            this.background = background;
            this.obstacles = obstacles;
            this.trees = trees;
            this.spriteBatch = spriteBatch;
            this.inventory = inventory;
            this.workbench = workbench;
        }

        public void Draw(ContentManager content)
        {
            spriteBatch.Draw(background.Texture, background.Position, Color.White);
            spriteBatch.Draw(player.Texture, player.Position, Color.White);
            inventory.Draw(player.dictionaryOfAllPlants, content);
            workbench.Draw(player, content);
            for(int i = 0; i < obstacles.Count; i++)
                DrawListOfItems(obstacles[i].Texture, obstacles[i].listOfObstaclePositions);
            DrawListOfItems(trees.Texture, trees.listOfNonPlayPlantsPositions);
        }

        private void DrawListOfItems(Texture2D itemsTexture, List<Vector2> listOfItemsPositions)
        {
            foreach (var itemsPosition in listOfItemsPositions)
                spriteBatch.Draw(itemsTexture, itemsPosition, Color.White);
        }

        public void LoadContent(GraphicsDeviceManager graphicsDevice, ContentManager content)
        {
            player.Texture = content.Load<Texture2D>("крош-без-фона (1) (1) (1)");
            background.Texture = content.Load<Texture2D>("фон (1)");
            obstacles[0].Texture = content.Load<Texture2D>("мышь без фона мини");
            obstacles[1].Texture = content.Load<Texture2D>("крот без фона mini");
            obstacles[2].Texture = content.Load<Texture2D>("еж без фона 1");
            trees.Texture = content.Load<Texture2D>("дерево без фона мини");
            inventory.Texture = content.Load<Texture2D>("доска крафта");
            inventory.Texture = content.Load<Texture2D>("доска с инвентарём");
        }
    }
}

