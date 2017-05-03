using Logic.Domain.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain.Containers._2D.Shelf
{
	public class ShelfContainer : Container2D
	{
		public ShelfContainer(int width, int height) : base(width, height)
		{
		}

		public SubContainer2D TopShelf
		{
			get { return Subcontainers.Last(); }
		}

		protected override SubContainer2D CreateSubcontainer(Position2D position, Rectangle size)
		{
			return new ShelfSubContainer(position.X, position.Y, size.Width, size.Height);
		}
	}
}
