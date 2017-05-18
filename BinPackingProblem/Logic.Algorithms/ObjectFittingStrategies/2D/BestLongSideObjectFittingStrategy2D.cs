using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain.Containers._2D;
using Logic.Domain.Objects;

namespace Logic.Algorithms.ObjectFittingStrategies._2D
{
	public class BestLongSideObjectFittingStrategy2D : AbstractFittingStrategy2D
	{
		public override double CalculateFittingQuality(Object2D objectToPlace, SubContainer2D subcontainer)
		{
			return Math.Max(subcontainer.Width - objectToPlace.Width, subcontainer.Height - objectToPlace.Height);
		}
	}
}
