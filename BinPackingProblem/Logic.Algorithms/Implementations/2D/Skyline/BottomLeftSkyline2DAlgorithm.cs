using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain.Containers._2D;
using Logic.Domain.Objects;
using Logic.Utilities.Extensions;
using Logic.Domain;
using Logic.Domain.Containers._2D.Skyline;
using Logic.Domain.Figures;

namespace Logic.Algorithms.Implementations._2D.Skyline
{
	public class BottomLeftSkyline2DAlgorithm : AbstractSkyline2DAlgorithm
	{
		public BottomLeftSkyline2DAlgorithm(Container2D initialContainer) : base(initialContainer)
		{
		}

		public override void Execute(ObjectSet originalObjects)
		{
			int selectedFitContainerIndex = 0;

			Position2D positionToPlace = null;

			SkylineContainer2D selectedContainer = containers.First() as SkylineContainer2D;
			
			var objectsCopy = originalObjects.ToObjectList();

			while (objectsCopy.Any())
			{
				Object2D selectedObject = objectsCopy.First() as Object2D;

				for (int i = 0; i < containers.Count; i++)
				{
					positionToPlace = FindMostBottomFittingSkyline(containers[i] as SkylineContainer2D, selectedObject);
					
					if (positionToPlace != null)
					{
						selectedFitContainerIndex = i;
						break;
					}
				}

				// Object not placed, create new container, place object bottom-left
				if (positionToPlace == null)
				{
					AddContainer();

					selectedContainer = containers.Last() as SkylineContainer2D;

					positionToPlace = new Position2D(0, 0);
				}
				else
					selectedContainer = containers[selectedFitContainerIndex] as SkylineContainer2D;
				
				objectsCopy.Remove(selectedObject);
				selectedContainer.PlaceNewObject(selectedObject, positionToPlace);
				selectedFitContainerIndex = 0;
			}
		}

		private Position2D FindMostBottomFittingSkyline(SkylineContainer2D container2D, Object2D objectToPlace)
		{
			var sortedSkylines = container2D.AvailableSkylines.OrderBy(o => o.Y);

			Position2D leftShiftedPosition = null;

			foreach (Line skyline in sortedSkylines)
			{
				// Skyline + object is higher than container
				if (skyline.Y + objectToPlace.Height > container2D.Height)
					continue;

				// Skyline is wider than object
				if (skyline.Length > objectToPlace.Width)
					return new Position2D(skyline.X, skyline.Y);

				// Object is wider than skyline
				leftShiftedPosition = CheckShiftedPositionAvailability(container2D, objectToPlace);
				if (leftShiftedPosition != null)
					return leftShiftedPosition;
			}

			return null;
		}

		private Position2D CheckShiftedPositionAvailability(SkylineContainer2D container2D, Object2D objectToPlace)
		{
			throw new NotImplementedException();
		}
	}
}
