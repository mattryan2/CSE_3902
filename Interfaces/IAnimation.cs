using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Threading.Tasks;

namespace Sprint0
{
    internal interface IAnimation
    {
        //rows in sprite sheet
        int Rows { get; set; }

        //columns in sprite sheet
        int Columns { get; set; }

        //beginning frame
        int currentFrame { get; set; }

        //rows * columns
        int totalFrames { get; set; }

        //how many frames have passed
        int fpsCount { get; set; }

        //update animation
        void Animate();


    }
}