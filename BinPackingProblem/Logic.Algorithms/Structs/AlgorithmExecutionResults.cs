using Logic.Domain.Figures;
using Logic.Domain.Objects;
using System;

namespace Logic.Algorithms.Structs
{
	public struct AlgorithmExecutionResults
	{
		public PlacedObjects PlacedObjects { get; set; }
		public IFigure ContainerSize { get; set; }

		/// <summary>
		/// Either area or volume of container
		/// </summary>
		public int ContainerFulfillment { get; set; }

		/// <summary>
		/// Either total area or volume of all placed objects
		/// </summary>
		public int ObjectsTotalFulfillment { get; set; }

		public double AverageFulfillmentRatio { get; set; }

		public double FulfillmentRatioStandardDeviation { get; set; }
		public double Quality { get; set; }
		public long ExecutionTime { get; set; }

		public int ContainersUsed { get; set; }

		public int ObjectCount { get; set; }

		public double WorstFulfillment { get; set; }
	}
}