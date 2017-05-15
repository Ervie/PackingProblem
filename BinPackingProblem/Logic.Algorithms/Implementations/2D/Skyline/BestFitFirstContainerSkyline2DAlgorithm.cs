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
	public class BestFitFirstContainerSkyline2DAlgorithm : AbstractSkylineBestFit2DAlgorithm
	{
		public BestFitFirstContainerSkyline2DAlgorithm(Container2D initialContainer) : base(initialContainer)
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
				bestFitResult = Double.MaxValue;
				positionToPlace = null;
			}
		}


	}
}
