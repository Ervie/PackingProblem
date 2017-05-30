using Logic.Algorithms.Enums;
using Logic.Algorithms.Exceptions;
using Logic.Algorithms.Structs;
using Logic.Domain.Containers._2D;
using Logic.Domain.Containers._2D.Guillotine;
using Logic.Domain.Containers._2D.Shelf;
using Logic.Domain.Containers._2D.Skyline;
using Logic.Domain.Containers._3D;
using System;

namespace Logic.Algorithms.Containers
{
	public class ContainerFactory : IContainerFactory
	{
		public Container2D Create(AlgorithmProperties properties, int Width, int Height)
		{
			if (properties.Dimensionality != AlgorithmDimensionality.TwoDimensional)
				throw new NotSuchAlgorithmException();

			switch (properties.Family)
			{
				case (AlgorithmFamily.Shelf):
					return new ShelfContainer2D(Width, Height);

				case (AlgorithmFamily.Skyline):
					return new SkylineContainer2D(Width, Height);

				case (AlgorithmFamily.GuillotineCut):
					return Create2DGuillotineCutContainer(properties, Width, Height);

				default:
					throw new NotSuchAlgorithmException();
			}
		}

		private Container2D Create2DGuillotineCutContainer(AlgorithmProperties properties, int width, int height)
		{
			switch (properties.SplittingStrategy)
			{
				case (ContainerSplittingStrategy.MaxAreaSplitRule):
					return new GuillotineCutMaxAreaContainer2D(width, height);

				case (ContainerSplittingStrategy.MinAreaSplitRule):
					return new GuillotineCutMinAreaContainer2D(width, height);

				case (ContainerSplittingStrategy.LongerAxisSplitRule):
					return new GuillotineCutLongerAxisContainer2D(width, height);

				case (ContainerSplittingStrategy.LongerLeftoverAxisSplitRule):
					return new GuillotineCutLongerLeftoverAxisContainer2D(width, height);

				case (ContainerSplittingStrategy.ShorterAxisSplitRule):
					return new GuillotineCutShorterAxisContainer2D(width, height);

				case (ContainerSplittingStrategy.ShorterLeftoverAxisSplitRule):
					return new GuillotineCutShorterLeftoverAxisContainer2D(width, height);

				default:
					throw new NotSuchAlgorithmException();
			}
		}

		public Container3D Create(AlgorithmProperties properties, int Width, int Height, int Depth)
		{
			throw new NotImplementedException();
		}
	}
}