using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starship_fighter
{
	abstract class BaseObject
	{
		protected Point Pos;
		protected Point Dir;
		protected Size Size;

		protected BaseObject(Point pos, Point dir, Size size)
		{
			Pos = pos;
			Dir = dir;
			Size = size;
		}
		public abstract void Draw();
		public virtual void Update()
		{
			Pos.X = Pos.X + Dir.X;
			if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
		}
	}

}
