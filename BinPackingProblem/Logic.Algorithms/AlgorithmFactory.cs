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
using Logic.Algorithms.Implementations._2D.Skyline;

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
				case (AlgorithmFamily.Skyline):
					return Create2DSkylineAlgorithm(properties.AlgorithmType, initialContainer);
				case (AlgorithmFamily.GuillotineCut):
					return Create2DGuillotineAlgorithm(properties.AlgorithmType, properties.SplittingStrategy, initialContainer);
				default:
					throw new NotSuchAlgorithmException();
			}
		}

		private IAlgorithm Create3DAlgorithm(AlgorithmProperties properties, Container3D initialContainer)
		{
			throw new NotImplementedException();
		}
		
		private IAlgorithm Create2DSkylineAlgorithm(ObjectFittingStrategy fittingStrategy, Container2D initialContainer)
		{
			switch (fittingStrategy)
			{
				case (ObjectFittingStrategy.BestFitFirstContainer):
					return new BestFitFirstContainerSkyline2DAlgorithm(initialContainer);
				case (ObjectFittingStrategy.BestFitBestContainer):
					return new BestFitBestContainerSkyline2DAlgorithm(initialContainer);
				case (ObjectFittingStrategy.BottomLeft):
					return new BottomLeftSkyline2DAlgorithm(initialContainer);
				default:
					throw new NotSuchAlgorithmException();
			}
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
					return new BestFitWidthShelf2DAlgorithm(initialContainer);
				case (ObjectFittingStrategy.BestHeightFit):
					return new BestFitHeightShelf2DAlgorithm(initialContainer);
				case (ObjectFittingStrategy.BestAreaFit):
					return new BestFitAreaShelf2DAlgorithm(initialContainer);
				case (ObjectFittingStrategy.WorstAreaFit):
					return new WorstFitAreaShelf2DAlgorithm(initialContainer);
				case (ObjectFittingStrategy.WorstWidthFit):
					return new WorstFitWidthShelf2DAlgorithm(initialContainer);
				default:
					throw new NotSuchAlgorithmException();
			}
		}

		private IAlgorithm Create2DGuillotineAlgorithm(ObjectFittingStrategy fittingStrategy, ContainerSplittingStrategy splittingStrategy, Container2D initialContainer)
		{
			throw new NotImplementedException();
		}

	}
}
