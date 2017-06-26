using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain.Figures;

namespace Logic.Domain.Containers._3D.Shelf
{
	public class ShelfContainer3D : Container3D
	{
		public ShelfContainer3D(int width, int height, int depth) : base(width, height, depth)
		{
			Subcontainers = new List<SubContainer3D>();
		}

		protected override SubContainer3D CreateSubcontainer(Position3D position, Cuboid size)
		{
			return new ShelfSubContainer3D(position.X, position.Y, position.Z, size.Width, size.Height, size.Depth);
		}

		public SubContainer3D TopShelf
		{
			get { return Subcontainers.Last(); }
		}

		public void AddShelf()
		{
			if (Subcontainers.Count != 0)
				(TopShelf as ShelfSubContainer3D).SetShelfDepth();

			ShelfSubContainer3D newShelf;

			if (Subcontainers.Count == 0)
				newShelf = new ShelfSubContainer3D(0, 0, 0, this.Height, this.Width, 0);
			else
				newShelf = new ShelfSubContainer3D(0, 0, TopShelf.Z2, this.Height, this.Width, 0);

			Subcontainers.Add(newShelf);
		}
	}
}
