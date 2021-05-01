using mapandtiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace francescopadovanicsharpgui
{
	public partial class Form1 : Form
	{

		private Floor f;
		public Form1()
		{

			InitializeComponent();



		}
		private void Form1_Load(object sender, EventArgs e)
		{
			this.f = new Floor(1, 1980, 1080, 1980, 1100);


		}
		
		
		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			Dictionary<Point, Tile> s = f.GetMap();
			Brush brush = new SolidBrush(Color.Red);
			f.Render(g, brush);
			Brush brushy = new SolidBrush(Color.Blue);
			
		}
		
	}
}
