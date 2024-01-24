using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal interface IPosition
    {
        //is the button clikced within a specific quadrant? takes int[] of size 4
        bool IsInArea(int[] quad);
    }
}
