using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain.Containers._2D;
using Logic.Domain.Objects;

namespace Logic.Algorithms.Implementations._2D.Shelf
{
	public sealed class FirstFitShelf2DAlgorithm : AbstractShelf2DAlgorithm
	{
		public FirstFitShelf2DAlgorithm(Container2D initialContainer) : base(initialContainer)
		{
		}

		public override void Execute(ObjectSet originalObjects)
		{
			Container2D selectedContainer = containers.First();


		}
	}
}
