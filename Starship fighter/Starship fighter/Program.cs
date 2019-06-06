using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Starship_fighter
{
	class Program
	{
		static void Main(string[] args)
		{
			Form mainForm = new Form();
			mainForm.Width = 800;
			mainForm.Height = 600;
			Game.Init(mainForm);
			mainForm.Show();
			Game.Load();
			Game.Draw();
			Application.Run(mainForm);
		}
	}
}
