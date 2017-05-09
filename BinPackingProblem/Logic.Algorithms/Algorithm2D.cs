using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain.Objects;
using Logic.Algorithms.Structs;
using Logic.Domain.Containers._2D;
using Logic.Domain.Figures;

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
			var containerArea = containers.Sum(x => x.Height * x.Width);
			var objectsTotalArea = containers.Sum(container => container.PlacedObjects.Sum(o => (o as Object2D).Width * (o as Object2D).Height));

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
