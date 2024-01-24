using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal interface IWrite
    {

        //Writing Class
        void Write(SpriteBatch spriteBatch, SpriteFont font, string str, int x, int y);
    }
}
