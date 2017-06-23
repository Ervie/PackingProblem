using Logic.Algorithms.ObjectFittingStrategies._3D;
using Logic.Domain.Containers._3D;
using Logic.Domain.Containers._3D.Guillotine;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Algorithms.Implementations._3D.Guillotine
{
	public class LongerLeftoverAxisGuillotineCut3DAlgorithm : AbstractGuillotineCut3DAlgorithm
	{
		public LongerLeftoverAxisGuillotineCut3DAlgorithm(Container3D initialContainer, AbstractFittingStrategy3D strategy) : base(initialContainer, strategy)
		{
			containers = new List<Container3D>();

			containers.Add(new GuillotineCutLongerLeftoverAxisContainer3D(initialContainer.Width, initialContainer.Height, initialContainer.Depth));
		}

		public override void AddContainer()
		{
			if (containers != null)
				containers.Add(new GuillotineCutLongerLeftoverAxisContainer3D(containers.First().Width, containers.First().Height, containers.First().Depth));
		}
	}
}