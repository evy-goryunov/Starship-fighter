using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starship_fighter
{
	class Asteroids : BaseObject
	{
		Image myImg = Image.FromFile("aster.png");
		public Asteroids(Point pos, Point dir, Size size) : base(pos, dir, size)
		{
		}

		public override void Draw()
		{
			Game.Buffer.Graphics.DrawImage(myImg, Pos.X, Pos.Y);
		}

		public override void Update()
		{
			Pos.X = Pos.X - Dir.X;
			if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
		}
	}
}
