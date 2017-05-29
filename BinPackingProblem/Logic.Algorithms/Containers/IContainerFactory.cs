using Logic.Algorithms.Structs;
using Logic.Domain.Containers._2D;
using Logic.Domain.Containers._3D;

namespace Logic.Algorithms.Containers
{
	public interface IContainerFactory
	{
		Container2D Create(AlgorithmProperties properties, int Width, int Height);

		Container3D Create(AlgorithmProperties properties, int Width, int Height, int Depth);
	}
}