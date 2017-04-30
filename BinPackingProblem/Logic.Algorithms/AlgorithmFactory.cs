using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Algorithms.Structs;
using Logic.Algorithms.Enums;
using Logic.Algorithms.Exceptions;

namespace Logic.Algorithms
{
	class AlgorithmFactory : IAlgorithmFactory
	{
		public IAlgorithm Create(AlgorithmProperties properties)
		{
			switch(properties.Dimensionality)
			{
				case (AlgorithmDimensionality.TwoDimensional):
					return Create2DAlgorithm(properties);
				case (AlgorithmDimensionality.ThreeDimensional):
					return Create3DAlgorithm(properties);
				default:
					throw new NotSuchAlgorithmException();
			}
		}


		private IAlgorithm Create2DAlgorithm(AlgorithmProperties properties)
		{
			switch (properties.Family)
			{
				case (AlgorithmFamily.Shelf):
					return Create2DShelfAlgorithm(properties.FittingStrategy);
				default:
					throw new NotSuchAlgorithmException();
			}
		}

		private IAlgorithm Create3DAlgorithm(AlgorithmProperties properties)
		{
			throw new NotImplementedException();
		}

		
		private IAlgorithm Create2DShelfAlgorithm(ObjectFittingStrategy fittingStrategy)
		{
			switch (fittingStrategy)
			{
				case (ObjectFittingStrategy.FirstFit):
					throw new NotSuchAlgorithmException();
				case (ObjectFittingStrategy.NextFit):
					throw new NotSuchAlgorithmException();
				case (ObjectFittingStrategy.BestWidthFit):
					throw new NotSuchAlgorithmException();
				case (ObjectFittingStrategy.BestHeightFit):
					throw new NotSuchAlgorithmException();
				case (ObjectFittingStrategy.BestAreaFit):
					throw new NotSuchAlgorithmException();
				default:
					throw new NotSuchAlgorithmException();
			}
		}
	}
}
