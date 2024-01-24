using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint0
{
    public class MouseTool : IPosition, IController
    {
        //mousestate
        MouseState mouseState = Mouse.GetState();

        //List all of the quads we will be using
        public List<int[]> quads = new List<int[]>()
        {
            //{upper left x, upper left y, lower right x, lower right y}
            new int[] {0, 0, 400, 240 }, //Quad 1
            new int[] {400, 0, 800, 240 }, //Quad 2
            new int[] {0, 200, 400, 480 }, //Quad 3
            new int[] { 400, 200, 800, 480 } //Quad 4
        };

        //check if button is pressed
        public bool IsPressed(ButtonState button)
        {
            if (button == ButtonState.Pressed)
            {
                return true;
            }

            return false;
        }

        //Mice do not need to press keys.
        public bool isPressed(Keys key)
        {
            throw new NotImplementedException();
        }

        public bool IsInArea(int[] quad)
        {
            //gets state of the mouse 60 times per second
            mouseState = Mouse.GetState();

            int x = mouseState.Position.X;
            int y = mouseState.Position.Y;

            if ((x > quad[0]) && (y > quad[1]) && (x < quad[2]) && (y < quad[3]))
            {
                return true;
            }
            return false;
        }

        public void CheckQuit(Game1 game)
        {
            //exit the game if we receive a right click
            if (this.IsPressed(Mouse.GetState().RightButton))
            {
                game.Exit();
            }
        }

    }
}
