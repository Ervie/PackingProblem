using Logic.Domain.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain.Containers._2D.Skyline
{
	public class SkylineSubContainer2D : SubContainer2D
	{
		public SkylineSubContainer2D(int x, int y, int width, int height) : base(x, y, width, height)
		{
			var availableSkyline = new Line(0, Width);
			AvailableSkylines = new List<Line> { availableSkyline };
		}

		public PlacedObject LastPlacedObject { get; private set; }

		public bool IsOpen
		{
			get { return AvailableSkylines.Any(); }
		}

		public IList<Line> AvailableSkylines { get; private set; }
	}
}
