using Logic.Algorithms.Structs;
using Logic.Domain.Objects;

namespace Logic.Algorithms
{
	public interface IAlgorithm
	{
		void Execute(ObjectSet originalObjects);

		AlgorithmExecutionResults CreateResults();
	}
}