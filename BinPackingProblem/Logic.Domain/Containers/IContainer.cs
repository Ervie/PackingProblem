using Logic.Domain.Objects;

namespace Logic.Domain.Containers
{
	public interface IContainer<T, D> where T : Logic.Domain.Objects.Object where D : Logic.Domain.IPosition
	{
		IPlacedObject PlaceObject(T objectToPlace, D position);
	}
}