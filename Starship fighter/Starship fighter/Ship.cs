﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starship_fighter
{
	class Ship : BaseObject
	{
		public static event Message MessageDie;
		public static event Message Striking;
		public static event Message Bumping;
		// методы получения урона
		private int _energy = 100;
		private int _score = 0;
		public int Energy => _energy;
		public void EnergyLow(int n)
		{
			_energy -= n;
		}
		//увеличение очков
		public int Score => _score;
		public void ScorePlus(int f)
		{
			_score += f;
		}
		//метод лечения
		public void EnergyHi(int n)
		{
			_energy += n;
		}
		// конструктор
		public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
		{
		}
		// реализуем отрисовку корабля
		public override void Draw()
		{
			Game.Buffer.Graphics.FillEllipse(Brushes.Wheat, Pos.X, Pos.Y, Size.Width, Size.Height);
		}

		public override void Update()
		{
			
		}
		// меотды движения вверх и вниз
		public void Up()
		{
			if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;
		}
		public void Down()
		{
			if (Pos.Y < Game.Height) Pos.Y = Pos.Y + Dir.Y;
		}
		// методы вызывающий срабатывание event-в 
		public void Die(string str)
		{ 
			MessageDie?.Invoke(str);
		}
		public void Str(string str)
		{
			Striking?.Invoke(str);
		}
		public void Bmp(string str)
		{
			Bumping?.Invoke(str);
		}
	}
}
