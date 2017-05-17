using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain.Containers._2D;
using Logic.Domain.Objects;
using Logic.Domain;
using Logic.Domain.Containers._2D.Guillotine;
using Logic.Utilities.Extensions;

namespace Logic.Algorithms.Implementations._2D.Guillotine
{
	public abstract class AbstractGuillotineCut2DAlgorithm : Algorithm2D
	{
		public AbstractGuillotineCut2DAlgorithm(Container2D initialContainer) : base(initialContainer)
		{
		}

		public override void AddContainer()
		{
			throw new NotImplementedException();
		}

		public override void Execute(ObjectSet originalObjects)
		{
			PlacedObject2D newPlacedObject;
			Position2D positionToPlace = null;

			GuillotineCutContainer2D selectedContainer = containers.First() as GuillotineCutContainer2D;

			GuillotineCutSubcontainer2D selectedSubcontainer = selectedContainer.Subcontainers.First() as GuillotineCutSubcontainer2D;

			var objectsCopy = originalObjects.ToObjectList();

			while (objectsCopy.Any())
			{
				Object2D selectedObject = objectsCopy.First() as Object2D;

				// TODO: Outline of Guillotine Cut algorithm

				//for (int i = 0; positionToPlace == null; i++)
				//{
				//	selectedContainer = containers[i] as ShelfContainer2D;

				//	for (int j = 0; positionToPlace == null; j++)
				//	{

				//		selectedShelf = selectedContainer.Subcontainers[j] as ShelfSubContainer2D;

				//		if (selectedObject.Width + selectedShelf.LastPlacedObject.X2 <= selectedContainer.Width &&
				//			((j == selectedContainer.Subcontainers.Count - 1 && selectedObject.Height + selectedShelf.Y <= selectedContainer.Height) ||
				//			j != selectedContainer.Subcontainers.Count - 1 && selectedObject.Height < selectedShelf.Height))
				//		{
				//			positionToPlace = new Position2D(selectedShelf.LastPlacedObject.X2, selectedShelf.Y);
				//		}
				//		else if (selectedObject.Height + selectedShelf.Y > selectedContainer.Height && i == containers.Count - 1 && j == selectedContainer.Subcontainers.Count - 1)
				//		{
				//			AddContainer();
				//			(containers.Last() as ShelfContainer2D).AddShelf();
				//			break;
				//		}
				//		else if (selectedObject.Height + selectedShelf.Y > selectedContainer.Height && j == selectedContainer.Subcontainers.Count - 1)
				//			break;
				//		else if (selectedObject.Width + selectedShelf.LastPlacedObject.X2 > selectedContainer.Width && j == selectedContainer.Subcontainers.Count - 1)
				//			selectedContainer.AddShelf();

				//	}
				//}

				objectsCopy.Remove(selectedObject);
				newPlacedObject = selectedContainer.PlaceObject(selectedObject, positionToPlace) as PlacedObject2D;
				selectedContainer.SplitSubcontainer(selectedSubcontainer, newPlacedObject); 
				positionToPlace = null;
			}
		}

	}
}
