using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Starship_fighter
{
	static class Game
	{

		private static BufferedGraphicsContext _context;
		public static BufferedGraphics Buffer;
		// Свойства, ширина и высота игрового поля
		public static int Width { get; set; }
		public static int Height { get; set; }

		static Game()
		{
		}

		public static void Init(Form form)
		{
			//Графическое устройство для вывода графики
			Graphics g;
			//Предоставляет доступ к главному буферу графического контекста для текущего приложения
			_context = BufferedGraphicsManager.Current;
			// Создаем объект (поверхность рисования) и связываем его с формой
			g = form.CreateGraphics();
			// Запоминаем размеры формы
			Width = form.ClientSize.Width;
			Height = form.ClientSize.Height;
			// Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
			Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

			// обработчик таймера
			 void Timer_Tick(object sender, EventArgs e)
			{
				Draw();
				Update();
			}
			//таймер
			Timer timer = new Timer { Interval = 100 };
			timer.Start();
			timer.Tick += Timer_Tick;



		}

		public static void Draw()
		{
			Buffer.Graphics.Clear(Color.Black);
			//выводим массив BaseObject _objs на экран
			foreach (BaseObject obj in _objs) obj.Draw();
			Buffer.Render();
			foreach (Asteroid obj in _asteroids) obj.Draw();
			Buffer.Render();
			_bullet.Draw();
			Buffer.Render();

		}

		private static Bullet _bullet;
		// массивы с фигурами
		public static BaseObject[] _objs;
		private static Asteroid[] _asteroids;

		public static void Load()
		{
			_objs = new BaseObject[30];
			_asteroids = new Asteroid[3];

			var rnd = new Random();

			//пули

			_bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(4, 1));
		

			//звёзды
			for (var i = 0; i < _objs.Length; i++)
			{
				int r = rnd.Next(5, 20);
				_objs[i] = new Star(new Point(1000, rnd.Next(0, Game.Height)), new Point(-r, r), new Size(3, 3));
			}
			//астероиды
			for (var i = 0; i <_asteroids.Length; i++)
			{
				int r = rnd.Next(5, 20);
				_asteroids[i] = new Asteroid(new Point(1000, rnd.Next(0, Game.Height)), new Point(-r / 5, r), new Size(r, r));
			}
			
		}

		public static void Update()
		{
			foreach (BaseObject obj in _objs)
				obj.Update();
			foreach (Asteroid a in _asteroids)
			{
				a.Update();
				if (a.Collision(_bullet)) { System.Media.SystemSounds.Hand.Play(); }
			}
			_bullet.Update();

		}
	}
}
