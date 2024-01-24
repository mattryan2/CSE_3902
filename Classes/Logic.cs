using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextureAtlas;

namespace Sprint0
{
    internal class Logic : ILogical, IDrawable, IActivate 
    {

        public void Update(MouseTool mouse, KeyboardTool keypad, List<ISprite> sprites)
        {
            this.SetActiveKey(keypad, sprites);
            this.SetActiveClick(mouse, sprites);
        }

        public void Draw(SpriteBatch spriteBatch, KeyboardTool keypad, List<ISprite> sprites)
        {
            this.SetActive(spriteBatch, keypad, sprites);
        }

        //Find the appropriate sprite with key and set as active
        public void SetActiveKey(KeyboardTool keypad, List<ISprite> sprites)
        {
            
            //loop through keys to see if any are pressed
            for (int i = 0; i < keypad.keysTopRow.Count; i++)
            {
                //if they ARE pressed, loop through sprites and activate / deactivate accordingly
                if (keypad.isPressed(keypad.keysTopRow[i]) || keypad.isPressed(keypad.keysRightPad[i]))
                {
                    for (int j = 0; j < sprites.Count; j++)
                    {
                        //if we are on the corresponding sprite to the key
                        if (j == i)
                        {
                            sprites[j].active = true;
                        }
                        else
                        {
                            sprites[j].active = false;
                        }
                    }
                }
            }
        }

        //Find the appropriate sprite with click and set as active
        public void SetActiveClick(MouseTool mouse, List<ISprite> sprites)
        {
            //only look if left button is clicked on mouse
            if (mouse.IsPressed(Mouse.GetState().LeftButton))
            {
                //no default quad
                int quad = -1;

                //find the appropriate quad that is being pressed
                for (int i = 0; i < mouse.quads.Count; i++)
                {
                    if (mouse.IsInArea(mouse.quads[i])) //is click in specified quad
                    {
                        quad = i;
                    }
                }

                //Set the appropriate sprite
                if (quad != -1)
                {
                    for (int i =0; i < sprites.Count; i++)
                    {
                        //if quad corresponds to sprite set true
                        if (i == quad)
                        {
                            sprites[i].active = true;
                        } else
                        {
                            sprites[i].active = false;
                        }
                    }
                }
            }
        }

        //Turn the sprites with active = true as on
        public void SetActive(SpriteBatch spriteBatch, KeyboardTool keypad, List<ISprite> sprites)
        {
            //choose sprite
            foreach (ISprite sprite in sprites)
            {
                //if it's active
                if (sprite.active)
                {
                    //Activate it
                    sprite.Activate(spriteBatch, keypad);
                }
            }
        }
    }
}
