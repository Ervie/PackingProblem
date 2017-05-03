using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain.Containers._2D;

namespace Logic.Algorithms.Implementations._2D.Shelf
{
	public abstract class AbstractShelf2DAlgorithm : Algorithm2D
	{
		public AbstractShelf2DAlgorithm(Container2D initialContainer) : base(initialContainer)
		{
		}
	}
}
