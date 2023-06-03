using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TrueAlchemicalWalker.Items;

namespace TrueAlchemicalWalker.Tests
{
    [TestFixture]
    public class WorkbenchTests
    {
        public GraphicsDevice graphics;
        private Workbench workbench;
        private Background background;
        private SpriteBatch spriteBatch;
        private List<Obstacle> obstacles;
        private Arrows arrows;
        private Player player;
        private MouseState mouseState;
        private Inventory inventory;

        [SetUp]
        public void SetUp()
        {
            player = new Player();
            background = new Background();
            arrows = new Arrows();

            var graphicsDeviceMock = new Mock<GraphicsDevice>(MockBehavior.Default);
            var graphicsDeviceServiceMock = new Mock<IGraphicsDeviceService>();
            graphicsDeviceServiceMock.SetupGet(s => s.GraphicsDevice).Returns(graphicsDeviceMock.Object);


            spriteBatch = new SpriteBatch(graphics);
            obstacles = new List<Obstacle>
            {
                new Obstacle("hedgehogs", 10),
                new Obstacle("mouses", 6),
                new Obstacle("moles", 2)
            };
            workbench = new Workbench(background, spriteBatch, obstacles, arrows);
            player.dictionaryOfAllPlants = new Dictionary<string, int>
            {
                { "hedgehogs", 5 },
                { "mouses", 3 },
                { "moles", 1 }
            };
        }

        [Test]
        public void TestCraftNewItem_PlantExistsAndEnoughResources()
        {
            // Arrange
            player.dictionaryOfAllPlants["hedgehogs"] = 10;
            player.dictionaryOfAllNewPlants["hedgehogs"] = 2;
            player.dictionaryOfAllNewPlants["mouses"] = 5;
            player.dictionaryOfAllNewPlants["moles"] = 0;
            mouseState = new MouseState();

            // Act
            workbench.CraftNewItem(player, mouseState, new GameSetting(player, background), obstacles, arrows);

            // Assert
            Assert.AreEqual(9, player.dictionaryOfAllPlants["hedgehogs"]);
            Assert.AreEqual(1, player.dictionaryOfAllNewPlants["hedgehogs"]);
            Assert.AreEqual(5, player.dictionaryOfAllNewPlants["mouses"]);
            Assert.AreEqual(0, player.dictionaryOfAllNewPlants["moles"]);
        }

        [Test]
        public void TestCraftNewItem_PlantExistsButNotEnoughResources()
        {
            // Arrange
            player.dictionaryOfAllPlants["hedgehogs"] = 3;
            player.dictionaryOfAllNewPlants["hedgehogs"] = 2;
            player.dictionaryOfAllNewPlants["mouses"] = 5;
            player.dictionaryOfAllNewPlants["moles"] = 0;
            mouseState = new MouseState();

            // Act
            workbench.CraftNewItem(player, mouseState, new GameSetting(player, background), obstacles, arrows);

            // Assert
            Assert.AreEqual(3, player.dictionaryOfAllPlants["hedgehogs"]);
            Assert.AreEqual(2, player.dictionaryOfAllNewPlants["hedgehogs"]);
            Assert.AreEqual(5, player.dictionaryOfAllNewPlants["mouses"]);
            Assert.AreEqual(0, player.dictionaryOfAllNewPlants["moles"]);
        }

        [Test]
        public void TestCraftNewItem_PlantDoesNotExist()
        {
            // Arrange
            player.dictionaryOfAllPlants["hedgehogs"] = 10;
            player.dictionaryOfAllNewPlants["hedgehogs"] = 2;
            player.dictionaryOfAllNewPlants["mouses"] = 5;
            player.dictionaryOfAllNewPlants["moles"] = 0;
            mouseState = new MouseState();

            // Act
            workbench.CraftNewItem(player, mouseState, new GameSetting(player, background), obstacles, arrows);

            // Assert
            Assert.AreEqual(10, player.dictionaryOfAllPlants["hedgehogs"]);
            Assert.AreEqual(2, player.dictionaryOfAllNewPlants["hedgehogs"]);
            Assert.AreEqual(5, player.dictionaryOfAllNewPlants["mouses"]);
            Assert.AreEqual(0, player.dictionaryOfAllNewPlants["moles"]);
        }

        [Test]
        public void TestIsAllDone_AllItemsDone_ReturnsTrue()
        {
            // Arrange
            player.dictionaryOfAllNewPlants["hedgehogs"] = 0;
            player.dictionaryOfAllNewPlants["mouses"] = 0;
            player.dictionaryOfAllNewPlants["moles"] = 0;

            // Act
            var result = workbench.IsAllDone(player, obstacles);

            // Assert
            Assert.True(result);
        }
    }
}