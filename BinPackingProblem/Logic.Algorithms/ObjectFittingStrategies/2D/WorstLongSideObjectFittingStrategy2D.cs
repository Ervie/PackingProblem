using Logic.Domain.Containers._2D;
using Logic.Domain.Objects;
using System;

namespace Logic.Algorithms.ObjectFittingStrategies._2D
{
	public class WorstLongSideObjectFittingStrategy2D : AbstractFittingStrategy2D
	{
		public override double CalculateFittingQuality(Object2D objectToPlace, SubContainer2D subcontainer)
		{
			return 1f / Math.Max(subcontainer.Width - objectToPlace.Width, subcontainer.Height - objectToPlace.Height);
		}
	}
}