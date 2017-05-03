using Logic.Algorithms.Enums;
using Logic.Algorithms.Structs;
using Logic.Domain.Figures;

namespace Logic.Algorithms
{
	public interface IAlgorithmFactory
	{
		IAlgorithm Create(AlgorithmProperties properties, IFigure initalContainerSize);
	}
}