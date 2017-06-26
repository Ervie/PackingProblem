using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain.Containers._3D.Shelf
{
	public class ShelfSubContainer3D: SubContainer3D
	{
		public ShelfSubContainer3D(int x, int y, int z, int width, int height, int depth) : base(x, y, z, width, height, depth)
		{

		}

		public int MaxItemDepth { get; set; }

		public void SetShelfDepth()
		{
			this.Depth = MaxItemDepth;
		}
	}
}
