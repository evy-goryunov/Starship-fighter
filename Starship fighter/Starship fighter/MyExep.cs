using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starship_fighter
{
	class MyExep : Exception
	{
		string messege;

		public override string Message
		{
			get
			{
				return this.messege;
			}
		}

		public int Error { get; set; }

		public MyExep(string msg, int err)
		{
			this.Error = err;
			this.messege = msg;
		}

		public override string ToString()
		{
			return $"{this.Error}{base.Message}";
		}
	}
}
