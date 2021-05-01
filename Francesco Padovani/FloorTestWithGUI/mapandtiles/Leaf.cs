using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace mapandtiles
{
	public class Leaf 
	{
		public int width, height;
		int x, y;
		public Leaf leftChild; // the Leaf's left child Leaf
		public Leaf rightChild; // the Leaf's right child Leaf
		public Nullable<Rectangle> room; // the room that is inside this Leaf
		//private Dictionary<Point,Tile> tilestate;
		Random r = new Random();
		private int minLeafSize = 9;
		public Leaf(int x, int y, int w, int h)
		{
			this.x = x;
			this.y = y;
			this.width = w;
			this.height = h;
			//
			// TODO: Add constructor logic here
			//
		}
		public Boolean Split()
		{
			if (leftChild != null || rightChild != null)
			{
				return false; // we're already split! Abort!
			}
			Boolean splitH = r.NextDouble() > 0.5;
			if (width > height && width / height >= 1.25)
			{
				splitH = false;
			}
			else if (height > width && height / width >= 1.25)
			{
				splitH = true;
			}

			// determine the maximum height or width
			int max = (splitH ? height : width) - minLeafSize;
			if (max <= minLeafSize)
			{
				return false; // the area is too small to split any more...
			}


			int split = r.Next(minLeafSize,max+1) ; // determine where we're going to split


			// create our left and right children based on the direction of the split
			if (splitH)
			{
				leftChild = new Leaf(x, y, width, split);
				rightChild = new Leaf(x, y + split, width, height - split);
			}
			else
			{
				leftChild = new Leaf(x, y, split, height);
				rightChild = new Leaf(x + split, y, width - split, height);
			}
			return true;
		}
		public void CreateRooms( ref Dictionary<Point,Tile> tilestate2)
		{
			if (leftChild != null || rightChild != null)
			{
				// this leaf has been split, so go into the children leafs
				if (leftChild != null)
				{
					leftChild.CreateRooms(ref tilestate2);
				}
				if (rightChild != null)
				{
					rightChild.CreateRooms(ref tilestate2);
				}
				if (leftChild != null && rightChild != null )
				{
					CreateHall(leftChild.GetRoom().Value, rightChild.GetRoom().Value, ref tilestate2);
				}
			}
			else
			{
				// this Leaf is the ready to make a room
				Point roomSize;
				Point roomPos;
				// the room can be between 3 x 3 tiles to the size of the leaf - 2.
				roomSize = new Point(r.Next(3,this.width-2),
					r.Next(3,this.height-2));
				// place the room within the Leaf, but don't put it right
				// against the side of the Leaf (that would merge rooms together)
				roomPos = new Point(r.Next(1,this.width-roomSize.X-1) ,
					r.Next(1,this.height-roomSize.Y-1) );
				room = new Rectangle(x + roomPos.X, y + roomPos.Y, roomSize.X, roomSize.Y);
				for (int a = room.Value.X; a < room.Value.X + room.Value.Width; a++)
				{
					for (int b = room.Value.Y; b < room.Value.Y + room.Value.Height; b++)
					{
						if(!tilestate2.ContainsKey(new Point(a,b)))
						tilestate2.Add(new Point(a, b), new Tile(new Point(a, b),true));
						
					}

				}

			}
		}
		public Nullable<Rectangle> GetRoom()
		{
			// iterate all the way through these leafs to find a room, if one exists.
			if (room != null)
			{
				return room;
			}
			else
			{
				Nullable<Rectangle> leftRoom = null ;
				Nullable<Rectangle> rightRoom = null;
				if (leftChild != null)
				{
					leftRoom = leftChild.GetRoom();
				}
				if (rightChild != null)
				{
					rightRoom = rightChild.GetRoom();
				}
				if (leftRoom == null && rightRoom == null)
				{
					return null;
				}
				else if (rightRoom == null)
				{
					return leftRoom;
				}
				else if (leftRoom == null)
				{
					return rightRoom;
				}
				else if (r.NextDouble() > 0.5)
				{
					return leftRoom;
				}
				else
				{
					return rightRoom;
				}

			}
		}
		public void CreateHall(Nullable<Rectangle> li, Nullable <Rectangle> rig, ref Dictionary<Point,Tile> tilestate2)
		{
			// now we connect these two rooms together with hallways.
			// this looks pretty complicated, but it's just trying to figure out which point
			// is where and then either draw a straight line, or a pair of lines to make a
			// right-angle to connect them.
			// you could do some extra logic to make your halls more bendy, or do some more
			// advanced things if you wanted.

			List<Nullable<Rectangle>> halls; // hallways to connect this Leaf to other Leafs
			halls = new List<Nullable<Rectangle>>();
			
			Rectangle l = li.Value;
			Rectangle ri = rig.Value;
			 Point point1 = new Point((int)r.Next(l.X+1,l.Width+l.X-1) ,
				(int)r.Next(l.Y+1,l.Height+l.Y-1)) ;
			 Point point2 = new Point((int)r.Next(ri.X+1,ri.Width+ri.X-1) ,
				(int)r.Next(ri.Y+1,ri.Height+ri.Y-1));

			 int w = point2.X - point1.X;
			 int h = point2.Y - point1.Y;

			if (w < 0)
			{
				if (h < 0)
				{
					if (r.NextDouble() < 0.5)
					{
						halls.Add(new Rectangle(point2.X, point1.Y, Math.Abs(w)+1 , 1));
						halls.Add(new Rectangle(point2.X, point2.Y, 1, Math.Abs(h)+1 ));
					}
					else
					{
						halls.Add(new Rectangle(point2.X, point2.Y, Math.Abs(w)+1 , 1));
						halls.Add(new Rectangle(point1.X, point2.Y, 1, Math.Abs(h)+1 ));
					}
				}
				else if (h > 0)
				{
					if (r.NextDouble() < 0.5)
					{
						halls.Add(new Rectangle(point2.X, point1.Y, Math.Abs(w)+1 , 1));
						halls.Add(new Rectangle(point2.X, point1.Y, 1, Math.Abs(h)+1 ));
					}
					else
					{
						halls.Add(new Rectangle(point2.X, point2.Y, Math.Abs(w)+1 , 1));
						halls.Add(new Rectangle(point1.X, point1.Y, 1, Math.Abs(h)+1 ));
					}
				}
				else
				{
					halls.Add(new Rectangle(point2.X, point2.Y, Math.Abs(w), 1));
				}

			}
			else if (w > 0)
			{
				if (h < 0)
				{
					if (r.NextDouble() < 0.5)
					{
						halls.Add(new Rectangle(point1.X, point2.Y, Math.Abs(w)+1 , 1));
						halls.Add(new Rectangle(point1.X, point2.Y, 1, Math.Abs(h)+1 ));
					}
					else
					{
						halls.Add(new Rectangle(point1.X, point1.Y, Math.Abs(w)+1 , 1));
						halls.Add(new Rectangle(point2.X, point2.Y, 1, Math.Abs(h)+1 ));
					}
				}
				else if (h > 0)
				{
					if (r.NextDouble() < 0.5)
					{
						halls.Add(new Rectangle(point1.X, point1.Y, Math.Abs(w), 1));
						halls.Add(new Rectangle(point2.X, point1.Y, 1, Math.Abs(h)));
					}
					else
					{
						halls.Add(new Rectangle(point1.X, point2.Y, Math.Abs(w), 1));
						halls.Add(new Rectangle(point1.X, point1.Y, 1, Math.Abs(h)));
					}

				}
				else
				{
					halls.Add(new Rectangle(point1.X, point1.Y, Math.Abs(w), 1));
				}
			}
			else
			{
				if (h < 0)
				{
					halls.Add(new Rectangle(point2.X, point2.Y, 1, Math.Abs(h) ));
				}
				else if (h > 0)
				{
					halls.Add(new Rectangle(point1.X, point1.Y, 1, Math.Abs(h)));
				}
			}
			foreach (Rectangle r in halls)
			{
				for (int b = 0; b < r.Width; b++)
				{
					for (int d = 0; d < r.Height; d++)
					{
						if(!tilestate2.ContainsKey(new Point(r.X + b, r.Y + d)))
						tilestate2.Add(new Point(r.X + b, r.Y + d),
							new Tile(new Point(r.X + b, r.Y + d), true));
					}
				}
			}

		}
	}


}