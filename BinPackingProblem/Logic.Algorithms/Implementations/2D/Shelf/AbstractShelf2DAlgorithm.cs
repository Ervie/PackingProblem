using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain.Containers._2D;
using Logic.Domain.Containers._2D.Shelf;

namespace Logic.Algorithms.Implementations._2D.Shelf
{
	public abstract class AbstractShelf2DAlgorithm : Algorithm2D
	{
		public AbstractShelf2DAlgorithm(Container2D initialContainer) : base(initialContainer)
		{
			containers = new List<Container2D>();

			containers.Add(new ShelfContainer2D(initialContainer.Width, initialContainer.Height));
		}

		public override void AddContainer()
		{
			if (containers != null)
				containers.Add(new ShelfContainer2D(containers.First().Width, containers.First().Height));
		}
	}
}
