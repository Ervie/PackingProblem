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
		private Container2D container;

		public Algorithm2D(Container2D _container)
		{
			container = _container;
		}

		public void Execute(ObjectSet originalObjects)
		{
			throw new NotImplementedException();
		}

		public AlgorithmExecutionResults CreateResults()
		{
			var containerArea = container.Height * container.Width;
			var objectsTotalArea = container.PlacedObjects.Sum(o => (o as Rectangle).Width * (o as Rectangle).Height);

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
