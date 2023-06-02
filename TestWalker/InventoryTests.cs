using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using NUnit.Framework;
using System.Collections.Generic;
using TrueAlchemicalWalker;

namespace TrueAlchemicalWalker.Tests
{
    [TestFixture]
    public class InventoryTests
    {
        private Inventory inventory;
        private Dictionary<string, int> dictionaryOfAllPlants;
        private List<Obstacle> obstacles;

        [SetUp]
        public void SetUp()
        {
            var background = new Background();
            var spriteBatch = new SpriteBatch(GraphicsDevice);
            obstacles = new List<Obstacle>
            {
                new Obstacle("hedgehogs", 10),
                new Obstacle("mouses", 6),
                new Obstacle("moles", 2)
            };
            inventory = new Inventory(background, spriteBatch, obstacles);
            dictionaryOfAllPlants = new Dictionary<string, int>
            {
                { "hedgehogs", 5 },
                { "mouses", 3 },
                { "moles", 1 }
            };
        }

        [Test]
        public void TestGenerateRandomPosition()
        {
            // Arrange
            var maxX = inventory.background.Texture.Width - inventory.Texture.Width;
            var maxY = inventory.background.Texture.Height - inventory.Texture.Height;

            // Act
            inventory.GenerateRandomPosition();

            // Assert
            Assert.GreaterOrEqual(inventory.Position.X, 0);
            Assert.LessOrEqual(inventory.Position.X, maxX);
            Assert.GreaterOrEqual(inventory.Position.Y, 0);
            Assert.LessOrEqual(inventory.Position.Y, maxY);
        }
    }
}
