using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starship_fighter
{
	class FirstAitKit : BaseObject
	{
		private int _aidValue;
		public int AidValue => _aidValue;

		Image aidImg = Image.FromFile("firstaid.png");
		// конструктор, указываем мощность аптечки
		public FirstAitKit(Point pos, Point dir, Size size, int firstAidKitEnergy) : base(pos, dir, size)
		{
			_aidValue = firstAidKitEnergy;
		}

		public override void Draw()
		{
			Game.Buffer.Graphics.DrawImage(aidImg, Pos.X, Pos.Y);
		}

		public override void Update()
		{
			Pos.X = Pos.X + Dir.X;
			if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
		}
	}
}
