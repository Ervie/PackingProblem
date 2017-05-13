using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain.Containers._2D;
using Logic.Domain.Objects;

namespace Logic.Algorithms.Implementations._2D.Shelf
{
	public class WorstFitAreaShelf2DAlgorithm : AbstractBestFitShelf2DAlgorithm
	{
		public WorstFitAreaShelf2DAlgorithm(Container2D initialContainer) : base(initialContainer)
		{
		}

		protected override double CalculateFitResult(Object2D objectToPlace, int widthLeftInShelf, int shelfLevel, int shelfHeight, int containerWidth, int ContainerHeight)
		{
			// Don't fit (container height)
			if (objectToPlace.Height + shelfLevel > ContainerHeight)
				return Double.MaxValue;
			// Don't fit (shelf height)
			else if (objectToPlace.Height > shelfHeight && shelfHeight != 0)
				return Double.MaxValue;
			// Don't fit (width)
			else if (objectToPlace.Width > widthLeftInShelf)
				return Double.MaxValue;
			else
			{
				int availableArea, availableHeight;

				if (shelfHeight == 0)
					availableHeight = ContainerHeight - shelfLevel;
				else
					availableHeight = shelfHeight;

				availableArea = availableHeight * widthLeftInShelf;

				return (double)(1/(availableArea / objectToPlace.Area));
			}
		}
	}
}
