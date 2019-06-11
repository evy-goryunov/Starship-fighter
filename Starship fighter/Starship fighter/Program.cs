using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/// <summary>
/// Горюнов Егвений
///2)Переделать виртуальный метод Update в BaseObject в абстрактный и реализовать его в наследниках.
///3)Сделать так, чтобы при столкновении пули с астероидом они регенерировались в разных концах экрана.
///4)Сделать проверку на задание размера экрана в классе Game.Если высота или ширина(Width, Height) 
///больше 1000 или принимает отрицательное значение, выбросить исключение ArgumentOutOfRangeException().
///5)* Создать собственное исключение GameObjectException, которое появляется при попытке  создать объект 
///с неправильными характеристиками(например, отрицательные размеры, слишком большая скорость или неверная позиция).
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
