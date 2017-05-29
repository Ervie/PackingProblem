using Logic.Algorithms.Structs;
using Logic.Domain.Containers._2D;
using Logic.Domain.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Algorithms
{
	public abstract class Algorithm2D : IAlgorithm
	{
		public List<Container2D> containers;

		public Algorithm2D(Container2D initialContainer)
		{
		}

		public abstract void Execute(ObjectSet originalObjects);

		public abstract void AddContainer();

		public AlgorithmExecutionResults CreateResults()
		{
			double averageFulfilment = 0.0;
			double standardDeviation = 0.0;
			var containerArea = containers.Sum(x => x.Height * x.Width);
			var objectsTotalArea = containers.Sum(container => container.PlacedObjects.Sum(o => (o as Object2D).Width * (o as Object2D).Height));
			double worstFulfillment;

			PlacedObjects placedObjectsTotal = new PlacedObjects();

			foreach (var container in containers)
			{
				placedObjectsTotal.AddRange(container.PlacedObjects);
				averageFulfilment += container.GetFulfilment();
			}

			averageFulfilment /= containers.Count();

			foreach (var container in containers)
			{
				standardDeviation += Math.Pow((double)(averageFulfilment - container.GetFulfilment()), 2.0);
			}

			standardDeviation = Math.Sqrt(standardDeviation / containers.Count);

			worstFulfillment = containers.OrderBy(x => x.GetFulfilment()).FirstOrDefault().GetFulfilment();

			var results = new AlgorithmExecutionResults
			{
				PlacedObjects = placedObjectsTotal,
				ContainerSize = containers.First(),
				ContainerFulfillment = containerArea,
				ObjectsTotalFulfillment = objectsTotalArea,
				AverageFulfillmentRatio = averageFulfilment,
				FulfillmentRatioStandardDeviation = standardDeviation,
				Quality = (double)containerArea / objectsTotalArea,
				ContainersUsed = containers.Count,
				WorstFulfillment = worstFulfillment
			};

			return results;
		}

		/// <summary>
		/// Help method for checking if placed object overlaps.
		/// </summary>
		public bool DoesPlacedObjectsOverlap()
		{
			foreach (var container in containers)
			{
				foreach (var object1 in container.PlacedObjects)
				{
					foreach (var object2 in container.PlacedObjects)
					{
						if (object1 != object2)
						{
							PlacedObject2D placedObject1 = object1 as PlacedObject2D;
							PlacedObject2D placedObject2 = object2 as PlacedObject2D;

							if (placedObject1.Position.X < placedObject2.Position.X + placedObject2.Width &&
								placedObject1.Position.X + placedObject1.Width > placedObject2.Position.X &&
								placedObject1.Position.Y > placedObject2.Position.Y + placedObject2.Height &&
								placedObject1.Position.Y + placedObject1.Height < placedObject2.Position.Y)
								return true;
						}
					}
				}
			}

			return false;
		}
	}
}