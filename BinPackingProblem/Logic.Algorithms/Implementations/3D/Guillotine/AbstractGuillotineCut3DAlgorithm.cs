using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain.Containers._3D;
using Logic.Algorithms.ObjectFittingStrategies._3D;
using Logic.Domain.Objects;
using Logic.Domain;
using Logic.Domain.Containers._3D.Guillotine;
using Logic.Utilities.Extensions;

namespace Logic.Algorithms.Implementations._3D.Guillotine
{
	public abstract class AbstractGuillotineCut3DAlgorithm : Algorithm3D
	{
		private Container3D initialContainer;

		public AbstractGuillotineCut3DAlgorithm(Container3D initialContainer, AbstractFittingStrategy3D strategy) : base(initialContainer)
		{
			FittingStrategy = strategy;
		}

		public AbstractFittingStrategy3D FittingStrategy { get; set; }

		public override void Execute(ObjectSet originalObjects)
		{
			double bestFittingQuality = Double.MaxValue;
			double localFittingQuality;
			PlacedObject3D newPlacedObject;
			Position3D positionToPlace = null;

			GuillotineCutContainer3D selectedContainer = containers.First() as GuillotineCutContainer3D;

			GuillotineCutSubcontainer3D selectedSubcontainer = selectedContainer.Subcontainers.First() as GuillotineCutSubcontainer3D;

			var objectsCopy = originalObjects.ToObjectList();

			while (objectsCopy.Any())
			{
				Object3D selectedObject = objectsCopy.First() as Object3D;
				

				foreach (GuillotineCutContainer3D container in containers)
				{
					foreach (GuillotineCutSubcontainer3D subcontainer in container.Subcontainers)
					{
						if (FittingStrategy.ValidateObjectPlacement(selectedObject, subcontainer))
						{
							localFittingQuality = FittingStrategy.CalculateFittingQuality(selectedObject, subcontainer);
							if (localFittingQuality < bestFittingQuality)
							{
								bestFittingQuality = localFittingQuality;
								selectedContainer = container;
								selectedSubcontainer = subcontainer;
								positionToPlace = subcontainer.Position;
							}
						}
					}
				}
				if (positionToPlace == null)
				{
					AddContainer();

					selectedContainer = containers.Last() as GuillotineCutContainer3D;
					selectedSubcontainer = selectedContainer.Subcontainers.Last() as GuillotineCutSubcontainer3D;
					positionToPlace = selectedSubcontainer.Position;
				}


				objectsCopy.Remove(selectedObject);
				newPlacedObject = selectedContainer.PlaceObject(selectedObject, positionToPlace) as PlacedObject3D;
				selectedContainer.SplitSubcontainer(selectedSubcontainer, newPlacedObject);
				positionToPlace = null;
				bestFittingQuality = Double.MaxValue;
			}
		}
	}
}
