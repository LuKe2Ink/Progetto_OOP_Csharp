using System;
using System.Drawing;

namespace Test.Entities
{
    /// <summary>
    /// Manage the entity's collisions
    /// </summary>
    class AaBb
    {
        private Point pos;
        private readonly int width;
        private readonly int height;
        private readonly int size;

        /// <summary>
        /// The class costructor 
        /// </summary>
        /// <param name="p"> the position in coordinates of the entity</param>
        /// <param name="w"> the width of the entity</param>
        /// <param name="h"> the height of the entity</param>
        public AaBb(Point p, int w, int h)
        {
            this.pos = p;
            this.width = w;
            this.height = h;
            this.size = Math.Max(w, h);
        }

        /// <summary>
        /// Manage the position of entity
        /// </summary>
        /// <returns> the current position</returns>
        public Point Getpos()
        {
            return pos;
        }

        /// <summary>
        /// Manage the entity's size
        /// </summary>
        /// <returns> the actual entity size</returns>
        public int Getsize()
        {
            return size;
        }

        /// <summary>
        /// Manage the position
        /// </summary>
        /// <param name="p"> set the new actuall position</param>
        public void Setpos(Point p)
        {
            this.pos = p;
        }

        /// <summary>
        /// Manage the collision between two boxes 
        /// </summary>
        /// <param name="box"> the other entity box</param>
        /// <returns> true if collide, false if not</returns>
        public bool Collides(AaBb box)
        {

            if (this.pos.X < (box.pos.X + box.width) && (this.pos.X + this.width) > box.pos.X
                && this.pos.Y < (box.pos.Y + box.height) && (this.pos.Y + this.height) > box.pos.Y)
            {
                return true;
            }

            return false;


        }
    }
}
