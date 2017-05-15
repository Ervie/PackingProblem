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
				// Skyline + object is higher than container; As skylines are sorted from lowest, break on first compatible statement
				if (skyline.Y + objectToPlace.Height > container2D.Height)
					break;

				// Skyline is wider than object
				//if (skyline.Length >= objectToPlace.Width)
				//	return new Position2D(skyline.X, skyline.Y);

				// Object is wider than skyline
				leftShiftedPosition = CheckShiftedPositionAvailability(container2D, objectToPlace, skyline);
				if (leftShiftedPosition != null)
					return leftShiftedPosition;
			}

			return null;
		}

		private Position2D CheckShiftedPositionAvailability(SkylineContainer2D container2D, Object2D objectToPlace, Line currentSkyline)
		{
			//Skylines on left side of currently checked skyline, starting from nearest
			var skylinesOnLeft = container2D.AvailableSkylines.Where(x => x.X < currentSkyline.X).OrderByDescending(x => x.X).ToList();

			Position2D mostLeftPosition = new Position2D(currentSkyline.X, currentSkyline.Y);

			// Look if object can be moved further to left, i.e. skyylines on left are below current skyline
			foreach (Line skyline in skylinesOnLeft)
			{
				if (skyline.Y < currentSkyline.Y)
				{
					mostLeftPosition.X = skyline.X;
				}
				else
					break;
			}

			// Part protruding on the right side of current skyline
			int protrudingPartLenght = mostLeftPosition.X + objectToPlace.Width - currentSkyline.X2;

			// If it exceed container width, then break
			if (protrudingPartLenght + currentSkyline.X2 > container2D.Width)
				return null;

			//Skylines on right side of currently checked skyline covered by protruding part, starting from nearest
			var skylinesOnRight = container2D.AvailableSkylines.Where(x => x.X > currentSkyline.X && x.X < currentSkyline.X2 + protrudingPartLenght).OrderBy(x => x.X).ToList();

			// Check if skylines on right are below object; If yes, it can be placed, otherwise object would overlap
			foreach (Line skyline in skylinesOnRight)
			{
				if (skyline.Y > currentSkyline.Y)
				{
					mostLeftPosition = null;
					break;
				}
			}

			return mostLeftPosition;
		}
	}
}
