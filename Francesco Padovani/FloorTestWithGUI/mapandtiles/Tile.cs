using System;
using System.Drawing;

namespace mapandtiles
{
	public class Tile
	{
		private Boolean tiletype;
		private Point p;
		private Boolean exit = false;
		/// <summary>
		/// creates a tile with position p and walkable/not walkable
		/// </summary>
		/// <param point="p"></param>
		/// <param true for walkable false for non walkable="b"></param>
		public Tile(Point p, Boolean b)
		{
			this.tiletype = b;
			this.p = p;
		}/// <summary>
		/// true walkable false non walkable
		/// </summary>
		/// <returns></returns>
		public Boolean GetTile() { return this.tiletype; ; }
		/// <summary>
		/// defines if this is a exit
		/// </summary>
		public void SetExit() { this.exit = true; }
		/// <summary>
		/// true if the tile is a exit, false otherwise
		/// </summary>
		/// <returns></returns>
		public Boolean IsExit() { return this.exit; }
	}
}
