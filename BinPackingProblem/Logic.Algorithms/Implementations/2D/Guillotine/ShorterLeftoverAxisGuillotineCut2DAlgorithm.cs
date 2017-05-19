using Logic.Algorithms.ObjectFittingStrategies._2D;
using Logic.Domain.Containers._2D;
using Logic.Domain.Containers._2D.Guillotine;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Logic.Algorithms.Implementations._2D.Guillotine
{
	public class ShorterLeftoverAxisGuillotineCut2DAlgorithm : AbstractGuillotineCut2DAlgorithm
	{
		public ShorterLeftoverAxisGuillotineCut2DAlgorithm(Container2D initialContainer, AbstractFittingStrategy2D strategy) : base(initialContainer, strategy)
		{
			containers = new List<Container2D>();

			containers.Add(new GuillotineCutShorterLeftoverAxisContainer2D(initialContainer.Width, initialContainer.Height));
		}

		public override void AddContainer()
		{
			if (containers != null)
				containers.Add(new GuillotineCutShorterLeftoverAxisContainer2D(containers.First().Width, containers.First().Height));
		}
	}
}
