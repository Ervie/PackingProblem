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
	public sealed class FirstFitShelf3DAlgorithm : AbstractShelf3DAlgorithm
	{
		public FirstFitShelf3DAlgorithm(Container3D initialContainer) : base(initialContainer)
		{
		}

		public override void Execute(ObjectSet originalObjects)
		{
			Position3D positionToPlace = null;

			ShelfContainer3D selectedContainer = containers.Last() as ShelfContainer3D;

			selectedContainer.AddShelf();

			ShelfSubContainer3D selectedShelf = selectedContainer.TopShelf as ShelfSubContainer3D;

			var objectsCopy = originalObjects.ToObjectList();

			while (objectsCopy.Any())
			{
				Object3D selectedObject = objectsCopy.First() as Object3D;
				
				for (int i = 0; positionToPlace == null; i++)
				{
					selectedContainer = containers[i] as ShelfContainer3D;

					for (int j = 0; positionToPlace == null; j++)
					{
						selectedShelf = selectedContainer.Subcontainers[j] as ShelfSubContainer3D;

						//positionToPlace = selectedShelf.TryToFitObject(selectedObject);

						if ((j == selectedContainer.Subcontainers.Count - 1 && selectedObject.Depth + selectedShelf.Z <= selectedContainer.Depth) ||
						(j != selectedContainer.Subcontainers.Count - 1 && selectedObject.Depth < selectedShelf.Depth))
						{
							positionToPlace = selectedShelf.TryToFitObject(selectedObject);
						}
						if (positionToPlace == null)
						{ 
							if (selectedObject.Depth + selectedShelf.Z > selectedContainer.Depth && i == containers.Count - 1 && j == selectedContainer.Subcontainers.Count - 1)
							{
								AddContainer();
								(containers.Last() as ShelfContainer3D).AddShelf();
								break;
							}
							else if (selectedObject.Depth + selectedShelf.Z > selectedContainer.Depth && j == selectedContainer.Subcontainers.Count - 1)
								break;
							else if (j == selectedContainer.Subcontainers.Count - 1)
							{
								positionToPlace = selectedShelf.TryToFitObject(selectedObject);
								if (positionToPlace == null)
									selectedContainer.AddShelf();
							}
						}

					}
				}

				objectsCopy.Remove(selectedObject);
				selectedContainer.PlaceObject(selectedObject, positionToPlace);
				positionToPlace = null;
			}
		}
	}
	
}
