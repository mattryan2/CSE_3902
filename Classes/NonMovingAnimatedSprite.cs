
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0;
using System.Net.Mime;

namespace TextureAtlas
{
    public class NonMovingAnimatedSprite : ISprite, IAnimation 
    {
        //Sprite Variables
        public Texture2D Texture { get; set; }

        public Vector2 location {  get; set; }

        public int sizeX { get; set; }
        public int sizeY { get; set; }

        public bool active { get; set; } = false;

        //Animation Variables
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int currentFrame { get; set; }
        public int totalFrames { get; set; }

        public int fpsCount { get; set; }

        public NonMovingAnimatedSprite(Texture2D texture, Vector2 locationPull, int rows, int columns, int X, int Y)
        {
            //Set texture and location
            Texture = texture;
            location = locationPull;

            //Set sizes
            sizeX = X;
            sizeY = Y;

            //assign number of rows
            Rows = rows;

            //assign number of columns
            Columns = columns;

            //current
            currentFrame = 0;
            totalFrames = Rows * Columns;

            //count FPS
            fpsCount = 0;
        }

        //Activate our sprite
        public void Activate(SpriteBatch spriteBatch, KeyboardTool keypad)
        {
            //Draw Moving Sprite
            this.Draw(spriteBatch);
            this.Animate();
        }

        //Animate our sprite
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

        //Draw our Sprite
        public void Draw(SpriteBatch spriteBatch)
        {
            //dynamically assign animation dimensions
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = currentFrame / Columns;
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width - 2, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, sizeX, sizeY);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}