using Logic.Domain.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain.Containers._2D.Guillotine
{
	public class GuillotineCutSubcontainer2D : SubContainer2D
	{
		public bool IsOpen { get; private set; }

		public GuillotineCutSubcontainer2D(int x, int y, int width, int height) : base(x, y, width, height)
		{
		}

		public override void PlaceObject(Object2D theObject, Position2D position)
		{
			base.PlaceObject(theObject, position);

			Close();
		}

		protected void Close()
		{
			IsOpen = false;
		}
	}
}
