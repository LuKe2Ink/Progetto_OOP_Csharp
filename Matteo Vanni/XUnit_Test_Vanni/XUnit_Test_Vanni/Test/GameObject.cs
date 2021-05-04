using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Test
{
    public abstract class GameObject
    {

        public int CordX { get; set; }
        public int CordY { get; set; }
        public int VelX { get; set; }
        public int VelY { get; set; }
        public ID Id { get; set; }

        /**
         * Constructor for GameObject.
         *
         * @param x  Horizontal position
         * @param y  Vertical position
         * @param id Class ID
         */
        public GameObject(int x, int y, ID id)
        {
            CordX = x;
            CordY = y;
            Id = id;
        }

        /**
         * Execute operation per CPU clock.
         */
        public abstract void Tick();

        /*
         * Update position.
         */
        public abstract void Move();

        /**
         * Generate the graphics elements.
         *
         * @param g the grapichs that "draw" the elements
         */
        public abstract void Render(/*Graphics2D g*/);

        /**
         * Take input from user keyboard or update entity action after key press.
         *
         * @param key        The keyboard key(Es.: KeyEvent.VK_W)
         * @param collisions Set the movement limit on the map
         */
        public abstract void Input(KeyEventArgs key, List<AaBb> collisions);
    }

    
}
