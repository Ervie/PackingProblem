using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain.Containers._2D;
using Logic.Domain.Objects;

namespace Logic.Algorithms.Implementations._2D.Shelf
{
	class BestFitHeightShelf2DAlgorithm : AbstractBestFitShelf2DAlgorithm
	{
		public BestFitHeightShelf2DAlgorithm(Container2D initialContainer) : base(initialContainer)
		{
		}

		protected override double CalculateFitResult(Object2D objectToPlace, int widthLeftInShelf, int shelfLevel, int shelfHeight, int containerWidth, int ContainerHeight)
		{
			if (objectToPlace.Height + shelfLevel > ContainerHeight)
				return Double.MaxValue;
			else if (objectToPlace.Height > shelfHeight && shelfHeight != 0)
				return Double.MaxValue;
			else if (objectToPlace.Width > widthLeftInShelf)
				return Double.MaxValue;
			else
				return Math.Max(shelfHeight - objectToPlace.Height, 0);
		}
	}
}
