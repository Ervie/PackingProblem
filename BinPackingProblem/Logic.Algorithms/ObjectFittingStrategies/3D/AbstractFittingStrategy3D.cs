using Logic.Domain.Containers._3D;
using Logic.Domain.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Algorithms.ObjectFittingStrategies._3D
{
	public abstract class AbstractFittingStrategy3D : IObjectFittingStrategy<Object3D, SubContainer3D>
	{
		public abstract double CalculateFittingQuality(Object3D objectToPlace, SubContainer3D subcontainer);

		public bool ValidateObjectPlacement(Object3D objectToPlace, SubContainer3D subcontainer)
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
			// Object too deep for subcontainer
			if (objectToPlace.Depth > subcontainer.Depth)
			{
				return false;
			}

			return true;
		}
	}
}
