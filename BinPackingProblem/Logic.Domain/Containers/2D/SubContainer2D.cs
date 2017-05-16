using Logic.Domain.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain.Containers._2D
{
	public abstract class SubContainer2D: PlacedObject2D
	{
		protected SubContainer2D(int x, int y, int width, int height) : base(x, y, width, height)
		{
			PlacedObjects = new PlacedObjects();
		}

		public PlacedObjects PlacedObjects { get; set; }

		public virtual void PlaceObject(Object2D theObject, Position2D position)
		{
			var placedObject = new PlacedObject2D(position, theObject);

			PlacedObjects.Add(placedObject);
		}

	}
}
