using Logic.Domain.Figures;
using Logic.Domain.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Domain.Containers._2D
{
	public abstract class Container2D : Rectangle, IContainer<Object2D, Position2D>
	{
		//public PlacedObjects PlacedObjects
		//{
		//	get { return GetAllPlacedObjects(); }
		//	set { }
		//}

		public PlacedObjects PlacedObjects { get; set; }

		public bool IsClosed { get; set; }

		public IList<SubContainer2D> Subcontainers { get; set; }

		public Container2D(int width, int height) : base(width, height)
		{
			IsClosed = false;
			PlacedObjects = new PlacedObjects();
		}

		protected abstract SubContainer2D CreateSubcontainer(Position2D position, Rectangle size);

		public IPlacedObject PlaceObject(Object2D objectToPlace, Position2D position)
		{
			PlacedObject2D newObject = new PlacedObject2D(position, objectToPlace.Width, objectToPlace.Height);

			PlacedObjects.Add(newObject);

			return newObject;
		}

		public double GetFulfilment()
		{
			return (double)PlacedObjects.Sum(o => (o as Object2D).Width * (o as Object2D).Height)/Area;
		}

		//private PlacedObjects GetAllPlacedObjects()
		//{
		//	var placedObjects = new PlacedObjects();

		//	if (Subcontainers == null)
		//	{
		//		return placedObjects;
		//	}

		//	foreach (var subcontainer in Subcontainers)
		//	{
		//		placedObjects.AddRange(subcontainer.PlacedObjects);
		//	}

		//	return placedObjects;
		//}
	}
}