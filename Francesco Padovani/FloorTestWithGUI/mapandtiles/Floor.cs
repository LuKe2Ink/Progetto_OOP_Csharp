using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace mapandtiles
{
	public class Floor : IAbsFloor
	{
       
 
        private  int level;
        private int screenw;
        private int screenh;
        private int width;
        private  int height;
        private Dictionary<Point, Tile> tilestate= new Dictionary <Point,Tile>();
        private int tilesize { get; set; }
        private  ArrayList leaves = new ArrayList();
        private static  int MAX_LEAF_SIZE = 24;
        private  Random rand = new Random();
        private int offsetX;
        private int offsetY;

        /// <summary>
        /// creates a new floor with given parameters
        /// </summary>
        /// <param level="l"></param>
        /// <param width="w"></param>
        /// <param height="h"></param>
        /// <param screen width="screenw"></param>
        /// <param screen height="screenh"></param>
        public Floor( int l,  int w,  int h,  int screenw,
            int screenh) 
        {
    this.level = l;
    this.height = h;
    this.width = w;
    this.screenw = screenw;
    this.screenh = screenh;
    this.tilesize = 16;
    this.offsetX = 0;
    this.offsetY = 0;
    FloorGenner(width, height);
}

/// <summary>
/// generates a pseudorandom floor 
/// </summary>
/// <param floor width="w"></param>
/// <param floor height="h"></param>
private void FloorGenner( int w,  int h)
{
    RoomsCreate();
    for (int i = 0; i < w / tilesize; i++)
    {
        for (int j = 0; j < h / tilesize; j++)
        {
            if (!tilestate.ContainsKey(new Point(i, j)))
            {
                this.tilestate.Add(new Point(i, j), new Tile(new Point(i, j), false));
            }
        }
    }

}

/// <summary>
/// use the bsp algorithm to generate rooms and halls of the floor
/// </summary>
private void RoomsCreate()
{
     Leaf root = new Leaf(0, 0, width / tilesize , height / tilesize );
    leaves.Add(root);
    Boolean didsplit = true;
    while (didsplit)
    {
        didsplit = false;
                
        for (int i = 0; i < leaves.Count; i++)
        {
             Leaf l =(Leaf) leaves[i];
            if (l.leftChild == null && l.rightChild == null)
            { // if this Leaf is not already split...
              // if this Leaf is too big, or 75% chance...
                if (l.width > MAX_LEAF_SIZE || l.height > MAX_LEAF_SIZE || rand.NextDouble() > 0.25)
                {
                    if (l.Split())
                    { // split the Leaf!
                      // if we did split, push the child leafs to the List so we can loop into them
                      // next
                        leaves.Add(l.leftChild);
                        leaves.Add(l.rightChild);
                        didsplit = true;
                    }
                }
            }
        }
    }
    root.CreateRooms(ref this.tilestate);

}


        /// <summary>
        /// renders the floor 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="brush"></param>
  public void Render(Graphics g,Brush brush)
{
    
    for (int i = 0; i < width/ tilesize; i++)
    {
        for (int j = 0; j < height / tilesize; j++)
        {
            if (tilestate.ContainsKey(new Point(i , j))) { 
                        if(tilestate[new Point(i,j)].GetTile())
            {
                 
                g.FillRectangle(brush,new Rectangle((i + offsetX)*tilesize, (j+offsetY)*tilesize ,  tilesize,  tilesize));
            }
                        }

        }
    }

}

public int GetOffsetX()
{
    return this.offsetX;
}

public int GetOffsetY()
{
    return this.offsetY;
}

public void SetOffsetX( int x)
{
    this.offsetX = x;
}

public void SetOffsetY( int y)
{
    this.offsetY = y;
}

public int GetScreenw()
{
    return this.screenw;
}

public int GetScreenh()
{
    return this.screenh;
}

public void SetScreenw( int x)
{
    this.screenw = x;
}

public void SetScreenh( int y)
{
    this.screenh = y;
}

public int GetWidth()
{
    return this.width;
}

public int GetHeight()
{
    return this.height;
}

public Dictionary<Point,Tile> GetMap()
{
    return this.tilestate;
}

/// <summary>
/// moves the offset of the camera
/// </summary>
/// <param name="x"></param>
/// <param name="y"></param>
public void MoveCam(int x,  int y)
{
   
    if (offsetX + x < 0 || offsetX + x > width / tilesize - screenw / tilesize)
    {
        x = 0;
    }
    if (offsetY + y < 0 || offsetY + y > height / tilesize - screenh / tilesize)
    {
        y= 0;
    }
    this.SetOffsetX(offsetX += x);
    this.SetOffsetY(offsetY += y);
   

}


public void SetTile(Point p)
{ tilestate.Remove(p);
    tilestate.Add(p, new Tile(p, true));
}
	}
}
