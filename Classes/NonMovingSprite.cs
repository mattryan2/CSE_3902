using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal class NonMovingSprite : ISprite
    {
        public Texture2D Texture { get; set; }

        public Vector2 location { get; set; }
        public int sizeX { get; set; }
        public int sizeY { get; set; }

        public bool active { get; set; } = false;

        public NonMovingSprite(Texture2D texture, Vector2 locationPull, int X, int Y)
        {
            //Set texture and location
            Texture = texture;
            location = locationPull;

            //Set sizes
            sizeX = X;
            sizeY = Y;
        }

        public void Activate(SpriteBatch spriteBatch, KeyboardTool keypad)
        {
            //Draw Moving Sprite
            this.Draw(spriteBatch);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, sizeX, sizeY);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
