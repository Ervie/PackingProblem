using Logic.Algorithms.Structs;
using Logic.Domain.Containers._3D;
using Logic.Domain.Figures;
using Logic.Domain.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Algorithms
{
	public abstract class Algorithm3D : IAlgorithm
	{
		public List<Container3D> containers;

		public Algorithm3D(Container3D initialContainer)
		{
		}

		public abstract void Execute(ObjectSet originalObjects);

		public abstract void AddContainer();

		public AlgorithmExecutionResults CreateResults()
		{
			double averageFulfilment = 0.0;
			double standardDeviation = 0.0;
			var containerVolume = containers.Sum(x => x.Height * x.Width * x.Depth);
			var objectsTotalVolume = containers.Sum(container => container.PlacedObjects.Sum(o => (o as Object3D).Width * (o as Object3D).Height * (o as Object3D).Depth));
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

			// If more than 1 container was used, do not take last created into account
			if (containers.Count > 1)
				worstFulfillment = containers.OrderBy(x => x.GetFulfilment()).Skip(1).FirstOrDefault().GetFulfilment();
			else
				worstFulfillment = containers.OrderBy(x => x.GetFulfilment()).FirstOrDefault().GetFulfilment();

			var results = new AlgorithmExecutionResults
			{
				PlacedObjects = placedObjectsTotal,
				ContainerSize = containers.First(),
				ContainerFulfillment = containerVolume,
				ObjectsTotalFulfillment = objectsTotalVolume,
				AverageFulfillmentRatio = averageFulfilment,
				FulfillmentRatioStandardDeviation = standardDeviation,
				Quality = (double)containerVolume / objectsTotalVolume,
				ContainersUsed = containers.Count,
				WorstFulfillment = worstFulfillment
			};

			return results;
		}

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
							PlacedObject3D placedObject1 = object1 as PlacedObject3D;
							PlacedObject3D placedObject2 = object2 as PlacedObject3D;

							if (placedObject1.Position.X < placedObject2.Position.X + placedObject2.Width &&
								placedObject1.Position.X + placedObject1.Width > placedObject2.Position.X &&
								placedObject1.Position.Y > placedObject2.Position.Y + placedObject2.Height &&
								placedObject1.Position.Y + placedObject1.Height < placedObject2.Position.Y &&
								placedObject1.Position.Z > placedObject2.Position.Z + placedObject2.Depth &&
								placedObject1.Position.Z + placedObject1.Depth < placedObject2.Position.Z)
								return true;
						}
					}
				}
			}

			return false;
		}
	}
}