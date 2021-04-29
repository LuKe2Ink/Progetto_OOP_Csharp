using System;
using System.Drawing;

namespace Test.Entities
{
    class AaBb
    {
        private Point pos;
        private readonly int width;
        private readonly int height;
        private readonly int size;

        /**
         * Constructor.
         *
         * @param p starting point of the box
         * @param w box width
         * @param h box height
         */
        public AaBb(Point p, int w, int h)
        {
            this.pos = p;
            this.width = w;
            this.height = h;
            this.size = Math.Max(w, h);
        }

        /**
         * get the position of the box.
         *
         * @return position point
         */
        public Point Getpos()
        {
            return pos;
        }

        /**
         * get the size of your box.
         *
         * @return box size
         */
        public int Getsize()
        {
            return size;
        }

        /**
         * get the coordinate x.
         *
         * @return horizontal position
         */
        public int GetX()
        {
            return pos.X;
        }

        /**
         * get the coordinate y.
         *
         * @return vertical position
         */
        public int GetY()
        {
            return pos.Y;
        }

        /**
         * Used in horizontal velocity movement.
         *
         * @param sum sum of actual pos.x
         */
        public void SumX(int sum)
        {
            this.pos.X += sum;
        }

        /**
         * Used in vertical velocity movement.
         *
         * @param sum sum of actual pos.y
         */
        public void SumY(int sum)
        {
            this.pos.Y += sum;
        }

        /**
         * Set box position.
         *
         * @param p position point
         */
        public void Setpos(Point p)
        {
            this.pos = p;
        }

        /**
         * Used as control for hit on box.
         *
         * @param box the box of the object
         * @return true if collides, false if not
         */
        public bool Collides(AaBb box)
        {

            if (this.pos.X < box.pos.X + box.width && this.pos.X + this.width > box.pos.X
                && this.pos.Y < box.pos.Y + box.height && this.pos.Y + this.height > box.pos.Y)
            {
                return true;
            }

            return false;


        }
    }
}
