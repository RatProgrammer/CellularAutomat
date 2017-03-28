using System;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace CellularAutomaton
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class GameOfLife : Microsoft.Xna.Framework.Game
    {
        public const int Fps = 60;
        public const int Ups = 20;
        public const int CellularSize = 10;
        public const int CellularX = 100;
        public const int CellulatY = 50;
        public SpriteFont SpriteFont;
        public static Texture2D Pixel;
        public Vector2 ScreenSize;
        public static bool IsPaused = true;
        private SpriteBatch _spriteBatch;
        private GraphicsDeviceManager _graphicsDeviceManager;
        private KeyboardState _keyboardState;
        private KeyboardState _lastKeyboardState;
        private Grid _grid;
        public Menu Menu { get; set; }
        public GameOfLife()
        {
            //Menu = new Menu();
            //Application.Run(Menu);
            _graphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            IsFixedTimeStep = true;
            TargetElapsedTime = TimeSpan.FromSeconds(1.0/Fps);
            ScreenSize = new Vector2(CellularX, CellulatY) * CellularSize;
            _graphicsDeviceManager.PreferredBackBufferHeight = (int)ScreenSize.Y;
            _graphicsDeviceManager.PreferredBackBufferWidth = (int) ScreenSize.X;
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
            _grid = new Grid();
            _lastKeyboardState = Keyboard.GetState();
            _keyboardState = _lastKeyboardState;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {         
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteFont = Content.Load<SpriteFont>("Font");
            Pixel = new Texture2D(_spriteBatch.GraphicsDevice,1,1);
            Pixel.SetData(new[] {Color.White});

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            _keyboardState = Keyboard.GetState();

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                this.Exit();
            }

            if (_keyboardState.IsKeyDown(Keys.P) && _lastKeyboardState.IsKeyUp(Keys.P))
            {
                IsPaused = !IsPaused;
            }

            if (_keyboardState.IsKeyDown(Keys.Delete) && _lastKeyboardState.IsKeyUp(Keys.Delete))
            {
               // _grid.Clear();
                Initialize();
            }

            base.Update(gameTime);
            _grid.Update(gameTime);
            _lastKeyboardState = _keyboardState;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            if (IsPaused)
            {
                GraphicsDevice.Clear(Color.Red);
            }
            else
            {
                GraphicsDevice.Clear(Color.Red);
            }
            _spriteBatch.Begin();
            if (IsPaused)
            {
                // string pauseText = @"Please, press P to continue.";
                // _spriteBatch.DrawString(SpriteFont,pauseText, ScreenSize/2, Color.White, 0f, SpriteFont.MeasureString(pauseText)/2, 1f,SpriteEffects.None, 0f);
            }
            _grid.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
