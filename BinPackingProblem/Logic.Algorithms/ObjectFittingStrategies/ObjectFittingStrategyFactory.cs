using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Algorithms.Enums;
using Logic.Domain.Objects;
using Logic.Algorithms.Exceptions;
using Logic.Algorithms.ObjectFittingStrategies._2D;
using Logic.Domain.Containers._2D;

namespace Logic.Algorithms.ObjectFittingStrategies
{
	public class ObjectFittingStrategyFactory : IObjectFittingStrategyFactory
	{
		public IObjectFittingStrategy<Object2D, SubContainer2D> Create(ObjectFittingStrategy objectFittingStrategy)
		{
			switch (objectFittingStrategy)
			{
				case (ObjectFittingStrategy.BestAreaFit):
					return new BestAreaObjectFittingStrategy2D();

				default:
					throw new NotSuchAlgorithmException();
			}
		}
	}
}
