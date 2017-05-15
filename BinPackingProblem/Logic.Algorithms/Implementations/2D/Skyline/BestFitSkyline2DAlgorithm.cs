using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain.Containers._2D;
using Logic.Domain.Objects;
using Logic.Domain;
using Logic.Domain.Containers._2D.Skyline;
using Logic.Utilities.Extensions;
using Logic.Domain.Figures;

namespace Logic.Algorithms.Implementations._2D.Skyline
{
	public class BestFitSkyline2DAlgorithm : AbstractSkyline2DAlgorithm
	{
		public BestFitSkyline2DAlgorithm(Container2D initialContainer) : base(initialContainer)
		{
		}

		public override void Execute(ObjectSet originalObjects)
		{
			double bestFitResult = Double.MaxValue;
			double currentFitResult;

			int selectedFitContainerIndex = 0;

			Position2D positionToPlace = null;

			SkylineContainer2D selectedContainer = containers.First() as SkylineContainer2D;

			var objectsCopy = originalObjects.ToObjectList();

			while (objectsCopy.Any())
			{
				Object2D selectedObject = objectsCopy.First() as Object2D;

				for (int i = 0; i < containers.Count; i++)
				{
					currentFitResult = FindBestFitWithinContainer(containers[i] as SkylineContainer2D, selectedObject, bestFitResult, ref positionToPlace);

					if (currentFitResult < bestFitResult)
					{
						bestFitResult = currentFitResult;
						selectedFitContainerIndex = i;
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
				bestFitResult = Double.MaxValue;
				positionToPlace = null;
			}
		}

		private double FindBestFitWithinContainer(SkylineContainer2D container2D, Object2D objectToPlace, double globallyBestFit, ref Position2D bestGlobalFitPosition)
		{
			var sortedSkylines = container2D.AvailableSkylines.OrderBy(o => o.Y);

			Position2D leftShiftedPosition, bestFitPosition = null;
			double currentFitValue, bestFitValueInContainer = 0.0;

			foreach (Line skyline in sortedSkylines)
			{
				// Skyline + object is higher than container; As skylines are sorted from lowest, break on first compatible statement
				if (skyline.Y + objectToPlace.Height > container2D.Height)
					break;


				leftShiftedPosition = CheckShiftedPositionAvailability(container2D, objectToPlace, skyline);
				if (leftShiftedPosition != null)
				{
					currentFitValue = GetBelowUnavaibleArea(leftShiftedPosition, container2D);

					if (currentFitValue < bestFitValueInContainer)
					{
						bestFitValueInContainer = currentFitValue;
						bestFitPosition = leftShiftedPosition;
					}
				}
			}

			if (bestFitValueInContainer < globallyBestFit)
			{
				bestGlobalFitPosition = bestFitPosition;
				return bestFitValueInContainer;
			}
			else
				return globallyBestFit;
		}

		private double GetBelowUnavaibleArea(Position2D leftShiftedPosition, SkylineContainer2D container2D)
		{
			throw new NotImplementedException();
		}
	}
}
