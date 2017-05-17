using Logic.Domain.Containers._2D;
using Logic.Domain.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Algorithms.ObjectFittingStrategies._2D
{
	public abstract class AbstractFittingStrategy2D : IObjectFittingStrategy<Object2D, SubContainer2D>
	{
		public abstract double CalculateFittingQuality(Object2D objectToPlace, SubContainer2D subcontainer);

		public bool ValidateObjectPlacement(Object2D objectToPlace, SubContainer2D subcontainer)
		{
			// Object too high for subcontainer
			if (objectToPlace.Height > subcontainer.Height)
			{
				return false;
			}
			// Object too wide for subcontainer
			if (objectToPlace.Width > subcontainer.Width)
			{
				return false;
			}

			return true;
		}
	}
}
