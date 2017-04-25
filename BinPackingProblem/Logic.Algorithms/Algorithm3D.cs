using Logic.Algorithms.Structs;
using Logic.Domain.Containers._3D;
using Logic.Domain.Figures;
using Logic.Domain.Objects;
using System;
using System.Linq;

namespace Logic.Algorithms
{
	internal class Algorithm3D : IAlgorithm
	{
		private Container3D container;

		public Algorithm3D(Container3D _container)
		{
			container = _container;
		}

		public void Execute(ObjectSet originalObjects)
		{
			throw new NotImplementedException();
		}

		public AlgorithmExecutionResults CreateResults()
		{
			var containerArea = container.Height * container.Width * container.Depth;
			var objectsTotalArea = container.PlacedObjects.Sum(o => (o as Cuboid).Width * (o as Cuboid).Height * (o as Cuboid).Depth);

			var results = new AlgorithmExecutionResults
			{
				PlacedObjects = container.PlacedObjects,
				ContainerSize = container,
				ContainerFulfilment = containerArea,
				ObjectsTotalFulfilment = objectsTotalArea,
				Quality = (double)containerArea / objectsTotalArea,
			};

			return results;
		}
	}
}