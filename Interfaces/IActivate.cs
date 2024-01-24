using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal interface IActivate
    {
        //check if active key was clicked and set appropriate sprite as active
        void SetActiveKey(KeyboardTool keypad, List<ISprite> sprites);

        //check if active button was clicked and set appropriate sprite as active
        void SetActiveClick(MouseTool mouse, List<ISprite> sprites);

        //Set the sprite active
        void SetActive(SpriteBatch spriteBatch, KeyboardTool keypad, List<ISprite> sprites);
    }
}
