using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using TrueAlchemicalWalker.Items;

namespace TrueAlchemicalWalker
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public SpriteRenderer spriteRenderer;
        public Player player;
        public Background background;
        public Arrows arrows;

        public List<Obstacle> obstacles;
        public List<Obstacle> newObstacles;
        public Inventory inventory;
        public Workbench workbench;
        public NonPlayPlants nonPlayPlants;
        public GameSetting setting;
        public PlayerController playerController;
        public GetPlantsController getPlantsController;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.Title = "My Game";
        }

        protected override void Initialize()
        {
            player = new Player();
            arrows = new Arrows();
            background = new Background();

            obstacles = new List<Obstacle>
            {
                new Obstacle("mouses", 10),
                new Obstacle("moles", 10),
                new Obstacle("hedgehogs", 10)
            };

            newObstacles = new List<Obstacle>
            {
                new Obstacle("newMouses", 0),
                new Obstacle("newMoles", 0),
                new Obstacle("newHedgehogs", 0)
            };

            setting = new GameSetting(player, background);
            setting.SetGraphics(graphics, setting);
            nonPlayPlants = new NonPlayPlants();
            spriteBatch = new SpriteBatch(GraphicsDevice);
            inventory = new Inventory(background, spriteBatch, obstacles);
            workbench = new Workbench(background, spriteBatch, obstacles, arrows);

            spriteRenderer = new SpriteRenderer(player, background, obstacles, nonPlayPlants, spriteBatch, inventory, workbench, setting);
            playerController = new PlayerController(player, background, obstacles, nonPlayPlants, setting, inventory, workbench);
            getPlantsController = new GetPlantsController(player, background, obstacles, nonPlayPlants, setting);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteRenderer.LoadContent(graphics, Content);
            setting.LoadContent(setting);
            setting.GetDictionaryPlants(player, obstacles);
            setting.GetDictionaryNewPlants(player, obstacles);
            for (int i = 0; i < obstacles.Count; i++)
                obstacles[i].GenerateRandomPositions(setting, background, obstacles[i]);
            nonPlayPlants.GenerateRandomPositions(setting, background);
            inventory.GenerateRandomPosition();
            workbench.GenerateRandomPosition();
        }

        protected override void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();
            var mouseState = Mouse.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || keyboardState.IsKeyDown(Keys.Escape))
                Exit();
            playerController.Update(keyboardState);
            getPlantsController.Update(mouseState);
            workbench.CraftNewItem(player, mouseState, setting, obstacles, arrows);

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            spriteRenderer.Draw(Content);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}