using Logic.Algorithms.Enums;
using Logic.Algorithms.Structs;

namespace Logic.Algorithms
{
	public interface IAlgorithmFactory
	{
		IAlgorithm Create(AlgorithmProperties properties);
	}
}