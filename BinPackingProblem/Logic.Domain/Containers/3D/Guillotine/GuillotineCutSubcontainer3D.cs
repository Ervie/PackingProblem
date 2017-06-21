using Logic.Domain.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain.Containers._3D.Guillotine
{
	public class GuillotineCutSubcontainer3D : SubContainer3D
	{
		public bool IsOpen { get; private set; }

		public GuillotineCutSubcontainer3D(int x, int y, int z, int width, int height, int depth) : base(x, y, z, width, height, depth)
		{
		}

		public GuillotineCutSubcontainer3D(Position3D position, int width, int height, int depth) : base(position, width, height, depth)
		{
		}

		public override void PlaceObject(Object3D theObject, Position3D position)
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
