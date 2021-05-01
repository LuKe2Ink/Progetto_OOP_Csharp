using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mapandtiles
{
    class BossFloor : IAbsFloor
    {
        private int level;
        private Dictionary<Point, Tile> tilestate = new Dictionary<Point, Tile>();
        private int tilesize;
        private int screenw;
        private int screenh;
        private int width;
        private int height;
        private int offsetX = 0;
        private int offsetY = 0;
        private int border;

     /// <summary>
     /// 
     /// </summary>
     /// <param level="l"></param>
     /// <param width="w"></param>
     /// <param height="h"></param>
     /// <param screen width="screenw"></param>
     /// <param screen height="screenh"></param>
        public BossFloor(int l,  int w,  int h,  int screenw,
             int screenh) 
        {
    this.level = l;
    this.height = screenh;
    this.width = screenw;
    this.screenw = screenw;
    this.screenh = screenh;
    this.tilesize = 32;
    this.border = 2;
    BossfloorGenner(this.width, this.height);
   
  }
  
  
     /// <summary>
     /// generates the boss floor
     /// </summary>
     /// <param width="w"></param>
     /// <param height="h"></param>

  private void BossfloorGenner( int w, int h)
{
    for (int i = border; i < w / tilesize - border; i++)
    {
        for (int j = border + 1; j < h / tilesize - border; j++)
        {
            this.tilestate.Add(new Point(i, j), new Tile(new Point(i, j), true));
        }
    }
    for (int i = 0; i < width / tilesize; i++)
    {
        for (int j = 0; j < height / tilesize; j++)
        {
            if (!(tilestate.ContainsKey(new Point(i, j))))
            {
                this.tilestate.Add(new Point(i, j), new Tile(new Point(i, j), false));
            }
        }
    }
    for (int i = 0; i < 3; i++)
    {
        
    }
}

/// <summary>
/// creates exit at point p
/// </summary>
/// <param point="p"></param>
public void ExitCreate(Point p)
{
    
    this.tilestate[p].SetExit();
}


        /// <summary>
        /// returns the tilemap
        /// </summary>
        /// <returns></returns>
public  Dictionary<Point, Tile>  GetMap()
{
    return this.tilestate;
}




  public void Render( Graphics g)
{
    
}

/// <summary>
/// sets a tile at point p as walkable
/// </summary>
/// <param name="p"></param>

public void setTile(Point p)
{
    tilestate.Remove(p);
    tilestate.Add(p, new Tile(p, true));
}
/// <summary>
/// does nothing on boss floor
/// </summary>
/// <param name="x"></param>
/// <param name="y"></param>
public void MoveCam(int x,  int y)
{
    this.offsetX = 0;
    this.offsetY = 0;
}



        /// <summary>
        /// returns the level of the floor
        /// </summary>
        /// <returns></returns>
public int GetLevel()
{
    return this.level;
}


 public int GetOffsetX()
{
    
    return this.offsetX;
}


  public int GetOffsetY()
{
    
    return this.offsetY;
}

        /// <summary>
        /// returns screen width in pixels
        /// </summary>
        /// <returns></returns>
  public int GetScreenw()
{
    
    return this.screenw;
}
        /// <summary>
        /// returns screen height in pixels
        /// </summary>
        /// <returns></returns>
  public int GetScreenh()
{
    
    return this.screenh;
}
        /// <summary>
        /// returns width
        /// </summary>
        /// <returns></returns>
  public int GetWidth()
{
    
    return this.width;
}
        /// <summary>
        /// returns height
        /// </summary>
        /// <returns></returns>
  public int GetHeight()
{
    
    return this.height;
}

    }
}
