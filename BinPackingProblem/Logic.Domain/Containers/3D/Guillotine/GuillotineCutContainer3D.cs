using Logic.Domain.Figures;
using Logic.Domain.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain.Containers._3D.Guillotine
{
	public abstract class GuillotineCutContainer3D : Container3D
	{
		public GuillotineCutContainer3D(int width, int height, int depth) : base(width, height, depth)
		{
			Subcontainers = new List<SubContainer3D>();

			// At beginning new container is single subcontainer filling all space
			CreateSubcontainer(new Position3D(0, 0, 0), new Cuboid(Width, Height, Depth));
		}

		public abstract void SplitSubcontainer(GuillotineCutSubcontainer3D subcontainer, PlacedObject3D placedObject);

		protected override SubContainer3D CreateSubcontainer(Position3D position, Cuboid size)
		{
			GuillotineCutSubcontainer3D newSubcontainer = new GuillotineCutSubcontainer3D(position.X, position.Y, position.Z, size.Width, size.Height, size.Depth);

			Subcontainers.Add(newSubcontainer);

			return newSubcontainer;
		}
		
		protected void SplitSubcontainerVerticallyThenHorizontally(GuillotineCutSubcontainer3D subcontainer, PlacedObject3D placedObject)
		{

			var rightSubcontainerPosition = new Position3D(placedObject.X2, subcontainer.Y, subcontainer.Z);
			var rightSubcontainerSize = new Cuboid(subcontainer.Width - placedObject.Width, subcontainer.Height, subcontainer.Depth);
			var rightSubcontainer = new GuillotineCutSubcontainer3D(rightSubcontainerPosition, rightSubcontainerSize.Width, rightSubcontainerSize.Height, rightSubcontainerSize.Depth);

			var topSubcontainerPosition = new Position3D(subcontainer.X, placedObject.Y2, subcontainer.Z);
			var topSubcontainerSize = new Cuboid(placedObject.Width, subcontainer.Height - placedObject.Height, subcontainer.Depth);
			var topSubcontainer = new GuillotineCutSubcontainer3D(topSubcontainerPosition, topSubcontainerSize.Width, topSubcontainerSize.Height, topSubcontainerSize.Depth);

			var behindSubcontainerPosition = new Position3D(subcontainer.X, subcontainer.Y, placedObject.Z2);
			var behindSubcontainerSize = new Cuboid(placedObject.Width, placedObject.Height, subcontainer.Depth - placedObject.Depth);
			var behindSubcontainer = new GuillotineCutSubcontainer3D(behindSubcontainerPosition, behindSubcontainerSize.Width, behindSubcontainerSize.Height, behindSubcontainerSize.Depth);


			// No need to add one ore two dimensional container
			if (topSubcontainer.Width != 0 && topSubcontainer.Height != 0 && topSubcontainer.Depth != 0)
				Subcontainers.Add(topSubcontainer);

			if (rightSubcontainer.Width != 0 && rightSubcontainer.Height != 0 && rightSubcontainer.Depth != 0)
				Subcontainers.Add(rightSubcontainer);

			if (behindSubcontainer.Width != 0 && behindSubcontainer.Height != 0 && behindSubcontainer.Depth != 0)
				Subcontainers.Add(behindSubcontainer);

			Subcontainers.Remove(subcontainer);
		}
		
		protected void SplitSubcontainerVerticallyThenDepth(GuillotineCutSubcontainer3D subcontainer, PlacedObject3D placedObject)
		{
			var rightSubcontainerPosition = new Position3D(placedObject.X2, subcontainer.Y, subcontainer.Z);
			var rightSubcontainerSize = new Cuboid(subcontainer.Width - placedObject.Width, subcontainer.Height, subcontainer.Depth);
			var rightSubcontainer = new GuillotineCutSubcontainer3D(rightSubcontainerPosition, rightSubcontainerSize.Width, rightSubcontainerSize.Height, rightSubcontainerSize.Depth);

			var behindSubcontainerPosition = new Position3D(subcontainer.X, subcontainer.Y, placedObject.Z2);
			var behindSubcontainerSize = new Cuboid(placedObject.Width, subcontainer.Height, subcontainer.Depth - placedObject.Depth);
			var behindSubcontainer = new GuillotineCutSubcontainer3D(behindSubcontainerPosition, behindSubcontainerSize.Width, behindSubcontainerSize.Height, behindSubcontainerSize.Depth);

			var topSubcontainerPosition = new Position3D(subcontainer.X, placedObject.Y2, subcontainer.Z);
			var topSubcontainerSize = new Cuboid(placedObject.Width, subcontainer.Height - placedObject.Height, placedObject.Depth);
			var topSubcontainer = new GuillotineCutSubcontainer3D(topSubcontainerPosition, topSubcontainerSize.Width, topSubcontainerSize.Height, topSubcontainerSize.Depth);
						
			// No need to add one ore two dimensional container
			if (topSubcontainer.Width != 0 && topSubcontainer.Height != 0 && topSubcontainer.Depth != 0)
				Subcontainers.Add(topSubcontainer);

			if (rightSubcontainer.Width != 0 && rightSubcontainer.Height != 0 && rightSubcontainer.Depth != 0)
				Subcontainers.Add(rightSubcontainer);

			if (behindSubcontainer.Width != 0 && behindSubcontainer.Height != 0 && behindSubcontainer.Depth != 0)
				Subcontainers.Add(behindSubcontainer);

			Subcontainers.Remove(subcontainer);
		}

		protected void SplitSubcontainerHorizontallyThenVertically(GuillotineCutSubcontainer3D subcontainer, PlacedObject3D placedObject)
		{
			var topSubcontainerPosition = new Position3D(subcontainer.X, placedObject.Y2, subcontainer.Z);
			var topSubcontainerSize = new Cuboid(subcontainer.Width, subcontainer.Height - placedObject.Height, subcontainer.Depth);
			var topSubcontainer = new GuillotineCutSubcontainer3D(topSubcontainerPosition, topSubcontainerSize.Width, topSubcontainerSize.Height, topSubcontainerSize.Depth);

			var rightSubcontainerPosition = new Position3D(placedObject.X2, subcontainer.Y, subcontainer.Z);
			var rightSubcontainerSize = new Cuboid(subcontainer.Width - placedObject.Width, placedObject.Height, subcontainer.Depth);
			var rightSubcontainer = new GuillotineCutSubcontainer3D(rightSubcontainerPosition, rightSubcontainerSize.Width, rightSubcontainerSize.Height, rightSubcontainerSize.Depth);

			var behindSubcontainerPosition = new Position3D(subcontainer.X, subcontainer.Y, placedObject.Z2);
			var behindSubcontainerSize = new Cuboid(placedObject.Width, placedObject.Height, subcontainer.Depth - placedObject.Depth);
			var behindSubcontainer = new GuillotineCutSubcontainer3D(behindSubcontainerPosition, behindSubcontainerSize.Width, behindSubcontainerSize.Height, behindSubcontainerSize.Depth);

			
			// No need to add one ore two dimensional container
			if (topSubcontainer.Width != 0 && topSubcontainer.Height != 0 && topSubcontainer.Depth != 0)
				Subcontainers.Add(topSubcontainer);

			if (rightSubcontainer.Width != 0 && rightSubcontainer.Height != 0 && rightSubcontainer.Depth != 0)
				Subcontainers.Add(rightSubcontainer);

			if (behindSubcontainer.Width != 0 && behindSubcontainer.Height != 0 && behindSubcontainer.Depth != 0)
				Subcontainers.Add(behindSubcontainer);

			Subcontainers.Remove(subcontainer);
		}

		protected void SplitSubcontainerHorizontallyThenDepth(GuillotineCutSubcontainer3D subcontainer, PlacedObject3D placedObject)
		{
			var topSubcontainerPosition = new Position3D(subcontainer.X, placedObject.Y2, subcontainer.Z);
			var topSubcontainerSize = new Cuboid(subcontainer.Width, subcontainer.Height - placedObject.Height, subcontainer.Depth);
			var topSubcontainer = new GuillotineCutSubcontainer3D(topSubcontainerPosition, topSubcontainerSize.Width, topSubcontainerSize.Height, topSubcontainerSize.Depth);

			var behindSubcontainerPosition = new Position3D(subcontainer.X, subcontainer.Y, placedObject.Z2);
			var behindSubcontainerSize = new Cuboid(subcontainer.Width, placedObject.Height, subcontainer.Depth - placedObject.Depth);
			var behindSubcontainer = new GuillotineCutSubcontainer3D(behindSubcontainerPosition, behindSubcontainerSize.Width, behindSubcontainerSize.Height, behindSubcontainerSize.Depth);

			var rightSubcontainerPosition = new Position3D(placedObject.X2, subcontainer.Y, subcontainer.Z);
			var rightSubcontainerSize = new Cuboid(subcontainer.Width - placedObject.Width, placedObject.Height, placedObject.Depth);
			var rightSubcontainer = new GuillotineCutSubcontainer3D(rightSubcontainerPosition, rightSubcontainerSize.Width, rightSubcontainerSize.Height, rightSubcontainerSize.Depth);

			// No need to add one ore two dimensional container
			if (topSubcontainer.Width != 0 && topSubcontainer.Height != 0 && topSubcontainer.Depth != 0)
				Subcontainers.Add(topSubcontainer);

			if (rightSubcontainer.Width != 0 && rightSubcontainer.Height != 0 && rightSubcontainer.Depth != 0)
				Subcontainers.Add(rightSubcontainer);

			if (behindSubcontainer.Width != 0 && behindSubcontainer.Height != 0 && behindSubcontainer.Depth != 0)
				Subcontainers.Add(behindSubcontainer);

			Subcontainers.Remove(subcontainer);
		}

		protected void SplitSubcontainerDepthThenVertically(GuillotineCutSubcontainer3D subcontainer, PlacedObject3D placedObject)
		{
			var behindSubcontainerPosition = new Position3D(subcontainer.X, subcontainer.Y, placedObject.Z2);
			var behindSubcontainerSize = new Cuboid(subcontainer.Width, subcontainer.Height, subcontainer.Depth - placedObject.Depth);
			var behindSubcontainer = new GuillotineCutSubcontainer3D(behindSubcontainerPosition, behindSubcontainerSize.Width, behindSubcontainerSize.Height, behindSubcontainerSize.Depth);

			var rightSubcontainerPosition = new Position3D(placedObject.X2, subcontainer.Y, subcontainer.Z);
			var rightSubcontainerSize = new Cuboid(subcontainer.Width - placedObject.Width, subcontainer.Height, placedObject.Depth);
			var rightSubcontainer = new GuillotineCutSubcontainer3D(rightSubcontainerPosition, rightSubcontainerSize.Width, rightSubcontainerSize.Height, rightSubcontainerSize.Depth);

			var topSubcontainerPosition = new Position3D(subcontainer.X, placedObject.Y2, subcontainer.Z);
			var topSubcontainerSize = new Cuboid(placedObject.Width, subcontainer.Height - placedObject.Height, placedObject.Depth);
			var topSubcontainer = new GuillotineCutSubcontainer3D(topSubcontainerPosition, topSubcontainerSize.Width, topSubcontainerSize.Height, topSubcontainerSize.Depth);
						
			// No need to add one ore two dimensional container
			if (topSubcontainer.Width != 0 && topSubcontainer.Height != 0 && topSubcontainer.Depth != 0)
				Subcontainers.Add(topSubcontainer);

			if (rightSubcontainer.Width != 0 && rightSubcontainer.Height != 0 && rightSubcontainer.Depth != 0)
				Subcontainers.Add(rightSubcontainer);

			if (behindSubcontainer.Width != 0 && behindSubcontainer.Height != 0 && behindSubcontainer.Depth != 0)
				Subcontainers.Add(behindSubcontainer);

			Subcontainers.Remove(subcontainer);
		}

		protected void SplitSubcontainerDepthThenHorizontally(GuillotineCutSubcontainer3D subcontainer, PlacedObject3D placedObject)
		{
			var behindSubcontainerPosition = new Position3D(subcontainer.X, subcontainer.Y, placedObject.Z2);
			var behindSubcontainerSize = new Cuboid(subcontainer.Width, subcontainer.Height, subcontainer.Depth - placedObject.Depth);
			var behindSubcontainer = new GuillotineCutSubcontainer3D(behindSubcontainerPosition, behindSubcontainerSize.Width, behindSubcontainerSize.Height, behindSubcontainerSize.Depth);

			var topSubcontainerPosition = new Position3D(subcontainer.X, placedObject.Y2, subcontainer.Z);
			var topSubcontainerSize = new Cuboid(subcontainer.Width, subcontainer.Height - placedObject.Height, placedObject.Depth);
			var topSubcontainer = new GuillotineCutSubcontainer3D(topSubcontainerPosition, topSubcontainerSize.Width, topSubcontainerSize.Height, topSubcontainerSize.Depth);

			var rightSubcontainerPosition = new Position3D(placedObject.X2, subcontainer.Y, subcontainer.Z);
			var rightSubcontainerSize = new Cuboid(subcontainer.Width - placedObject.Width, placedObject.Height, placedObject.Depth);
			var rightSubcontainer = new GuillotineCutSubcontainer3D(rightSubcontainerPosition, rightSubcontainerSize.Width, rightSubcontainerSize.Height, rightSubcontainerSize.Depth);
			
			// No need to add one ore two dimensional container
			if (topSubcontainer.Width != 0 && topSubcontainer.Height != 0 && topSubcontainer.Depth != 0)
				Subcontainers.Add(topSubcontainer);

			if (rightSubcontainer.Width != 0 && rightSubcontainer.Height != 0 && rightSubcontainer.Depth != 0)
				Subcontainers.Add(rightSubcontainer);

			if (behindSubcontainer.Width != 0 && behindSubcontainer.Height != 0 && behindSubcontainer.Depth != 0)
				Subcontainers.Add(behindSubcontainer);

			Subcontainers.Remove(subcontainer);
		}
	}
}
