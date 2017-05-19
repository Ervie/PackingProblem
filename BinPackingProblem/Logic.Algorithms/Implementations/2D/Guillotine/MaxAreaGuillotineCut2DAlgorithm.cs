using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Algorithms.ObjectFittingStrategies._2D;
using Logic.Domain.Containers._2D;
using Logic.Domain.Containers._2D.Guillotine;

namespace Logic.Algorithms.Implementations._2D.Guillotine
{
	public class MaxAreaGuillotineCut2DAlgorithm : AbstractGuillotineCut2DAlgorithm
	{
		public MaxAreaGuillotineCut2DAlgorithm(Container2D initialContainer, AbstractFittingStrategy2D strategy) : base(initialContainer, strategy)
		{
			containers = new List<Container2D>();

			containers.Add(new GuillotineCutMaxAreaContainer2D(initialContainer.Width, initialContainer.Height));
		}

		public override void AddContainer()
		{
			if (containers != null)
				containers.Add(new GuillotineCutMaxAreaContainer2D(containers.First().Width, containers.First().Height));
		}
	}
}
