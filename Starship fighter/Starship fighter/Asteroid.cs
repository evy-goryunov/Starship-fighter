using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starship_fighter
{
	class Asteroid : BaseObject, ICloneable
	{
		public int Power { get; set; }
		public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
		{
			Power = 1;
		}

		public override void Draw()
		{
			// --->работа пользовательского исключения для 5 задания<---
			try
			{
				Game.Buffer.Graphics.FillEllipse(Brushes.White, Pos.X, Pos.Y, Size.Width, Size.Height);
				if (Size.Width > 100)
				{
					throw new MyExep("Слишком большой размер", 1);
				}
			}
			catch(MyExep e)
			{
				Console.WriteLine(e.Message);
			}
		}

		public object Clone()
		{
			Asteroid asteroid = new Asteroid(new Point(Pos.X, Pos.Y), new Point(Dir.X, Dir.Y), new Size(Size.Width, Size.Height));
			asteroid.Power = Power;
			return asteroid;
		}

		public override void Update()
		{
			Pos.X = Pos.X + Dir.X;
			if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
		}
	}
}
