using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using System.Collections.Generic;
using TextureAtlas;

namespace Sprint0
{
    public class Game1 : Game
    {
        private List<ISprite> SpriteList; // initialize list of sprites

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //initialize sprites
        private Texture2D shyGuy;
        private Texture2D shySpin;
        private Texture2D shyGuyGhost;
        private Texture2D shyWalk;

        private MouseTool mouse; //initialize a new MouseTool
        private KeyboardTool keypad; //initialize a new Keypad
        private Logic gameLogic; //initialize a new logic object
        private ScreenWriter writer;  //initialize a new ScreenWriter

        //initialize sprite font for later
        SpriteFont font;

        /*
         * Here we will be setting up some of the settings for the game
         */
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //can you see the mouse when you are in game? Yes
            IsMouseVisible = true;
        }

        /*
         * This section runs as the game boots up. Here we will set up the game and apply settings
         */
        protected override void Initialize()
        {
            //Initialize all of our controllers
            keypad = new KeyboardTool();
            mouse = new MouseTool();   

            //Initialize our screen writer
            writer = new ScreenWriter();

            //Initialize the game logic object
            gameLogic = new Logic();

            base.Initialize();

        }

        /*
         * Where images and sounds will be loaded into the game
         */
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //load in sprites
            shyGuy = Content.Load<Texture2D>("ShyGuyStill");
            shySpin = Content.Load<Texture2D>("ShyGuySpinPNG");
            shyGuyGhost = Content.Load<Texture2D>("ShyGuyGhost");
            shyWalk = Content.Load<Texture2D>("ShyGuyWalkProper");

            //add sprites to SpriteList
            SpriteList = new List<ISprite>()
            {
                new NonMovingSprite(shyGuy, new Vector2(350, 200), 100, 100),
                new NonMovingAnimatedSprite(shySpin, new Vector2(350, 200), 1, 5, 100, 100),
                new MovingSprite(shyGuyGhost, new Vector2(350, 200), 100, 100, 2),
                new MovingAnimatedSprite(shyWalk, new Vector2(350, 200), 1, 6, 100, 100, 2)
            };

            //set first sprite active
            SpriteList[0].active = true;

            //load in spriteFont
            font = Content.Load<SpriteFont>("galleryFont");
        }

        /*
         * A game loop that will loop for every frame of the game. 60 FPS
         */
        protected override void Update(GameTime gameTime)
        {
            //Check Quit Conditions
            keypad.CheckQuit(this);
            mouse.CheckQuit(this);

            //Update Game Logic Conditions
            gameLogic.Update(mouse, keypad, SpriteList);

            base.Update(gameTime);
        }

        /*
         * Where we can draw things onto the screen. Will also run once every frame. 60 FPS
         */
        protected override void Draw(GameTime gameTime)
        {
            //set the background color to Corn Flower Blue
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //write to screen
            writer.Write(_spriteBatch, font, "Credits", 100, 300);
            writer.Write(_spriteBatch, font, "Program Made By: Matt Ryan", 100, 325);
            writer.Write(_spriteBatch, font, "Sprites From: https://www.deviantart.com", 100, 352);

            //set the correct sprite as active
            gameLogic.Draw(_spriteBatch, keypad, SpriteList);

            base.Draw(gameTime);
        }
    }
}