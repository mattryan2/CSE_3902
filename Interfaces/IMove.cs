using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal interface IMove
    {
        //how many pizels to move each frame
        int speed { get; set; }

        //are we facing left?
        bool facingLeft { get; set; }

        //move left
        void MoveLeft();

        //move right
        void MoveRight();

        //move down
        void MoveDown();

        //move up
        void MoveUp();

        //Walk around
        void Walk(KeyboardTool keypad);

    }
}
