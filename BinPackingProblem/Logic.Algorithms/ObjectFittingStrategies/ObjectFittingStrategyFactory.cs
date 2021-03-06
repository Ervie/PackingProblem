﻿using System;
using Logic.Algorithms.Enums;
using Logic.Algorithms.Exceptions;
using Logic.Algorithms.ObjectFittingStrategies._2D;
using Logic.Domain.Containers._2D;
using Logic.Domain.Containers._3D;
using Logic.Domain.Objects;
using Logic.Algorithms.ObjectFittingStrategies._3D;

namespace Logic.Algorithms.ObjectFittingStrategies
{
	public class ObjectFittingStrategyFactory : IObjectFittingStrategyFactory
	{
		public IObjectFittingStrategy<Object2D, SubContainer2D> Create2D(ObjectFittingStrategy objectFittingStrategy)
		{
			switch (objectFittingStrategy)
			{
				case (ObjectFittingStrategy.BestAreaFit):
					return new BestAreaObjectFittingStrategy2D();

				case (ObjectFittingStrategy.WorstAreaFit):
					return new WorstAreaObjectFittingStrategy2D();

				case (ObjectFittingStrategy.BestLongSideFit):
					return new BestLongSideObjectFittingStrategy2D();

				case (ObjectFittingStrategy.BestShortSideFit):
					return new BestShortSideObjectFittingStrategy2D();

				case (ObjectFittingStrategy.WorstLongSideFit):
					return new WorstLongSideObjectFittingStrategy2D();

				case (ObjectFittingStrategy.WorstShortSideFit):
					return new WorstShortSideObjectFittingStrategy2D();

				case (ObjectFittingStrategy.BottomLeft):
					return new BottomLeftObjectFittingStrategy2D();

				default:
					throw new NotSuchAlgorithmException();
			}
		}

		public IObjectFittingStrategy<Object3D, SubContainer3D> Create3D(ObjectFittingStrategy objectFittingStrategy)
		{
			switch (objectFittingStrategy)
			{
				case (ObjectFittingStrategy.BestVolumeFit):
					return new BestVolumeObjectFittingStrategy3D();

				case (ObjectFittingStrategy.WorstVolumeFit):
					return new WorstVolumeObjectFittingStrategy3D();

				case (ObjectFittingStrategy.BestLongSideFit):
					return new BestLongSideObjectFittingStrategy3D();

				case (ObjectFittingStrategy.BestShortSideFit):
					return new BestShortSideObjectFittingStrategy3D();

				case (ObjectFittingStrategy.WorstLongSideFit):
					return new WorstLongSideObjectFittingStrategy3D();

				case (ObjectFittingStrategy.WorstShortSideFit):
					return new WorstShortSideObjectFittingStrategy3D();

				default:
					throw new NotSuchAlgorithmException();
			}
		}
	}
}