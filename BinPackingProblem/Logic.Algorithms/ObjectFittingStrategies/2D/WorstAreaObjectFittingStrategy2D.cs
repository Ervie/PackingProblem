using Logic.Domain.Containers._2D;
using Logic.Domain.Objects;

namespace Logic.Algorithms.ObjectFittingStrategies._2D
{
	public class WorstAreaObjectFittingStrategy2D : AbstractFittingStrategy2D
	{
		public override double CalculateFittingQuality(Object2D objectToPlace, SubContainer2D subcontainer)
		{
			return (double)objectToPlace.Area / subcontainer.Area;
		}
	}
}