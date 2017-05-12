using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain.Containers._2D;
using Logic.Domain.Objects;
using Logic.Domain;
using Logic.Domain.Containers._2D.Shelf;
using Logic.Utilities.Extensions;

namespace Logic.Algorithms.Implementations._2D.Shelf
{
	public abstract class AbstractBestFitShelf2DAlgorithm : AbstractShelf2DAlgorithm
	{
		public AbstractBestFitShelf2DAlgorithm(Container2D initialContainer) : base(initialContainer)
		{
		}

		public override void Execute(ObjectSet originalObjects)
		{
			double bestFitResult = Double.MaxValue;
			int bestFitContainerIndex = 0;
			int bestFitShelfIndex = 0;

			Position2D positionToPlace = null;

			ShelfContainer2D selectedContainer = containers.First() as ShelfContainer2D;

			selectedContainer.AddShelf();

			ShelfSubContainer2D selectedShelf = selectedContainer.TopShelf as ShelfSubContainer2D;

			var objectsCopy = originalObjects.ToObjectList();

			while (objectsCopy.Any())
			{
				Object2D selectedObject = objectsCopy.First() as Object2D;

				for (int i = 0; i < containers.Count(); i++)
				{
					selectedContainer = containers[i] as ShelfContainer2D;

					for (int j = 0; j < selectedContainer.Subcontainers.Count(); j++)
					{
						selectedShelf = selectedContainer.Subcontainers[j] as ShelfSubContainer2D;

						var localFitResult = CalculateFitResult(selectedObject, selectedContainer.Width - selectedShelf.LastPlacedObject.X2,
							selectedShelf.Y, selectedShelf.Height, selectedContainer.Width, selectedContainer.Height);
						if (localFitResult < bestFitResult)
						{
							bestFitResult = localFitResult;
							bestFitContainerIndex = i;
							bestFitShelfIndex = j;
						}
					}
				}

				if (bestFitResult == Double.MaxValue)
				{
					if (selectedObject.Height + selectedContainer.TopShelf.Y < selectedContainer.Height)
					{
						selectedContainer.AddShelf();

						selectedShelf = selectedContainer.TopShelf as ShelfSubContainer2D;
					}
					else
					{
						AddContainer();
						(containers.Last() as ShelfContainer2D).AddShelf();

						selectedContainer = containers.Last() as ShelfContainer2D;
						selectedShelf = selectedContainer.TopShelf as ShelfSubContainer2D;
					}
				}
				else
				{
					selectedContainer = containers[bestFitContainerIndex] as ShelfContainer2D;
					selectedShelf = selectedContainer.Subcontainers[bestFitShelfIndex] as ShelfSubContainer2D;
				}

				positionToPlace = new Position2D(selectedShelf.LastPlacedObject.X2, selectedShelf.Y);

				objectsCopy.Remove(selectedObject);
				selectedShelf.LastPlacedObject = selectedContainer.PlaceObject(selectedObject, positionToPlace) as PlacedObject2D;
				positionToPlace = null;

				bestFitResult = Double.MaxValue;
				bestFitContainerIndex = 0;
				bestFitShelfIndex = 0;
			}
		}

		protected abstract double CalculateFitResult(Object2D objectToPlace, int widthLeftInShelf, int shelfLevel,int shelfHeight, int containerWidth, int ContainerHeight);
	}
}
