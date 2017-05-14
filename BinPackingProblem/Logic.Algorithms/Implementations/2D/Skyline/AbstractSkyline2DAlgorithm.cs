using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain.Containers._2D;
using Logic.Domain.Objects;
using Logic.Domain.Containers._2D.Skyline;

namespace Logic.Algorithms.Implementations._2D.Skyline
{
	public abstract class AbstractSkyline2DAlgorithm : Algorithm2D
	{
		public AbstractSkyline2DAlgorithm(Container2D initialContainer) : base(initialContainer)
		{
			containers = new List<Container2D>();

			containers.Add(new SkylineContainer2D(initialContainer.Width, initialContainer.Height));
		}

		public override void AddContainer()
		{
			if (containers != null)
				containers.Add(new SkylineContainer2D(containers.First().Width, containers.First().Height));
		}
	}
}
