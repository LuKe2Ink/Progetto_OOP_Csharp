using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Drawing;
namespace Test
{
    public class KeyInput//extends KeyAdapter
    {

        public List<GameObject> Handler;//ex Handler class
        public int Moves { get; set; }

        public bool IsPlayer { get; set; }//for testing

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
        //Added a generic game object and removed tempobj for testing
        public void KeyPressed(KeyEventArgs key, GameObject genericObj)
        {
            List<AaBb> collisions = new List<AaBb>();
            /*Testing a list of 4 elements*/
            Handler.Add(genericObj);
            Handler.Add(genericObj);
            Handler.Add(genericObj);
            Handler.Add(genericObj);
            //collisions.Where(x => x.get >= n).ToList();
            /*handler.object.stream().filter(x->x.getId() != Id.FLOOR && x.getId() != Id.HUD)
                .forEach(x->collisions.add(((Entity)x).getBox()));*/

            //Handler.Where(x => x.)final List<AaBb> collisions = new ArrayList<>();
            if (genericObj.Id == ID.Player)
            {
                IsPlayer = true;
            }
            
            for (int i = 0; i < Handler.Count; i++) {
                if (genericObj.Id == ID.Player)
                {
                    genericObj.Input(key, collisions);
                    if (key.KeyCode == Keys.A || key.KeyCode == Keys.S || key.KeyCode == Keys.D || key.KeyCode == Keys.W)
                    {
                        Moves++;
                    }
                }
                if (key.KeyCode == Keys.A || key.KeyCode == Keys.S || key.KeyCode == Keys.D || key.KeyCode == Keys.W || key.KeyCode == Keys.J || key.KeyCode == Keys.K)
                {
                    if (key.KeyCode != Keys.J && key.KeyCode != Keys.K)
                    {   
                        if (genericObj.Id == ID.Player)
                        {
                            ((Player)genericObj).Attacking = false;
                        }
                    }

                    /* Used for Enemy and Boss combat
                    if (tempobj.Id == ID.Enemy)//does nothing
                    {
                        tempobj.Input(key, collisions);
                    }
                    if (tempobj.Id == ID.Boss)//does nothing
                    {
                        tempobj.Input(key, collisions);
                    }*/
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
        //Added a generic game object and removed tempobj for testing
        public void KeyReleased(KeyEventArgs e, GameObject genericObj)
        {
            for (int i = 0; i < Handler.Count(); i++) {
                if (/*genericObj.Id == ID.Enemy || */genericObj.Id == ID.Player)
                {
                    if (e.KeyCode == Keys.W)
                    {
                        genericObj.VelY=0;
                        ((Entity)genericObj).Movement=false;
                        ((Entity)genericObj).Attacking=false;
                    }
                    if (e.KeyCode == Keys.A)
                    {
                        genericObj.VelX=0;
                        ((Entity)genericObj).Movement=false;
                        ((Entity)genericObj).Attacking=false;
                    }
                    if (e.KeyCode == Keys.S)
                    {
                        genericObj.VelY=0;
                        ((Entity)genericObj).Movement=false;
                        ((Entity)genericObj).Attacking=false;
                    }
                    if (e.KeyCode == Keys.D)
                    {
                        genericObj.VelX=0;
                        ((Entity)genericObj).Movement=false;
                        ((Entity)genericObj).Attacking=false;
                    }
                    if (e.KeyCode == Keys.J)
                    {
                        genericObj.VelX=0;
                        ((Entity)genericObj).Movement=false;
                        ((Entity)genericObj).Attacking=false;
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
