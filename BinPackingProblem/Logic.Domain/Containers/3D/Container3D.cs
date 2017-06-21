using Logic.Domain.Figures;
using Logic.Domain.Objects;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Domain.Containers._3D
{
	public abstract class Container3D : Cuboid, IContainer<Object3D, Position3D>
	{
		public PlacedObjects PlacedObjects { get; set; }

		public bool IsClosed { get; set; }

		public IList<SubContainer3D> Subcontainers { get; set; }

		public Container3D(int width, int height, int depth) : base(width, height, depth)
		{
			IsClosed = false;
			PlacedObjects = new PlacedObjects();
		}

		protected abstract SubContainer3D CreateSubcontainer(Position3D position, Cuboid size);

		public IPlacedObject PlaceObject(Object3D objectToPlace, Position3D position)
		{
			PlacedObject3D newObject = new PlacedObject3D(position, objectToPlace.Width, objectToPlace.Height, objectToPlace.Depth);

			PlacedObjects.Add(newObject);

			return newObject;
		}

		public double GetFulfilment()
		{
			return (double)PlacedObjects.Sum(o => (o as Object3D).Width * (o as Object3D).Height * (o as Object3D).Depth) / Volume;
		}
	}
}