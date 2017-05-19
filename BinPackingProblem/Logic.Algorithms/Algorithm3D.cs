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
			containers = new List<Container3D>();
			containers.Add(initialContainer);
		}

		public abstract void Execute(ObjectSet originalObjects);

		public abstract void AddContainer();

		public AlgorithmExecutionResults CreateResults()
		{
			double averageFulfilment = 0.0;
			double standardDeviation = 0.0;
			var containerVolume = containers.Sum(x => x.Height * x.Width * x.Depth);
			var objectsTotalVolume = containers.Sum(x => x.PlacedObjects.Sum(o => (o as Cuboid).Width * (o as Cuboid).Height * (o as Cuboid).Depth));

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

			var results = new AlgorithmExecutionResults
			{
				PlacedObjects = placedObjectsTotal,
				ContainerSize = containers.First(),
				ContainerFulfilment = containerVolume,
				ObjectsTotalFulfilment = objectsTotalVolume,
				AverageFulfilmentRatio = averageFulfilment,
				FulfilmentRatioStandardDeviation = standardDeviation,
				Quality = (double)containerVolume / objectsTotalVolume,
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
							if ((placedObject1.X <= placedObject2.X2 && placedObject1.X2 >= placedObject2.X) &&
								 (placedObject1.Y <= placedObject2.Y2 && placedObject1.Y2 >= placedObject2.Y) &&
								 (placedObject1.Z <= placedObject2.Z2 && placedObject1.Z2 >= placedObject2.Z))
								return true;
						}
					}
				}
			}

			return false;
		}
	}
}