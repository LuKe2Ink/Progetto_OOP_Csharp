using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace mapandtiles
{
	public interface IAbsFloor
	{

		void MoveCam(int x, int y);

		Dictionary<Point,Tile> GetMap();

		 int GetOffsetX();

		int GetOffsetY();

		int GetScreenw();

		int GetScreenh();

		int GetWidth();

		int GetHeight();
	}
}