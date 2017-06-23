using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain.Objects;

namespace Logic.Domain.Containers._3D.Guillotine
{
	public class GuillotineCutLongerLeftoverAxisContainer3D : GuillotineCutContainer3D
	{
		public GuillotineCutLongerLeftoverAxisContainer3D(int width, int height, int depth) : base(width, height, depth)
		{
		}

		public override void SplitSubcontainer(GuillotineCutSubcontainer3D subcontainer, PlacedObject3D placedObject)
		{
			var leftoverHeight = subcontainer.Height - placedObject.Height;
			var leftoverWidth = subcontainer.Width - placedObject.Width;
			var leftoverDepth = subcontainer.Depth - placedObject.Depth;

			if ((leftoverHeight > leftoverWidth) && (leftoverHeight > leftoverDepth))
			{
				if (leftoverWidth > leftoverDepth)
				{
					SplitSubcontainerVerticallyThenHorizontally(subcontainer, placedObject);
					//Console.WriteLine("{0} {1} {2}", a, b, c);
				}
				else
				{
					SplitSubcontainerVerticallyThenDepth(subcontainer, placedObject);
					//Console.WriteLine("{0} {1} {2}", a, c, b);
				}
			}
			else if ((leftoverWidth > leftoverHeight) && (leftoverWidth > leftoverDepth))
			{
				if (leftoverHeight > leftoverDepth)
				{
					SplitSubcontainerHorizontallyThenVertically(subcontainer, placedObject);
					//Console.WriteLine("{0} {1} {2}", b, a, c);
				}
				else
				{
					SplitSubcontainerHorizontallyThenDepth(subcontainer, placedObject);
					//Console.WriteLine("{0} {1} {2}", b, c, a);
				}
			}
			else if ((leftoverDepth > leftoverHeight) && (leftoverDepth > leftoverWidth))
			{
				if (leftoverHeight > leftoverWidth)
				{
					SplitSubcontainerDepthThenVertically(subcontainer, placedObject);
					//Console.WriteLine("{0} {1} {2}", c, a, b);
				}
				else
				{
					SplitSubcontainerDepthThenHorizontally(subcontainer, placedObject);
					//Console.WriteLine("{0} {1} {2}", c, b, a);
				}
			}
		}
	}
}
