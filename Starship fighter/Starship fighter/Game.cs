using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;


namespace Starship_fighter
{
	static class Game
	{

		private static BufferedGraphicsContext _context;
		public static BufferedGraphics Buffer;
		// Свойства, ширина и высота игрового поля
		public static int Width { get; set; }
		public static int Height { get; set; }
		//таймер
		private static Timer _timer = new Timer() { Interval = 20 };
		public static Random Rnd = new Random();

		static Game()
		{
		}
		// запись в файл
		public static void WriteToFile(string s)
		{
				StreamWriter sw = new StreamWriter("log.txt", true);
				sw.WriteLine(s);
				sw.Close();
		}
		// вывод в консоль
		public static void Finish(string s)
		{
			_timer.Stop();
			Console.WriteLine(s);
			Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
			Buffer.Render();
		}
		public static void Strike(string s)
		{
			Console.WriteLine(s);
		}
		public static void Bump(string s)
		{
			Console.WriteLine(s);
		}

		public static void Init(Form form)
		{
			// обработчик событий нажатия клавиши
			form.KeyDown += Form_KeyDown;
			//Графическое устройство для вывода графики
			Graphics g;
			//Предоставляет доступ к главному буферу графического контекста для текущего приложения
			_context = BufferedGraphicsManager.Current;
			// Создаем объект (поверхность рисования) и связываем его с формой
			g = form.CreateGraphics();
			// Запоминаем размеры формы
			// --->Исключение для 4 задания<---
			try
			{
				Width = form.ClientSize.Width;
				Height = form.ClientSize.Height;
			}
			catch (ArgumentOutOfRangeException e)
			{
				Console.WriteLine("Неверный размер экрана");
			}
			// Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
			Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

			// обработчик таймера
			 void Timer_Tick(object sender, EventArgs e)
			{
				Draw();
				Update();
			}
	
			_timer.Start();
			_timer.Tick += Timer_Tick;
			//передаём нужные нам методы в event-ы
			Ship.MessageDie += WriteToFile;
			Ship.MessageDie += Finish;
			Ship.Striking += WriteToFile;
			Ship.Striking += Strike;
			Ship.Bumping += WriteToFile;
			Ship.Bumping += Bump;
			
		}
		// обработчик событий нажатия клавиши
		private static void Form_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.ControlKey) _bullet = new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 4), new Point(4, 0), new Size(4, 1));
			if (e.KeyCode == Keys.Up) _ship.Up();
			if (e.KeyCode == Keys.Down) _ship.Down();
		}
		// отрисовка объектов
		public static void Draw()
		{
			Buffer.Graphics.Clear(Color.Black);
			foreach (BaseObject obj in _objs) obj.Draw();
			foreach (Asteroid a in _asteroids) { a?.Draw(); }
			_bullet?.Draw();
			_ship?.Draw();
			_firstAid?.Draw();
			if (_ship != null)
				Buffer.Graphics.DrawString("Energy:" + _ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);
				Buffer.Graphics.DrawString("Score:" + _ship.Score, SystemFonts.DefaultFont, Brushes.White, 100, 0);
			Buffer.Render();
		}

		private static Ship _ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(10, 10));
		private static Bullet _bullet;
		private static FirstAitKit _firstAid;
		//массивы с фигурами
		public static BaseObject[] _objs;
		private static Asteroid[] _asteroids;
		//загржаем объекты на экран
		public static void Load()
		{
			_objs = new BaseObject[30];
			_asteroids = new Asteroid[3];

			var rnd = new Random();

			//пули
			//_bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(6, 1));
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
				_asteroids[i] = new Asteroid(new Point(1100, rnd.Next(0, Game.Height)), new Point(-r / 5, r), new Size(r, r));
			}
			//аптечки
			
			
			int f = rnd.Next(5, 20);
			_firstAid = new FirstAitKit(new Point(1100, rnd.Next(0, Game.Height)), new Point(-f / 5, f), new Size(25, 25), 25);

		}
		//обновляем отрисовку
		public static void Update()
		{
			foreach (BaseObject obj in _objs) obj.Update();

			_bullet?.Update();
			_firstAid?.Update();

			for (var i = 0; i < _asteroids.Length; i++)
			{
				if (_asteroids[i] == null) continue;
				_asteroids[i].Update();
				if (_bullet != null && _bullet.Collision(_asteroids[i]))
				{
					System.Media.SystemSounds.Hand.Play();
					_asteroids[i] = null;
					_bullet = null;
					//+1 к счёту за сбитый астероид
					_ship?.ScorePlus(1);
					// вызов метода у экземпляра класса Ship который вызовет срабатывание event-а
					_ship?.Str("Попадание по астероиду");
					continue;
				}
				//логика срабатывания аптечки
				if (_ship.Collision(_firstAid))
				{
					if (_ship.Energy < 100)
					{
						_ship?.EnergyHi(_firstAid.AidValue);
					}
				}
				if (!_ship.Collision(_asteroids[i])) continue;
				if (_ship.Collision(_asteroids[i])) _ship?.Bmp("Столкновение с астероидом");
				var rnd = new Random();
				_ship?.EnergyLow(rnd.Next(1, 5));
				System.Media.SystemSounds.Asterisk.Play();
				if (_ship.Energy <= 0) _ship?.Die("Окончание игры");
			}
		}
	}
}
