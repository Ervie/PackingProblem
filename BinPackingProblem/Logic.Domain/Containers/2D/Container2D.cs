using Logic.Domain.Figures;
using Logic.Domain.Objects;
using System;
using System.Collections.Generic;

namespace Logic.Domain.Containers._2D
{
	public abstract class Container2D : Rectangle, IContainer<Object2D, Position2D>
	{
		public PlacedObjects PlacedObjects
		{
			get { return GetAllPlacedObjects(); }
		}

		public bool IsClosed { get; set; }

		public IList<SubContainer2D> Subcontainers { get; set; }

		public Container2D(int width, int height) : base(width, height)
		{
			IsClosed = false;
		}

		protected abstract SubContainer2D CreateSubcontainer(Position2D position, Rectangle size);

		public void PlaceObject(Object2D objectToPlace, Position2D position)
		{
			PlacedObject2D newObject = new PlacedObject2D(position, objectToPlace.Width, objectToPlace.Height);

			PlacedObjects.Add(newObject);
		}

		private PlacedObjects GetAllPlacedObjects()
		{
			var placedObjects = new PlacedObjects();

			if (Subcontainers == null)
			{
				return placedObjects;
			}

			foreach (var subcontainer in Subcontainers)
			{
				placedObjects.AddRange(subcontainer.PlacedObjects);
			}

			return placedObjects;
		}
	}
}