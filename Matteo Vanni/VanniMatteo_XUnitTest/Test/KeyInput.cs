using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Test
{
    public class KeyInput//extends KeyAdapter
    {

        private List<GameObject> Handler;//ex Handler class
        private int Moves { get; set; }

        /**
         * Constructor.
         *
         * @param handler event controller
         */
        public KeyInput(List<GameObject> handler)
        {
            Handler = handler;
            Moves = 0;
        }

        /**
         * Control events when user press a key.
         *
         * @param key the key pressed
         */
        public void KeyPressed(KeyEventArgs key)
        {

            List<AaBb> collisions = new List<AaBb>();
                //collisions.Where(x => x.get >= n).ToList();
                /*handler.object.stream().filter(x->x.getId() != Id.FLOOR && x.getId() != Id.HUD)
                    .forEach(x->collisions.add(((Entity)x).getBox()));*/

                //Handler.Where(x => x.)final List<AaBb> collisions = new ArrayList<>();
            
            
            for (int i = 0; i < Handler.Count; i++) {
                GameObject tempobj = Handler.ElementAt(i);

                if (tempobj.Id == ID.Player)
                {
                    tempobj.Input(key, collisions);
                    if (key.KeyCode == Keys.A || key.KeyCode == Keys.S || key.KeyCode == Keys.D || key.KeyCode == Keys.W)
                    {
                        Moves++;
                    }
                }
                if (key.KeyCode == Keys.A || key.KeyCode == Keys.S || key.KeyCode == Keys.D || key.KeyCode == Keys.W || key.KeyCode == Keys.J || key.KeyCode == Keys.K)
                {
                    if (key.KeyCode == Keys.J && key.KeyCode == Keys.K)
                    {   
                        if (tempobj.Id == ID.Player)
                        {
                            ((Player)tempobj).Attacking = false;
                        }
                    }
                    if (tempobj.Id == ID.Enemy)
                    {
                        tempobj.Input(key, collisions);
                    }
                    if (tempobj.Id == ID.Boss)
                    {
                        tempobj.Input(key, collisions);
                    }
                }

                /*Require menu package
                if (tempobj.getId() == Id.HUD && key.getKeyCode() == KeyEvent.VK_Q)
                {
                    ((Hud)tempobj).setHudDisplay(true);
                }*/
            }
            collisions.Clear();
        }

        /**
         * Control when user release the pressed key.
         *
         * @param e the event of the key pressed
         */
        public void KeyReleased(KeyEventArgs e)
        {
            for (int i = 0; i < Handler.Count(); i++) {
                GameObject tempobj = Handler.ElementAt(i);
                if (tempobj.Id == ID.Enemy || tempobj.Id == ID.Player)
                {
                    if (e.KeyCode == Keys.W)
                    {
                        tempobj.VelY=0;
                        ((Entity)tempobj).Movement=false;
                        ((Entity)tempobj).Attacking=false;
                    }
                    if (e.KeyCode == Keys.A)
                    {
                        tempobj.VelX=0;
                        ((Entity)tempobj).Movement=false;
                        ((Entity)tempobj).Attacking=false;
                    }
                    if (e.KeyCode == Keys.S)
                    {
                        tempobj.VelY=0;
                        ((Entity)tempobj).Movement=false;
                        ((Entity)tempobj).Attacking=false;
                    }
                    if (e.KeyCode == Keys.D)
                    {
                        tempobj.VelX=0;
                        ((Entity)tempobj).Movement=false;
                        ((Entity)tempobj).Attacking=false;
                    }
                    if (e.KeyCode == Keys.J)
                    {
                        tempobj.VelX=0;
                        ((Entity)tempobj).Movement=false;
                        ((Entity)tempobj).Attacking=false;
                    }
                }

                /*Require menu package
                if (key == KeyEvent.VK_Q && tempobj.getId() == Id.HUD)
                {
                    ((Hud)tempobj).setHudDisplay(false);
                }*/
            }
        }
    }

}
