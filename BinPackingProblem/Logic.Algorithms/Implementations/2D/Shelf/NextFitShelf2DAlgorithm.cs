using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain.Containers._2D;
using Logic.Domain.Objects;
using Logic.Domain.Containers._2D.Shelf;
using Logic.Utilities.Extensions;
using Logic.Domain;

namespace Logic.Algorithms.Implementations._2D.Shelf
{
	public sealed class NextFitShelf2DAlgorithm : AbstractShelf2DAlgorithm
	{
		public NextFitShelf2DAlgorithm(Container2D initialContainer) : base(initialContainer)
		{
		}

		public override void Execute(ObjectSet originalObjects)
		{
			Position2D positionToPlace;

			ShelfContainer2D selectedContainer = containers.Last() as ShelfContainer2D;

			selectedContainer.AddShelf();

			ShelfSubContainer2D selectedShelf =  selectedContainer.TopShelf as ShelfSubContainer2D;

			var objectsCopy = originalObjects.ToObjectList();
			
			while (objectsCopy.Any())
			{
				Object2D selectedObject = objectsCopy.First() as Object2D;
				
				// Change Shelf
				if (selectedObject.Width + selectedShelf.LastPlacedObject.X2 > selectedContainer.Width)
				{
					selectedContainer.AddShelf();

					selectedShelf = selectedContainer.TopShelf as ShelfSubContainer2D;
				}

				// Change Container
				if (selectedObject.Height + selectedContainer.TopShelf.Y > selectedContainer.Height)
				{
					AddContainer();

					selectedContainer = containers.Last() as ShelfContainer2D;

					selectedContainer.AddShelf();

					selectedShelf = selectedContainer.TopShelf as ShelfSubContainer2D;
				}

				positionToPlace = new Position2D(selectedShelf.LastPlacedObject.X2, selectedShelf.Y);

				objectsCopy.Remove(selectedObject);
				selectedShelf.LastPlacedObject = selectedContainer.PlaceObject(selectedObject, positionToPlace) as PlacedObject2D;
			
			}
		}
	}
}
