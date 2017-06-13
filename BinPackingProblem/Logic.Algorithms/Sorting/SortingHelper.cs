using Logic.Algorithms.Enums;
using Logic.Algorithms.Exceptions;
using Logic.Domain.Objects;
using Logic.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Algorithms.Sorting
{
	public static class SortingHelper
	{
		public static ObjectSet Sort(ObjectSet inputObjectSet, ObjectOrdering ordering)
		{
			if (inputObjectSet != null && inputObjectSet.Count != 0)
			{
				if (ordering.Equals(ObjectOrdering.None))
					return inputObjectSet;
				if (inputObjectSet.First() is Object2D)
					return Sort2DSet(inputObjectSet, ordering);
				else
					return Sort3DSet(inputObjectSet, ordering);
			}
			return inputObjectSet;
		}

		private static ObjectSet Sort2DSet(ObjectSet inputObjectSet, ObjectOrdering ordering)
		{
			switch (ordering)
			{
				case (ObjectOrdering.ByWidth):
					return inputObjectSet.OrderByDescending(x => (x as Object2D).Width).ToObjectList();
				case (ObjectOrdering.ByHeight):
					return inputObjectSet.OrderByDescending(x => (x as Object2D).Height).ToObjectList();
				case (ObjectOrdering.ByArea):
					return inputObjectSet.OrderByDescending(x => (x as Object2D).Area).ToObjectList();
				case (ObjectOrdering.ByPerimeter):
					return inputObjectSet.OrderByDescending(x => (x as Object2D).Perimeter).ToObjectList();
				case (ObjectOrdering.BySideDifference):
					return inputObjectSet.OrderByDescending(x => Math.Abs((x as Object2D).Width - (x as Object2D).Height)).ToObjectList();
				case (ObjectOrdering.BySideRatio):
					return inputObjectSet.OrderByDescending(x => (x as Object2D).Width > (x as Object2D).Height ? (x as Object2D).Width / (x as Object2D).Height : (x as Object2D).Height / (x as Object2D).Width).ToObjectList();
				case (ObjectOrdering.ByLongest):
					return inputObjectSet.OrderByDescending(x => (x as Object2D).Width > (x as Object2D).Height ? (x as Object2D).Width : (x as Object2D).Height).ToObjectList();
				case (ObjectOrdering.ByShortest):
					return inputObjectSet.OrderByDescending(x => (x as Object2D).Width > (x as Object2D).Height ? (x as Object2D).Height : (x as Object2D).Width).ToObjectList();
				default:
					throw new CannotSortObjectsException("Cannot sort 2d objects with given: " + ordering + " ordering strategy");
			}
		}

		private static ObjectSet Sort3DSet(ObjectSet inputObjectSet, ObjectOrdering ordering)
		{
			switch (ordering)
			{
				case (ObjectOrdering.ByWidth):
					return inputObjectSet.OrderByDescending(x => (x as Object3D).Width).ToObjectList();
				case (ObjectOrdering.ByHeight):
					return inputObjectSet.OrderByDescending(x => (x as Object3D).Height).ToObjectList();
				case (ObjectOrdering.ByDepth):
					return inputObjectSet.OrderByDescending(x => (x as Object3D).Depth).ToObjectList();
				case (ObjectOrdering.ByVolume):
					return inputObjectSet.OrderByDescending(x => (x as Object3D).Volume).ToObjectList();
				case (ObjectOrdering.BySurfaceArea):
					return inputObjectSet.OrderByDescending(x => (x as Object3D).SurfaceArea).ToObjectList();
				case (ObjectOrdering.ByWidthHeightDifference):
					return inputObjectSet.OrderByDescending(x => Math.Abs((x as Object3D).Width - (x as Object3D).Height)).ToObjectList();
				case (ObjectOrdering.ByWidthHeightRatio):
					return inputObjectSet.OrderByDescending(x => (x as Object3D).Width > (x as Object3D).Height ? (x as Object3D).Width / (x as Object3D).Height : (x as Object3D).Height / (x as Object3D).Width).ToObjectList();
				case (ObjectOrdering.ByWidthDepthDifference):
					return inputObjectSet.OrderByDescending(x => Math.Abs((x as Object3D).Width - (x as Object3D).Depth)).ToObjectList();
				case (ObjectOrdering.ByWidthDepthRatio):
					return inputObjectSet.OrderByDescending(x => (x as Object3D).Width > (x as Object3D).Depth ? (x as Object3D).Width / (x as Object3D).Depth : (x as Object3D).Depth / (x as Object3D).Width).ToObjectList();
				case (ObjectOrdering.ByHeightDepthDifference):
					return inputObjectSet.OrderByDescending(x => Math.Abs((x as Object3D).Height - (x as Object3D).Depth)).ToObjectList();
				case (ObjectOrdering.ByHeightDepthRatio):
					return inputObjectSet.OrderByDescending(x => (x as Object3D).Height > (x as Object3D).Depth ? (x as Object3D).Height / (x as Object3D).Depth : (x as Object3D).Depth / (x as Object3D).Height).ToObjectList();
				case (ObjectOrdering.ByLongest):
					return inputObjectSet.OrderByDescending(x => Math.Max((x as Object3D).Width, Math.Max((x as Object3D).Height, (x as Object3D).Depth))).ToObjectList();
				case (ObjectOrdering.ByShortest):
					return inputObjectSet.OrderByDescending(x => Math.Min((x as Object3D).Width, Math.Min((x as Object3D).Height, (x as Object3D).Depth))).ToObjectList();
				default:
					throw new CannotSortObjectsException("Cannot sort 3d objects with given: " + ordering + " ordering strategy");
			}
		}

		
	}
}
