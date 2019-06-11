using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starship_fighter
{
	class Bullet : BaseObject
	{
		Random r = new Random();
		public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
		{
		}

		public override void Draw()
		{
				Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
		}
		public override void Update()
		{
			int i = r.Next(1, 1000);
			Pos.X = Pos.X + 3;
			if (Pos.X > Game.Width)
			{
				Pos.X = 0;
				Pos.Y = i;
			}
		}
	}
}
