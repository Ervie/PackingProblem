using Logic.Domain.Figures;
using Logic.Domain.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Algorithms.Structs
{
	public struct AlgorithmExecutionResults
	{
		public PlacedObjects PlacedObjects { get; set; }
		public IFigure ContainerSize { get; set; }

		/// <summary>
		/// Either area or volume of container
		/// </summary>
		public int ContainerFulfilment { get; set; }

		/// <summary>
		/// Either total area or volume of all placed objects
		/// </summary>
		public int ObjectsTotalFulfilment { get; set; }
		public double Quality { get; set; }
		public TimeSpan ExecutionTime { get; set; }
	}
}
