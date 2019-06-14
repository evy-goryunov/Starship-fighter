using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/// <summary>
/// Горюнов Егвений

/// Добавить космический корабль, как описано в уроке.
/// Доработать игру «Астероиды»:
/// Добавить ведение журнала в консоль с помощью делегатов;
/// * добавить это и в файл.
/// Разработать аптечки, которые добавляют энергию.
/// Добавить подсчет очков за сбитые астероиды.
/// * Добавить в пример Lesson3 обобщенный делегат.

/// </summary>
namespace Starship_fighter
{
	class Program
	{
		static void Main(string[] args)
		{
			Form mainForm = new Form { Width = Screen.PrimaryScreen.Bounds.Width, Height = Screen.PrimaryScreen.Bounds.Height };
			Game.Init(mainForm);
			mainForm.Show();
			Game.Load();
			Game.Draw();
			Application.Run(mainForm);
		}
	}
}
