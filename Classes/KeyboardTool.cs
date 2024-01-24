using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{

    public class KeyboardTool : IController
    {
        public List<Keys> keysRightPad = new List<Keys>()
            {
                Keys.NumPad1,
                Keys.NumPad2,
                Keys.NumPad3,
                Keys.NumPad4
             };

        public List<Keys> keysTopRow = new List<Keys>()
            {
                Keys.D1,
                Keys.D2,
                Keys.D3,
                Keys.D4
            };

        //Check if a key is pressed
        public bool isPressed(Keys key)
        {
            if (Keyboard.GetState().IsKeyDown(key))
            {
                return true;
            }

            return false;
        }

        //Keyboards do not need to press buttons
        public bool IsPressed(ButtonState button)
        {
            throw new NotImplementedException();
        }

        public void CheckQuit(Game1 game)
        {
            //exit the game if we receive a 0
            if (this.isPressed(Keys.D0) || this.isPressed(Keys.NumPad0))
            {
                game.Exit();
            }
        }
    }
}
