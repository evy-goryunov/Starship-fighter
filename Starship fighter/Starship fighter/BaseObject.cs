using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starship_fighter
{
	public delegate void Message(string msg);

	abstract class BaseObject : ICollision
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
		//draw и update реализуем в наследниках
		public abstract void Draw();
		public abstract void Update();

		// реализуем интерфейс столконовений объектов
		public bool Collision(ICollision o)
		{
			return o.Rect.IntersectsWith(this.Rect);
		}

		public Rectangle Rect
		{
			get
			{
				return new Rectangle(Pos, Size);
			}
		}
	}

}
