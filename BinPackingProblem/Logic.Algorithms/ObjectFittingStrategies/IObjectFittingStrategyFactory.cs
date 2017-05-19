using Logic.Algorithms.Enums;
using Logic.Domain.Containers._2D;
using Logic.Domain.Containers._3D;
using Logic.Domain.Objects;

namespace Logic.Algorithms.ObjectFittingStrategies
{
	public interface IObjectFittingStrategyFactory
	{
		IObjectFittingStrategy<Object2D, SubContainer2D> Create2D(ObjectFittingStrategy objectFittingStrategy);

		IObjectFittingStrategy<Object3D, SubContainer3D> Create3D(ObjectFittingStrategy objectFittingStrategy);
	}
}