using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain.Objects;

namespace Logic.Domain.Containers._2D.Guillotine
{
	public class GuillotineCutShorterLeftoverAxisContainer2D : GuillotineCutContainer2D
	{
		public GuillotineCutShorterLeftoverAxisContainer2D(int width, int height) : base(width, height)
		{
		}

		public override void SplitSubcontainer(GuillotineCutSubcontainer2D subcontainer, PlacedObject2D placedObject)
		{
			var leftoverHeight = subcontainer.Height - placedObject.Height;
			var leftoverWidth = subcontainer.Width - placedObject.Width;

			if (leftoverHeight < leftoverWidth)
			{
				SplitSubcontainerVertically(subcontainer, placedObject);
			}
			else
			{
				SplitSubcontainerHorizontally(subcontainer, placedObject);
			}
		}
	}
}
