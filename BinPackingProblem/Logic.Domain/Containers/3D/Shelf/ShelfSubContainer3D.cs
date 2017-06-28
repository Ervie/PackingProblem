using Logic.Domain.Containers._2D;
using Logic.Domain.Containers._2D.Guillotine;
using Logic.Domain.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain.Containers._3D.Shelf
{
	public class ShelfSubContainer3D : SubContainer3D
	{

		public GuillotineCutMinAreaContainer2D GuillotineContainer { get; set; }
		
		public ShelfSubContainer3D(int x, int y, int z, int width, int height, int depth) : base(x, y, z, width, height, depth)
		{
			GuillotineContainer = new GuillotineCutMinAreaContainer2D(width, height);
		}

		public int MaxItemDepth { get; set; }

		public void SetShelfDepth()
		{
			this.Depth = MaxItemDepth;
		}

		public Position3D TryToFitObject(Object3D selectedObject)
		{
			double bestFittingQuality = Double.MaxValue;
			double localFittingQuality;
			Position2D positionToPlace = null;

			GuillotineCutContainer2D selectedContainer = GuillotineContainer;

			// No space in container - return from function
			if (selectedContainer.Subcontainers.Count == 0)
				return null;

			GuillotineCutSubcontainer2D selectedSubcontainer = selectedContainer.Subcontainers.First() as GuillotineCutSubcontainer2D;

			// flattens object to 2D during single shelf placement
			Object2D selectedObject2D = new Object2D(selectedObject.Width, selectedObject.Height);

			foreach (GuillotineCutSubcontainer2D subcontainer in selectedContainer.Subcontainers)
			{
				if (ValidateObjectPlacement(selectedObject2D, subcontainer))
				{
					localFittingQuality = CalculateFittingQuality(selectedObject2D, subcontainer);
					if (localFittingQuality < bestFittingQuality)
					{
						bestFittingQuality = localFittingQuality;
						selectedSubcontainer = subcontainer;
						positionToPlace = subcontainer.Position;
					}
				}
			}


			if (positionToPlace != null)
			{
				var newPlacedObject = selectedContainer.PlaceObject(selectedObject2D, positionToPlace) as PlacedObject2D;
				UpdateMaxDepth(selectedObject.Depth);
				selectedContainer.SplitSubcontainer(selectedSubcontainer, newPlacedObject);
				return new Position3D(positionToPlace.X, positionToPlace.Y, this.Depth);
			}
			else
				return null;
		}

		private void UpdateMaxDepth(int newObjectDepth)
		{
			if (MaxItemDepth < newObjectDepth)
				MaxItemDepth = newObjectDepth;
		}

		private double CalculateFittingQuality(Object2D objectToPlace, GuillotineCutSubcontainer2D subcontainer)
		{
			return subcontainer.Area / (double)objectToPlace.Area;
		}

		private bool ValidateObjectPlacement(Object2D objectToPlace, SubContainer2D subcontainer)
		{
			// Object too high for subcontainer
			if (objectToPlace.Height > subcontainer.Height)
			{
				return false;
			}
			// Object too wide for subcontainer
			if (objectToPlace.Width > subcontainer.Width)
			{
				return false;
			}

			return true;
		}
	}
}
