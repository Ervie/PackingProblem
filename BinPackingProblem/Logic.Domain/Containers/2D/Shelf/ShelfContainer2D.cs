using Logic.Domain.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain.Containers._2D.Shelf
{
	public class ShelfContainer2D : Container2D
	{
		public ShelfContainer2D(int width, int height) : base(width, height)
		{
			Subcontainers = new List<SubContainer2D>();
		}

		public SubContainer2D TopShelf
		{
			get { return Subcontainers.Last(); }
		}

		protected override SubContainer2D CreateSubcontainer(Position2D position, Rectangle size)
		{
			return new ShelfSubContainer2D(position.X, position.Y, size.Width, size.Height);
		}

		public void AddShelf()
		{
			ShelfSubContainer2D newShelf;

			if (Subcontainers.Count == 0)
				newShelf = new ShelfSubContainer2D(0, 0, this.Width, 0);
			else
				newShelf = new ShelfSubContainer2D(0, TopShelf.Y2, this.Width, 0);

			Subcontainers.Add(newShelf);
		}
	}
}
