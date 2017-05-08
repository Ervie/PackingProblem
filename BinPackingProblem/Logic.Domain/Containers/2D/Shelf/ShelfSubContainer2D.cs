using Logic.Domain.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain.Containers._2D.Shelf
{
	public class ShelfSubContainer2D: SubContainer2D
	{
		public ShelfSubContainer2D(int x, int y, int width, int height) : base(x, y, width, height)
		{
			LastPlacedObject = null;
		}

		private PlacedObject2D _lastPlacedObject;

		public PlacedObject2D LastPlacedObject
		{
			get
			{
				if (_lastPlacedObject == null)
					return new PlacedObject2D(0, 0, 0, 0);
				else
					return _lastPlacedObject;
			}
			set
			{
				_lastPlacedObject = value;
			}
		}


	}
}
