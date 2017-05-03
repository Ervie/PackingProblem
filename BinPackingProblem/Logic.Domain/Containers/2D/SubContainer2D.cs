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
		}

		public PlacedObjects PlacedObjects { get; set; }

	}
}
