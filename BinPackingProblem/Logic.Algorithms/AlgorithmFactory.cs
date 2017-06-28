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
using Logic.Algorithms.Implementations._2D.Guillotine;
using Logic.Algorithms.ObjectFittingStrategies;
using Logic.Algorithms.ObjectFittingStrategies._2D;
using Logic.Algorithms.ObjectFittingStrategies._3D;
using Logic.Algorithms.Implementations._3D.Guillotine;
using Logic.Algorithms.Implementations._3D.Shelf;

namespace Logic.Algorithms
{
	public class AlgorithmFactory : IAlgorithmFactory
	{
		public IObjectFittingStrategyFactory objectFittingStrategyFactory { get; set; }

		public AlgorithmFactory()
		{
			objectFittingStrategyFactory = new ObjectFittingStrategyFactory();
		}

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
			switch (properties.Family)
			{
				case (AlgorithmFamily.Shelf):
					return Create3DShelfAlgorithm(properties.AlgorithmType, initialContainer);
				case (AlgorithmFamily.GuillotineCut):
					return Create3DGuillotineAlgorithm(properties.AlgorithmType, properties.SplittingStrategy, initialContainer);
				default:
					throw new NotSuchAlgorithmException();
			}
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
			var strategyInstance = objectFittingStrategyFactory.Create2D(fittingStrategy) as AbstractFittingStrategy2D;

			switch (splittingStrategy)
			{
				case (ContainerSplittingStrategy.MinAreaSplitRule):
					return new MinAreaGuillotineCut2DAlgorithm(initialContainer, strategyInstance);
				case (ContainerSplittingStrategy.MaxAreaSplitRule):
					return new MaxAreaGuillotineCut2DAlgorithm(initialContainer, strategyInstance);
				case (ContainerSplittingStrategy.LongerAxisSplitRule):
					return new LongerAxisGuillotineCut2DAlgorithm(initialContainer, strategyInstance);
				case (ContainerSplittingStrategy.LongerLeftoverAxisSplitRule):
					return new LongerLeftoverAxisGullotineCut2DAlgorithm(initialContainer, strategyInstance);
				case (ContainerSplittingStrategy.ShorterAxisSplitRule):
					return new ShorterAxisGuillotineCut2DAlgorithm(initialContainer, strategyInstance);
				case (ContainerSplittingStrategy.ShorterLeftoverAxisSplitRule):
					return new ShorterLeftoverAxisGuillotineCut2DAlgorithm(initialContainer, strategyInstance);

				default:
					throw new NotSuchAlgorithmException();
			}
		}
		
		private IAlgorithm Create3DGuillotineAlgorithm(ObjectFittingStrategy fittingStrategy, ContainerSplittingStrategy splittingStrategy, Container3D initialContainer)
		{
			var strategyInstance = objectFittingStrategyFactory.Create3D(fittingStrategy) as AbstractFittingStrategy3D;

			switch (splittingStrategy)
			{
				case (ContainerSplittingStrategy.MaxVolumeSplitRule):
					return new MaxVolumeGuillotineCut3DAlgorithm(initialContainer, strategyInstance);
				case (ContainerSplittingStrategy.MinVolumeSplitRule):
					return new MinVolumeGuillotineCut3DAlgorithm(initialContainer, strategyInstance);
				case (ContainerSplittingStrategy.LongerAxisSplitRule):
					return new LongerAxisGuillotineCut3DAlgorithm(initialContainer, strategyInstance);
				case (ContainerSplittingStrategy.LongerLeftoverAxisSplitRule):
					return new LongerLeftoverAxisGuillotineCut3DAlgorithm(initialContainer, strategyInstance);
				case (ContainerSplittingStrategy.ShorterAxisSplitRule):
					return new ShorterAxisGuillotineCut3DAlgorithm(initialContainer, strategyInstance);
				case (ContainerSplittingStrategy.ShorterLeftoverAxisSplitRule):
					return new ShorterLeftoverAxisGuillotineCut3DAlgorithm(initialContainer, strategyInstance);

				default:
					throw new NotSuchAlgorithmException();
			}
		}

		private IAlgorithm Create3DShelfAlgorithm(ObjectFittingStrategy fittingStrategy, Container3D initialContainer)
		{
			switch (fittingStrategy)
			{
				case (ObjectFittingStrategy.NextFit):
					return new NextFitShelf3DAlgorithm(initialContainer);
				case (ObjectFittingStrategy.FirstFit):
					return new FirstFitShelf3DAlgorithm(initialContainer);
				default:
					throw new NotSuchAlgorithmException();
			}
		}

	}
}
