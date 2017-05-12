using Logic.Domain;
using Logic.Domain.Containers._2D;
using Logic.Domain.Containers._2D.Shelf;
using Logic.Domain.Objects;
using Logic.Utilities.Extensions;
using System.Linq;

namespace Logic.Algorithms.Implementations._2D.Shelf
{
	public sealed class FirstFitShelf2DAlgorithm : AbstractShelf2DAlgorithm
	{
		public FirstFitShelf2DAlgorithm(Container2D initialContainer) : base(initialContainer)
		{
		}

		public override void Execute(ObjectSet originalObjects)
		{
			Position2D positionToPlace = null;

			ShelfContainer2D selectedContainer = containers.First() as ShelfContainer2D;

			selectedContainer.AddShelf();

			ShelfSubContainer2D selectedShelf = selectedContainer.TopShelf as ShelfSubContainer2D;

			var objectsCopy = originalObjects.ToObjectList();

			while (objectsCopy.Any())
			{
				Object2D selectedObject = objectsCopy.First() as Object2D;
				
				for (int i = 0; positionToPlace == null; i++)
				{
					selectedContainer = containers[i] as ShelfContainer2D;

					for (int j = 0; positionToPlace == null; j++)
					{

						selectedShelf = selectedContainer.Subcontainers[j] as ShelfSubContainer2D;

						if (selectedObject.Width + selectedShelf.LastPlacedObject.X2 <= selectedContainer.Width &&
							((j == selectedContainer.Subcontainers.Count - 1 && selectedObject.Height + selectedShelf.Y2 <= selectedContainer.Height) ||
							j != selectedContainer.Subcontainers.Count - 1 && selectedObject.Height < selectedShelf.Height))
						{
							positionToPlace = new Position2D(selectedShelf.LastPlacedObject.X2, selectedShelf.Y);
						}
						else if (selectedObject.Height + selectedShelf.Y2 > selectedContainer.Height && i == containers.Count - 1 && j == selectedContainer.Subcontainers.Count - 1)
						{
							AddContainer();
							(containers.Last() as ShelfContainer2D).AddShelf();
							break;
						}
						else if (selectedObject.Height + selectedShelf.Y2 > selectedContainer.Height && j == selectedContainer.Subcontainers.Count - 1)
							break;
						else if (selectedObject.Width + selectedShelf.LastPlacedObject.X2 > selectedContainer.Width && j == selectedContainer.Subcontainers.Count - 1)
							selectedContainer.AddShelf();

					}
				}

				objectsCopy.Remove(selectedObject);
				selectedShelf.LastPlacedObject = selectedContainer.PlaceObject(selectedObject, positionToPlace) as PlacedObject2D;
				positionToPlace = null;
			}
		}
	}
}