using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starship_fighter
{
	class Ship : BaseObject
	{
		public static event Message MessageDie;
		// свойства
		private int _energy = 100;
		public int Energy => _energy;
		public void EnergyLow(int n)
		{
			_energy -= n;
		}
		// конструктор
		public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
		{
		}
		// реализуем отрисовку корабля
		public override void Draw()
		{
			Game.Buffer.Graphics.FillEllipse(Brushes.Wheat, Pos.X, Pos.Y, Size.Width, Size.Height);
		}

		public override void Update()
		{
			
		}
		// меотды движения вверх и вниз
		public void Up()
		{
			if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;
		}
		public void Down()
		{
			if (Pos.Y < Game.Height) Pos.Y = Pos.Y + Dir.Y;
		}
		public void Die()
		{
			MessageDie?.Invoke();
		}

	}
}
