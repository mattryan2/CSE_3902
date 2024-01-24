using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Threading.Tasks;

namespace Sprint0
{
    internal interface ISprite
    {
        //sprite texture
        Texture2D Texture { get; set; }

        //starting location
        public Vector2 location { get; set; }

        //size on X-axis
        int sizeX { get; set; }

        //size on Y-axis
        int sizeY { get; set; }

        //true when on screen, false if not
        bool active { get; set; }

        //Draw sprite to screen
        void Draw(SpriteBatch spriteBatch);

        void Activate(SpriteBatch spriteBatch, KeyboardTool keypad);
    }
}
