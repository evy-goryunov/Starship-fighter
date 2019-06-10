using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
/// <summary>
/// интерфейс столконовений объектов
/// </summary>
namespace Starship_fighter
{
	interface ICollision
	{
		bool Collision(ICollision obj);
		Rectangle Rect { get; }
	}
}
