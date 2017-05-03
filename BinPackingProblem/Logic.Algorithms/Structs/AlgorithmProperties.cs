using Logic.Algorithms.Enums;

namespace Logic.Algorithms.Structs
{
	public class AlgorithmProperties
	{
		public AlgorithmDimensionality Dimensionality { get; set; }

		public AlgorithmFamily Family { get; set; }

		public ObjectFittingStrategy AlgorithmType { get; set; }

		public ContainerSplittingStrategy SplittingStrategy { get; set; }

	}
}