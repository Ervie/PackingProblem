using Logic.Domain.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain.Containers._2D.Shelf
{
	class ShelfSubContainer: SubContainer2D
	{
		public ShelfSubContainer(int x, int y, int width, int height) : base(x, y, width, height)
		{
			LastPlacedObject = null;
		}

		public PlacedObject2D LastPlacedObject { get; private set; }


	}
}
