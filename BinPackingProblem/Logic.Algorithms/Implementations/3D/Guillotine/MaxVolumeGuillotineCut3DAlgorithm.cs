using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Algorithms.ObjectFittingStrategies._3D;
using Logic.Domain.Containers._3D;
using Logic.Domain.Containers._2D.Guillotine;
using Logic.Domain.Containers._3D.Guillotine;

namespace Logic.Algorithms.Implementations._3D.Guillotine
{
	public class MaxVolumeGuillotineCut3DAlgorithm : AbstractGuillotineCut3DAlgorithm
	{
		public MaxVolumeGuillotineCut3DAlgorithm(Container3D initialContainer, AbstractFittingStrategy3D strategy) : base(initialContainer, strategy)
		{
			containers = new List<Container3D>();

			containers.Add(new GuillotineCutMaxVolumeContainer3D(initialContainer.Width, initialContainer.Height, initialContainer.Depth));
		}

		public override void AddContainer()
		{
			if (containers != null)
				containers.Add(new GuillotineCutMaxVolumeContainer3D(containers.First().Width, containers.First().Height, containers.First().Depth));
		}
	}
}
