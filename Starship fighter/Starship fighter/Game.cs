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
			Timer timer = new Timer { Interval = 70 };
			timer.Start();
			timer.Tick += Timer_Tick;



		}

		public static void Draw()
		{
			// Проверяем вывод графики
			Buffer.Graphics.Clear(Color.Black);
			
			//Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
			//Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));

			//выводим массив BaseObject _objs на экран
			foreach (BaseObject obj in _objs) obj.Draw();
			Buffer.Render();
		}
		// массив с фигурами
		public static BaseObject[] _objs;
		/// <summary>
		/// метод загрузки фигур в массив для последующего их выведения на экран
		/// </summary>
		public static void Load()
		{
			_objs = new BaseObject[60];
			//for (int i = 0; i < _objs.Length / 2; i++)
			//{
			//	_objs[i] = new BaseObject(new Point(600, i * 20), new Point(-i, -i), new Size(20, 20));
			//}
			for(int i = 0; i < _objs.Length; i++)
			{                                 //X   //Y            //X  //Y
				_objs[i] = new Star(new Point(700, i*20), new Point(20+i, 0), new Size(5, 5));
			}										     //значение смещения //размер фигуры
		}

		public static void Update()
		{
			foreach (BaseObject obj in _objs) obj.Update();
		}
	}
}
