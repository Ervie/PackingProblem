using Logic.Domain.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain.Containers._3D
{
	public abstract class SubContainer3D: PlacedObject3D
	{
		protected SubContainer3D(int x, int y, int z, int width, int height, int depth) : base(x, y, z, width, height, depth)
		{
			PlacedObjects = new PlacedObjects();
		}

		protected SubContainer3D(Position3D position, int width, int height, int depth) : base(position, width, height, depth)
		{
			PlacedObjects = new PlacedObjects();
		}

		public PlacedObjects PlacedObjects { get; set; }

		public virtual void PlaceObject(Object3D theObject, Position3D position)
		{
			var placedObject = new PlacedObject3D(position, theObject);

			PlacedObjects.Add(placedObject);
		}
	}
}
