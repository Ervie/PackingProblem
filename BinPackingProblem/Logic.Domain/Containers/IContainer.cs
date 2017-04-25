using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain.Containers
{
	public interface IContainer<T, D> where T: Logic.Domain.Objects.Object where D: Logic.Domain.IPosition
	{
		void PlaceObject(T objectToPlace, D position);
	}
}
