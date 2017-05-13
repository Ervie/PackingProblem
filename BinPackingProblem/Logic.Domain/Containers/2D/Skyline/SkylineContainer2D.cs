using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain.Figures;

namespace Logic.Domain.Containers._2D.Skyline
{
	public class SkylineContainer2D : Container2D
	{
		public SkylineContainer2D(int width, int height) : base(width, height)
		{
		}

		protected override SubContainer2D CreateSubcontainer(Position2D position, Rectangle size)
		{
			return new SkylineSubContainer2D(position.X, position.Y, size.Width, size.Height);
		}
	}
}
