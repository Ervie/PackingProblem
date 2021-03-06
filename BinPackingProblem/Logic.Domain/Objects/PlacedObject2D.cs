﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain.Objects
{
	public class PlacedObject2D: Object2D, IPlacedObject
	{
		public int X
		{
			get { return Position.X; }
		}

		public int Y
		{
			get { return Position.Y; }
		}

		public int X2
		{
			get { return X + Width; }
		}

		public int Y2
		{
			get { return Y + Height; }
		}

		public PlacedObject2D(int x, int y, int width, int height) 
            :base(width, height)
        {
			Position = new Position2D(x, y);
		}

		public PlacedObject2D(Position2D position, int width, int height) 
            :base(width, height)
        {
			Position = position;
		}

		public PlacedObject2D(int x, int y, Object2D theObject): base(theObject.Width, theObject.Height)
		{
			Position = new Position2D(x, y);
		}

		public PlacedObject2D(Position2D position, Object2D theObject) : base(theObject.Width, theObject.Height)
		{
			Position = position;
		}

		public Position2D Position { get; protected set; }

		public IPosition GetPostion()
		{
			return Position;
		}
	}
}
