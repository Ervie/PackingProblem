using Logic.Domain.Figures;
using Logic.Domain.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Domain.Containers._3D
{
	public class Container3D : Cuboid, IContainer<Object3D, Position2D>
	{
		public PlacedObjects PlacedObjects { get; set; }

		public bool IsClosed { get; set; }

		public Container3D(int width, int height, int depth) : base(width, height, depth)
		{
			IsClosed = false;
		}

		public IPlacedObject PlaceObject(Object3D objectToPlace, Position2D position)
		{
			throw new NotImplementedException();
		}

		public double GetFulfilment()
		{
			return (double)PlacedObjects.Sum(o => (o as Object3D).Width * (o as Object3D).Height * (o as Object3D).Depth) / Volume;
		}
	}
}