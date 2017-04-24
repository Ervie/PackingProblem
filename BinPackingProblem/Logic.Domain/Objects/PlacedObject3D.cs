using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain.Objects
{
	public class PlacedObject3D: Object3D
	{
		public int X
		{
			get { return Position.X; }
		}

		public int Y
		{
			get { return Position.Y; }
		}

		public int Z
		{
			get { return Position.Z; }
		}

		public int X2
		{
			get { return X + Width; }
		}

		public int Y2
		{
			get { return Y + Height; }
		}

		public int Z2
		{
			get { return Z + Depth; }
		}

		protected PlacedObject3D(int x, int y, int z, int width, int height, int depth) 
            :base(width, height, depth)
        {
			Position = new Position3D(x, y, z);
		}

		protected PlacedObject3D(Position3D position, int width, int height, int depth) 
            :base(width, height, depth)
        {
			Position = position;
		}

		public Position3D Position { get; protected set; }
	}
}
