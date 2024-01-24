using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal interface ILogical
    {

        void Update(MouseTool mouse, KeyboardTool keypad, List<ISprite> Sprites);

    }

}
