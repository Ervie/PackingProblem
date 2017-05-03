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
		private List<Container3D> containers;

		public Algorithm3D(Container3D initialContainer)
		{
			containers = new List<Container3D>();
			containers.Add(initialContainer);
		}

		public abstract void Execute(ObjectSet originalObjects);

		public AlgorithmExecutionResults CreateResults()
		{
			var containerArea = containers.Sum(x => x.Height * x.Width * x.Depth);
			var objectsTotalArea = containers.Sum(x => x.PlacedObjects.Sum(o => (o as Cuboid).Width * (o as Cuboid).Height * (o as Cuboid).Depth));

			PlacedObjects placedObjectsTotal = new PlacedObjects();

			foreach (var container in containers)
			{
				placedObjectsTotal.AddRange(container.PlacedObjects);
			}

			var results = new AlgorithmExecutionResults
			{
				PlacedObjects = placedObjectsTotal,
				ContainerSize = containers.First(),
				ContainerFulfilment = containerArea,
				ObjectsTotalFulfilment = objectsTotalArea,
				Quality = (double)containerArea / objectsTotalArea,
			};

			return results;
		}
	}
}