using System;
using System.Drawing;

namespace Test.Entities
{
    class AaBb
    {
        private Point pos { get; set; };
        private readonly int width { get; set; };
        private readonly int height { get; set; };
        private readonly int size { get; set; };

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
