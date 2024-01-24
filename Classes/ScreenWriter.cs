using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal class ScreenWriter : IWrite
    {

        public void Write(SpriteBatch spriteBatch, SpriteFont font, string str, int x, int y)
        { 
            spriteBatch.Begin();

            // Write Message - Parameters - (Font, Message, Position, Color) - We're going to default to black
            spriteBatch.DrawString(font, str, new Vector2(x, y), Color.Black);

            spriteBatch.End();
        }
    }
}
