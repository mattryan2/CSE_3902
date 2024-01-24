using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal interface IDrawable
    {
        void Draw(SpriteBatch spriteBatch, KeyboardTool keypad, List<ISprite> sprites);
    }
}
