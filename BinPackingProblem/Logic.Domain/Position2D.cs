using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain
{
	public class Position2D: IPosition
	{
		public int X { get; set; }

		public int Y { get; set; }

		public Position2D()
		{
		}

		public Position2D(int x, int y)
		{
			X = x;
			Y = y;
		}

		public Position2D(Position2D position)
		{
			X = position.X;
			Y = position.Y;
		}
	}
}
