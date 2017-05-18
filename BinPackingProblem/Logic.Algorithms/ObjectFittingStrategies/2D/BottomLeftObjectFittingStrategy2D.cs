using Logic.Domain.Containers._2D;
using Logic.Domain.Objects;
using System;

namespace Logic.Algorithms.ObjectFittingStrategies._2D
{
	public class BottomLeftObjectFittingStrategy2D : AbstractFittingStrategy2D
	{
		public override double CalculateFittingQuality(Object2D objectToPlace, SubContainer2D subcontainer)
		{
			return subcontainer.Y - 1f / (subcontainer.X + 1);
		}
	}
}