using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace CIS580HW3
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Platformer : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteSheet sheet;
        Player player;
        Door door;
        List<Platform> platforms;
        List<Gem> gems;
        AxisList world;

        public Platformer()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            platforms = new List<Platform>();
            gems = new List<Gem>();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
#if VISUAL_DEBUG
            VisualDebugging.LoadContent(Content);
#endif
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Texture2D texture = Content.Load<Texture2D>("spritesheet");
            sheet = new SpriteSheet(texture, 21, 21, 3, 2);

            // Create the player with the corresponding frames from the spritesheet
            IEnumerable<Sprite> playerFrames = from index in Enumerable.Range(19, 30) select sheet[index];
            player = new Player(playerFrames);

            door = new Door(new Vector2(1440, 330), sheet[184]);

            // Create the platforms
            platforms.Add(new Platform(new BoundingRectangle(0, 400, 200, 21), sheet[1]));
            platforms.Add(new Platform(new BoundingRectangle(250, 350, 200, 21), sheet[2]));
            platforms.Add(new Platform(new BoundingRectangle(500, 300, 100, 21), sheet[3]));
            platforms.Add(new Platform(new BoundingRectangle(650, 400, 150, 21), sheet[1]));
            platforms.Add(new Platform(new BoundingRectangle(900, 500, 50, 21), sheet[2]));
            platforms.Add(new Platform(new BoundingRectangle(1000, 450, 100, 21), sheet[3]));
            platforms.Add(new Platform(new BoundingRectangle(1150, 400, 200, 21), sheet[1]));
            platforms.Add(new Platform(new BoundingRectangle(1400, 350, 100, 21), sheet[122]));

            // Add the platforms to the axis list
            world = new AxisList();

            foreach (Platform platform in platforms)
            {
                world.AddGameObject(platform);
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            player.Update(gameTime);

            // Check for platform collisions
            IEnumerable<IBoundable> platformQuery = world.QueryRange(player.Bounds.X, player.Bounds.X + player.Bounds.Width);
            player.CheckForPlatformCollision(platformQuery);

            // Check for gem collisions
            IEnumerable<IBoundable> gemQuery = world.QueryRange(player.Bounds.X, player.Bounds.X + player.Bounds.Width);
            player.CheckForGemCollision(gemQuery);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            Vector2 offset = new Vector2(200, 300) - player.Position;
            Matrix t = Matrix.CreateTranslation(offset.X, offset.Y, 0);

            spriteBatch.Begin(SpriteSortMode.Deferred, transformMatrix: t);

            // Draw the platforms 
            platforms.ForEach(platform =>
            {
                platform.Draw(spriteBatch);
            });

            // Draw the gems
            gems.ForEach(gem =>
            {
                gem.Draw(spriteBatch);
            });

            // Draw the player
            player.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
