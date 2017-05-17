using Logic.Domain.Figures;
using Logic.Domain.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain.Containers._2D.Guillotine
{
	public abstract class GuillotineCutContainer2D : Container2D
	{
		public GuillotineCutContainer2D(int width, int height) : base(width, height)
		{
			Subcontainers = new List<SubContainer2D>();

			// At beginning new container is single subcontainer filling all space
			CreateSubcontainer(new Position2D(0, 0), new Rectangle(Width, Height));
		}

		public abstract void SplitSubcontainer(GuillotineCutSubcontainer2D subcontainer, PlacedObject2D placedObject);

		protected override SubContainer2D CreateSubcontainer(Position2D position, Rectangle size)
		{
			GuillotineCutSubcontainer2D newSubcontainer = new GuillotineCutSubcontainer2D(position.X, position.Y, size.Width, size.Height);

			Subcontainers.Add(newSubcontainer);

			return newSubcontainer;
		}

		protected void SplitSubcontainerVertically(GuillotineCutSubcontainer2D subcontainer, PlacedObject2D placedObject)
		{
			var topSubcontainerPosition = new Position2D(subcontainer.X, placedObject.Y2);
			var topSubcontainerSize = new Rectangle(placedObject.Width, subcontainer.Height - placedObject.Height);
			var topSubcontainer = new GuillotineCutSubcontainer2D(topSubcontainerPosition, topSubcontainerSize.Width, topSubcontainerSize.Height);

			var rightSubcontainerPosition = new Position2D(placedObject.X2, subcontainer.Y);
			var rightSubcontainerSize = new Rectangle(subcontainer.Width - placedObject.Width, subcontainer.Height);
			var rightSubcontainer = new GuillotineCutSubcontainer2D(rightSubcontainerPosition, rightSubcontainerSize.Width, rightSubcontainerSize.Height);

			// No need to add one dimensional container
			if (topSubcontainer.Width == 0 || topSubcontainer.Height == 0)
				Subcontainers.Add(topSubcontainer);

			if (rightSubcontainer.Width == 0 || rightSubcontainer.Height == 0)
				Subcontainers.Add(rightSubcontainer);

			Subcontainers.Remove(subcontainer);
		}

		protected void SplitSubcontainerHorizontally(GuillotineCutSubcontainer2D subcontainer, PlacedObject2D placedObject)
		{
			var topSubcontainerPosition = new Position2D(subcontainer.X, placedObject.Y2);
			var topSubcontainerSize = new Rectangle(subcontainer.Width, subcontainer.Height - placedObject.Height);
			var topSubcontainer = new GuillotineCutSubcontainer2D(topSubcontainerPosition, topSubcontainerSize.Width, topSubcontainerSize.Height);

			var rightSubcontainerPosition = new Position2D(placedObject.X2, subcontainer.Y);
			var rightSubcontainerSize = new Rectangle(subcontainer.Width - placedObject.Width, placedObject.Height);
			var rightSubcontainer = new GuillotineCutSubcontainer2D(rightSubcontainerPosition, rightSubcontainerSize.Width, rightSubcontainerSize.Height);

			// No need to add one dimensional container
			if (topSubcontainer.Width == 0 || topSubcontainer.Height == 0)
				Subcontainers.Add(topSubcontainer);

			if (rightSubcontainer.Width == 0 || rightSubcontainer.Height == 0)
				Subcontainers.Add(rightSubcontainer);

			Subcontainers.Remove(subcontainer);
		}
	}
}
