using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain.Containers._2D;
using Logic.Domain.Objects;
using Logic.Domain;
using Logic.Domain.Containers._2D.Guillotine;
using Logic.Utilities.Extensions;
using Logic.Algorithms.ObjectFittingStrategies;
using Logic.Algorithms.ObjectFittingStrategies._2D;
using Logic.Algorithms.Enums;

namespace Logic.Algorithms.Implementations._2D.Guillotine
{
	public abstract class AbstractGuillotineCut2DAlgorithm : Algorithm2D
	{
		private Container2D initialContainer;

		public AbstractGuillotineCut2DAlgorithm(Container2D initialContainer, AbstractFittingStrategy2D strategy) : base(initialContainer)
		{
			FittingStrategy = strategy;
		}

		public AbstractFittingStrategy2D FittingStrategy { get; set; }

		public override void Execute(ObjectSet originalObjects)
		{
			double bestFittingQuality = Double.MaxValue;
			double localFittingQuality;
			PlacedObject2D newPlacedObject;
			Position2D positionToPlace = null;

			GuillotineCutContainer2D selectedContainer = containers.First() as GuillotineCutContainer2D;

			GuillotineCutSubcontainer2D selectedSubcontainer = selectedContainer.Subcontainers.First() as GuillotineCutSubcontainer2D;

			var objectsCopy = originalObjects.ToObjectList();

			while (objectsCopy.Any())
			{
				Object2D selectedObject = objectsCopy.First() as Object2D;
				

				foreach (GuillotineCutContainer2D container in containers)
				{
					foreach (GuillotineCutSubcontainer2D subcontainer in container.Subcontainers)
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

					selectedContainer = containers.Last() as GuillotineCutContainer2D;
					selectedSubcontainer = selectedContainer.Subcontainers.Last() as GuillotineCutSubcontainer2D;
					positionToPlace = selectedSubcontainer.Position;
				}


				objectsCopy.Remove(selectedObject);
				newPlacedObject = selectedContainer.PlaceObject(selectedObject, positionToPlace) as PlacedObject2D;
				selectedContainer.SplitSubcontainer(selectedSubcontainer, newPlacedObject); 
				positionToPlace = null;
				bestFittingQuality = Double.MaxValue;
			}
		}
	}
}
