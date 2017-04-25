using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain
{
	public class Position3D: IPosition
	{
		public int X { get; set; }

		public int Y { get; set; }

		public int Z { get; set; }

		public Position3D()
		{
		}

		public Position3D(int x, int y, int z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public Position3D(Position3D position)
		{
			X = position.X;
			Y = position.Y;
			Z = position.Z;
		}
	}
}
