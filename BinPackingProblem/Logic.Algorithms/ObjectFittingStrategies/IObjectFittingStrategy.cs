using Logic.Domain.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Algorithms.ObjectFittingStrategies
{
	public interface IObjectFittingStrategy<T, D> where T: Logic.Domain.Objects.Object where D: IPlacedObject
	{
		double CalculateFittingQuality(T objectToPlace, D subcontainer);

		bool ValidateObjectPlacement(T objectToPlace, D subcontainer);
	}
}
