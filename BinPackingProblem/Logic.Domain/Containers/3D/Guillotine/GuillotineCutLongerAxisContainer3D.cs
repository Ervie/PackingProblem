using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain.Objects;

namespace Logic.Domain.Containers._3D.Guillotine
{
	public class GuillotineCutLongerAxisContainer3D : GuillotineCutContainer3D
	{
		public GuillotineCutLongerAxisContainer3D(int width, int height, int depth) : base(width, height, depth)
		{
		}

		public override void SplitSubcontainer(GuillotineCutSubcontainer3D subcontainer, PlacedObject3D placedObject)
		{
			if ((subcontainer.Height > subcontainer.Width) && (subcontainer.Height > subcontainer.Depth))
			{
				if (subcontainer.Width > subcontainer.Depth)
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
			else if ((subcontainer.Width > subcontainer.Height) && (subcontainer.Width > subcontainer.Depth))
			{
				if (subcontainer.Height > subcontainer.Depth)
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
			else if ((subcontainer.Depth > subcontainer.Height) && (subcontainer.Depth > subcontainer.Width))
			{
				if (subcontainer.Height > subcontainer.Width)
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
