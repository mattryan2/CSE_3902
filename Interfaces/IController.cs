using Microsoft.Xna.Framework.Input;

namespace Sprint0
{
    internal interface IController
    {
        //is the key I'm looking for pressed?
        bool isPressed(Keys key);

        //is the button I'm looking for pressed?
        bool IsPressed(ButtonState button);

        //Check quit conditions
        void CheckQuit(Game1 game);
    }
}
