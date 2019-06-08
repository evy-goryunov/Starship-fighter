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
			//Bitmap MyB = new Bitmap("aster.png");
			//Graphics MyG;
			//MyG = form.CreateGraphics();
			//MyG.DrawImage(MyB, 10, 10);
			// Проверяем вывод графики
			Buffer.Graphics.Clear(Color.Black);

			//Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
			//Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
			
			//выводим массив BaseObject _objs на экран
			foreach (BaseObject obj in _objs) obj.Draw();
			Buffer.Render();
			foreach (BaseObject obj in _objs2) obj.Draw();
			Buffer.Render();
			foreach (BaseObject obj in _objs3) obj.Draw();
			Buffer.Render();
		}
		// массив с фигурами
		public static BaseObject[] _objs;
		public static BaseObject[] _objs2;
		public static BaseObject[] _objs3;
		/// <summary>
		/// метод загрузки фигур в массив для последующего их выведения на экран
		/// </summary>
		public static void Load()
		{
			_objs = new BaseObject[60];
			_objs2 = new BaseObject[30];
			_objs3 = new BaseObject[5];
			//for (int i = 0; i < _objs.Length / 2; i++)
			//{
			//	_objs[i] = new BaseObject(new Point(600, i * 20), new Point(-i, -i), new Size(20, 20));
			//}

			for(int i = 0; i < _objs.Length / 2; i++)
			{                                 //X   //Y            //X  //Y
				_objs[i] = new Star(new Point(700, i*20), new Point(20+i, 0), new Size(5, 5));
			}                                            //значение смещения //размер фигуры

			for (int i = _objs.Length / 2; i < _objs.Length; i++)
			{
				_objs[i] = new SpaceTrash(new Point(100, i * 5), new Point(i, i), new Size(1, 1));
			}

			for (int i = 0; i < _objs2.Length / 2; i++)
			{
				_objs2[i] = new SpaceTrash(new Point(350, i * 8), new Point(1 + i, i), new Size(2, 2));
			}

			for (int i = _objs2.Length / 2; i < _objs2.Length; i++)
			{
				_objs2[i] = new SpaceTrash2(new Point(450, i * 19), new Point(1 + i, i), new Size(3, 3));
				//_objs2[i] = new Asteroids(new Point(450, i * 19), new Point(1 + i, i), new Size(3, 3));
			}
			for (int i = 0; i < _objs3.Length; i++)
			{
				
				_objs3[i] = new Asteroids(new Point(0, i * 120), new Point(1 + i, i), new Size(3, 3));
			}
		}

		public static void Update()
		{
			foreach (BaseObject obj in _objs) obj.Update();
			foreach (BaseObject obj in _objs2) obj.Update();
			foreach (BaseObject obj in _objs3) obj.Update();
		}
	}
}
