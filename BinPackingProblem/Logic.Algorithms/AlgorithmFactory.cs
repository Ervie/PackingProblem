using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Algorithms.Structs;
using Logic.Algorithms.Enums;
using Logic.Algorithms.Exceptions;
using Logic.Algorithms.Implementations._2D.Shelf;
using Logic.Domain.Figures;
using Logic.Domain.Containers._2D;
using Logic.Domain.Containers._3D;

namespace Logic.Algorithms
{
	public class AlgorithmFactory : IAlgorithmFactory
	{
		public IAlgorithm Create(AlgorithmProperties properties, IFigure size)
		{
			switch(properties.Dimensionality)
			{
				case (AlgorithmDimensionality.TwoDimensional):
					return Create2DAlgorithm(properties, size as Container2D);
				case (AlgorithmDimensionality.ThreeDimensional):
					return Create3DAlgorithm(properties, size as Container3D);
				default:
					throw new NotSuchAlgorithmException();
			}
		}


		private IAlgorithm Create2DAlgorithm(AlgorithmProperties properties, Container2D initialContainer)
		{
			switch (properties.Family)
			{
				case (AlgorithmFamily.Shelf):
					return Create2DShelfAlgorithm(properties.AlgorithmType, initialContainer);
				default:
					throw new NotSuchAlgorithmException();
			}
		}

		private IAlgorithm Create3DAlgorithm(AlgorithmProperties properties, Container3D initialContainer)
		{
			throw new NotImplementedException();
		}

		
		private IAlgorithm Create2DShelfAlgorithm(ObjectFittingStrategy fittingStrategy, Container2D initialContainer)
		{
			switch (fittingStrategy)
			{
				case (ObjectFittingStrategy.FirstFit):
					return new FirstFitShelf2DAlgorithm(initialContainer);
				case (ObjectFittingStrategy.NextFit):
					return new NextFitShelf2DAlgorithm(initialContainer);
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
