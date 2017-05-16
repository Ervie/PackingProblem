using Logic.Domain.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain.Containers._2D.Guillotine
{
	abstract class GuillotineCutContainer2D : Container2D
	{
		public GuillotineCutContainer2D(int width, int height) : base(width, height)
		{
		}

		protected abstract void SplitSubcontainer(GuillotineCutSubcontainer2D subcontainer);

		protected override SubContainer2D CreateSubcontainer(Position2D position, Rectangle size)
		{
			return new GuillotineCutSubcontainer2D(position.X, position.Y, size.Width, size.Height);
		}
	}
}
