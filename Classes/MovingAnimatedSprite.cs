
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0;
using System.Net.Mime;
using System.Data.Common;
using Microsoft.Xna.Framework.Input;

namespace TextureAtlas
{
    public class MovingAnimatedSprite : ISprite, IAnimation, IMove
    {
        //Sprite Variables
        public Texture2D Texture { get; set; }

        public Vector2 location { get; set; }

        public int sizeX { get; set; }
        public int sizeY { get; set; }

        public bool active { get; set; } = false;

        //Animation Variables
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int currentFrame { get; set; }
        public int totalFrames { get; set; }

        public int fpsCount { get; set; }

        //Move variable
        public int speed {  get; set; }

        public bool facingLeft { get; set; } = true;

        public MovingAnimatedSprite(Texture2D texture, Vector2 locationPull, int rows, int columns, int X, int Y, int pace)
        {
            //assign texture
            Texture = texture;

            //Set sizes
            sizeX = X;
            sizeY = Y;

            //set starting location
            location = locationPull;

            //assign number of rows
            Rows = rows;

            //assign number of columns
            Columns = columns;

            //current
            currentFrame = 0;
            totalFrames = Rows * Columns;

            //count FPS
            fpsCount = 0;

            speed = pace;
        }

        public void Animate()
        {
            //iterate FPS
            fpsCount++;

            //move animation every 10 frames (spin slower)
            if (fpsCount == 10)
            {
                currentFrame++;
                fpsCount = 0;
            }

            //wrap around if we exceed last frame
            if (currentFrame == totalFrames)
                currentFrame = 0;
        }

        //activate our sprite
        public void Activate(SpriteBatch spriteBatch, KeyboardTool keypad)
        {
            //Draw Moving Sprite
            this.Draw(spriteBatch);
            this.Animate();
            this.Walk(keypad);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //dynamically assign animation dimensions
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = currentFrame / Columns;
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width - 1, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, sizeX, sizeY);

            spriteBatch.Begin();
            if (facingLeft)
            {
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            }
            else
            {
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
            }
            spriteBatch.End();
        }

        public void MoveLeft()
        {
            if (location.X > 0)
            {
                //set location left
                location = new Vector2(location.X - speed, location.Y);
                facingLeft = true;
            }
        }

        public void MoveRight()
        {
            if (location.X < 700)
            {
                //set location right
                location = new Vector2(location.X + speed, location.Y);
                facingLeft = false;
            }

        }

        public void MoveDown()
        {
            if (location.Y < 380)
            {
                //set location down
                location = new Vector2(location.X, location.Y + speed);
            }

        }

        public void MoveUp()
        {
            if (location.Y > 0)
            {
                //set location up
                location = new Vector2(location.X, location.Y - speed);
            }
        }

        public void Walk(KeyboardTool keypad)
        {
            if (keypad.isPressed(Keys.A) || keypad.isPressed(Keys.Left))
            {
                //Move Left
                this.MoveLeft();

            }
            else if (keypad.isPressed(Keys.S) || keypad.isPressed(Keys.Down))
            {
                //Move Down
                this.MoveDown();
            }
            else if (keypad.isPressed(Keys.D) || keypad.isPressed(Keys.Right))
            {

                //Move Right
                this.MoveRight();

            }
            else if (keypad.isPressed(Keys.W) || keypad.isPressed(Keys.Up))
            {
                //Move Up
                this.MoveUp();
            }

        }
    }
}