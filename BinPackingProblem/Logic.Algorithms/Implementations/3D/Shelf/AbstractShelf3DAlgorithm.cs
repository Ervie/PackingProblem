using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain.Containers._3D;
using Logic.Domain.Containers._3D.Shelf;

namespace Logic.Algorithms.Implementations._3D.Shelf
{
	public abstract class AbstractShelf3DAlgorithm : Algorithm3D
	{
		public AbstractShelf3DAlgorithm(Container3D initialContainer) : base(initialContainer)
		{
			containers = new List<Container3D>();

			containers.Add(new ShelfContainer3D(initialContainer.Width, initialContainer.Height, initialContainer.Depth));
		}

		public override void AddContainer()
		{
			if (containers != null)
				containers.Add(new ShelfContainer3D(containers.First().Width, containers.First().Height, containers.First().Depth));
		}
	}
}
