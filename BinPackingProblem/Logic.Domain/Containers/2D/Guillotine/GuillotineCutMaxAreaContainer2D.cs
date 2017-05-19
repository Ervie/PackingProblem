using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain.Objects;

namespace Logic.Domain.Containers._2D.Guillotine
{
	public class GuillotineCutMaxAreaContainer2D : GuillotineCutContainer2D
	{
		public GuillotineCutMaxAreaContainer2D(int width, int height) : base(width, height)
		{
		}

		public override void SplitSubcontainer(GuillotineCutSubcontainer2D subcontainer, PlacedObject2D placedObject)
		{
			var availableAreaAboveObject = (subcontainer.Height - placedObject.Height) * placedObject.Width;
			var availableAreaOnTheRightOfObject = placedObject.Height * (subcontainer.Width - placedObject.Width);

			if (availableAreaAboveObject > availableAreaOnTheRightOfObject)
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
