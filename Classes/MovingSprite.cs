using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal class MovingSprite : ISprite, IMove
    {
        //Sprite Variables
        public Texture2D Texture { get; set; }

        public Vector2 location { get; set; }

        public int sizeX { get; set; }
        public int sizeY { get; set; }

        public bool active { get; set; } = false;

        //Move variable
        public int speed { get; set; }

        public bool facingLeft { get; set; } = false;

        public MovingSprite(Texture2D texture, Vector2 locationPull, int X, int Y, int pace)
        {
            //assign texture
            Texture = texture;

            location = locationPull;

            //Set sizes
            sizeX = X;
            sizeY = Y;

            speed = pace;
        }

        public void Activate(SpriteBatch spriteBatch, KeyboardTool keypad)
        {
            //Draw Moving Sprite
            this.Draw(spriteBatch);
            this.Walk(keypad);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, sizeX, sizeY);

            spriteBatch.Begin();
            if (facingLeft)
            {
                spriteBatch.Draw(Texture, destinationRectangle,  Color.White);
            }
            else
            {
                spriteBatch.Draw(Texture, destinationRectangle, null, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
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
