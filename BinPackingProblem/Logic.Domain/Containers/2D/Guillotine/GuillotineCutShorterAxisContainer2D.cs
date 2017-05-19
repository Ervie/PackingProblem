using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain.Objects;

namespace Logic.Domain.Containers._2D.Guillotine
{
	public class GuillotineCutShorterAxisContainer2D : GuillotineCutContainer2D
	{
		public GuillotineCutShorterAxisContainer2D(int width, int height) : base(width, height)
		{
		}

		public override void SplitSubcontainer(GuillotineCutSubcontainer2D subcontainer, PlacedObject2D placedObject)
		{
			if (subcontainer.Height < subcontainer.Width)
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
