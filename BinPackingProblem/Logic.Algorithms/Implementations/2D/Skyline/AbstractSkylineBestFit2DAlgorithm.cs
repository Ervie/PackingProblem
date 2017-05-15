using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain.Containers._2D;
using Logic.Domain.Containers._2D.Skyline;
using Logic.Domain;
using Logic.Domain.Figures;
using Logic.Domain.Objects;

namespace Logic.Algorithms.Implementations._2D.Skyline
{
	public abstract class AbstractSkylineBestFit2DAlgorithm : AbstractSkyline2DAlgorithm
	{
		public AbstractSkylineBestFit2DAlgorithm(Container2D initialContainer) : base(initialContainer)
		{
		}

		protected double FindBestFitWithinContainer(SkylineContainer2D container2D, Object2D objectToPlace, double globallyBestFit, ref Position2D bestGlobalFitPosition)
		{
			var sortedSkylines = container2D.AvailableSkylines.OrderBy(o => o.Y).ToList();

			Position2D leftShiftedPosition, bestFitPosition = null;
			double currentFitValue, bestFitValueInContainer = Double.MaxValue;

			foreach (Line skyline in sortedSkylines)
			{
				// Skyline + object is higher than container; As skylines are sorted from lowest, break on first compatible statement
				if (skyline.Y + objectToPlace.Height > container2D.Height)
					break;


				leftShiftedPosition = CheckShiftedPositionAvailability(container2D, objectToPlace, skyline);
				if (leftShiftedPosition != null)
				{
					currentFitValue = GetBelowUnavaibleArea(leftShiftedPosition, container2D, objectToPlace.Width);

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

		/// <summary>
		/// Calculates potential total blocked area by placing object on given position
		/// </summary>
		private double GetBelowUnavaibleArea(Position2D positionToPlace, SkylineContainer2D container2D, int objectWidth)
		{
			double totalBlockedArea = 0.0;

			int endOfObjectWidth = positionToPlace.X + objectWidth;

			foreach (var availableSkyline in container2D.AvailableSkylines.ToList())
			{
				// Checks only skylines below place
				if (availableSkyline.Y <= positionToPlace.Y)
				{
					// Object completely cover skyline below - no unused space
					if (availableSkyline.X >= positionToPlace.X &&
						availableSkyline.X2 <= endOfObjectWidth)
					{
						//totalBlockedArea += 0;
						continue;
					}

					// Object partially cover skyline below (left) - unused space on right
					if (availableSkyline.X < positionToPlace.X &&
						availableSkyline.X2 <= endOfObjectWidth &&
						availableSkyline.X2 > positionToPlace.X)
					{
						totalBlockedArea += (endOfObjectWidth - availableSkyline.X) * (positionToPlace.Y - availableSkyline.Y);
						continue;
					}

					// Object partially cover skyline below (right) - unused space on left
					if (availableSkyline.X >= positionToPlace.X &&
						availableSkyline.X < endOfObjectWidth &&
						availableSkyline.X2 > endOfObjectWidth)
					{
						totalBlockedArea += (availableSkyline.X2 - positionToPlace.X) * (positionToPlace.Y - availableSkyline.Y);
						continue;
					}
					// Object partially cover skyline below from both size -> unused space on left and right
					if (availableSkyline.X < positionToPlace.X &&
						availableSkyline.X2 > endOfObjectWidth)
					{
						//left
						totalBlockedArea += (positionToPlace.X - availableSkyline.X) * (availableSkyline.Y * positionToPlace.Y);
						//right
						totalBlockedArea += (availableSkyline.X2 - endOfObjectWidth) * (availableSkyline.Y * positionToPlace.Y);
					}
				}
			}



			return totalBlockedArea;
		}
	}
}
