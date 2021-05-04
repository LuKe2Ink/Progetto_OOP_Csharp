using System;
using System.Drawing;

namespace Test
{
    public class AaBb
    {
        public Point Pos { get; set; }
        private int Width { get; set; }
        private int Height { get; set; }
        private int Size { get; set; }

        /**
         * Constructor.
         *
         * @param p starting point of the box
         * @param w box width
         * @param h box height
         */
        public AaBb(Point p, int w, int h)
        {
            Pos = new Point(p.X, p.Y);
            //Pos = p;
            Width = w;
            Height = h;
            Size = Math.Max(w, h);
        }

        public void SumX(int sum)
        {
            Pos = new Point(Pos.X + sum, Pos.Y);
        }

        public void SumY(int sum)
        {
            Pos = new Point(Pos.X, Pos.Y + sum);
        }


        public bool Collides(AaBb box)
        {
            if (Pos.X < box.Pos.X + box.Width && Pos.X + Width > box.Pos.X && Pos.Y < box.Pos.Y + box.Height && Pos.Y + Height > box.Pos.Y)
            {
                return true;
            }
            return false;
        }
    }
}
