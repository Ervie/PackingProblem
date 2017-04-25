using Logic.Domain.Figures;
using Logic.Domain.Objects;
using System;
using System.Collections.Generic;

namespace Logic.Domain.Containers._2D
{
	public class Container2D : Rectangle, IContainer<Object2D, Position2D>
	{
		public PlacedObjects PlacedObjects { get; set; }

		public Container2D(int width, int height) : base(width, height)
		{
		}

		public void PlaceObject(Object2D objectToPlace, Position2D position)
		{
			throw new NotImplementedException();
		}
	}
}