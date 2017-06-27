using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain.Containers._3D;
using Logic.Domain.Objects;
using Logic.Domain;
using Logic.Domain.Containers._3D.Shelf;
using Logic.Utilities.Extensions;

namespace Logic.Algorithms.Implementations._3D.Shelf
{
	public sealed class NextFitShelf3DAlgorithm : AbstractShelf3DAlgorithm
	{
		public NextFitShelf3DAlgorithm(Container3D initialContainer) : base(initialContainer)
		{
		}

		public override void Execute(ObjectSet originalObjects)
		{
			Position3D positionToPlace;

			ShelfContainer3D selectedContainer = containers.Last() as ShelfContainer3D;

			ShelfSubContainer3D selectedShelf = selectedContainer.TopShelf as ShelfSubContainer3D;

			var objectsCopy = originalObjects.ToObjectList();

			while (objectsCopy.Any())
			{
				Object3D selectedObject = objectsCopy.First() as Object3D;


				// Change Container if object is too depp
				if (selectedObject.Depth + selectedContainer.TopShelf.Z > selectedContainer.Depth)
				{
					AddContainer();

					selectedContainer = containers.Last() as ShelfContainer3D;

					selectedContainer.AddShelf();

					selectedShelf = selectedContainer.TopShelf as ShelfSubContainer3D;
				}
				
				positionToPlace = selectedShelf.TryToFitObject(selectedObject);

				// Change Shelf
				if (positionToPlace == null )
				{
					selectedContainer.AddShelf();

					selectedShelf = selectedContainer.TopShelf as ShelfSubContainer3D;

					positionToPlace = new Position3D(selectedShelf.X, selectedShelf.Y, selectedShelf.Z);
				}
				
				//positionToPlace = new Position3D(selectedShelf.LastPlacedObject.X2, selectedShelf.Y);

				objectsCopy.Remove(selectedObject);
				selectedContainer.PlaceObject(selectedObject, positionToPlace);
			}
		}
	}
}
