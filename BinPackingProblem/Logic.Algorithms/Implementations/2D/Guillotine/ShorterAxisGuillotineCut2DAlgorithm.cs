using Logic.Algorithms.ObjectFittingStrategies._2D;
using Logic.Domain.Containers._2D;
using Logic.Domain.Containers._2D.Guillotine;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Logic.Algorithms.Implementations._2D.Guillotine
{
	public class ShorterAxisGuillotineCut2DAlgorithm : AbstractGuillotineCut2DAlgorithm
	{
		public ShorterAxisGuillotineCut2DAlgorithm(Container2D initialContainer, AbstractFittingStrategy2D strategy) : base(initialContainer, strategy)
		{
			containers = new List<Container2D>();

			containers.Add(new GuillotineCutShorterAxisContainer2D(initialContainer.Width, initialContainer.Height));
		}

		public override void AddContainer()
		{
			if (containers != null)
				containers.Add(new GuillotineCutShorterAxisContainer2D(containers.First().Width, containers.First().Height));
		}
	}
}
