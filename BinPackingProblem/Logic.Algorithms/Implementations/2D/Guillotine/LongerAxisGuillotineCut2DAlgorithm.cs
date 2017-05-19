using Logic.Algorithms.ObjectFittingStrategies._2D;
using Logic.Domain.Containers._2D;
using Logic.Domain.Containers._2D.Guillotine;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Algorithms.Implementations._2D.Guillotine
{
	public class LongerAxisGuillotineCut2DAlgorithm : AbstractGuillotineCut2DAlgorithm
	{
		public LongerAxisGuillotineCut2DAlgorithm(Container2D initialContainer, AbstractFittingStrategy2D strategy) : base(initialContainer, strategy)
		{
			containers = new List<Container2D>();

			containers.Add(new GuillotineCutLongerAxisContainer2D(initialContainer.Width, initialContainer.Height));
		}

		public override void AddContainer()
		{
			if (containers != null)
				containers.Add(new GuillotineCutLongerAxisContainer2D(containers.First().Width, containers.First().Height));
		}
	}
}