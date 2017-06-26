using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain.Objects;

namespace Logic.Domain.Containers._3D.Guillotine
{
	public class GuillotineCutMaxVolumeContainer3D : GuillotineCutContainer3D
	{
		public GuillotineCutMaxVolumeContainer3D(int width, int height, int depth) : base(width, height, depth)
		{
		}

		public override void SplitSubcontainer(GuillotineCutSubcontainer3D subcontainer, PlacedObject3D placedObject)
		{
			var availableVolumeAboveObject = (subcontainer.Height - placedObject.Height) * placedObject.Width * placedObject.Depth;
			var availableVolumeOnTheRightOfObject = placedObject.Height * (subcontainer.Width - placedObject.Width) * placedObject.Depth;
			var availableVolumeBehindObject = placedObject.Height * placedObject.Width * (subcontainer.Depth - placedObject.Depth);

			if ((availableVolumeAboveObject >= availableVolumeOnTheRightOfObject) && (availableVolumeAboveObject >= availableVolumeBehindObject))
			{
				if (availableVolumeOnTheRightOfObject >= availableVolumeBehindObject)
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
			else if ((availableVolumeOnTheRightOfObject >= availableVolumeAboveObject) && (availableVolumeOnTheRightOfObject >= availableVolumeBehindObject))
			{
				if (availableVolumeAboveObject >= availableVolumeBehindObject)
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
			else if ((availableVolumeBehindObject >= availableVolumeAboveObject) && (availableVolumeBehindObject >= availableVolumeOnTheRightOfObject))
			{
				if (availableVolumeAboveObject >= availableVolumeOnTheRightOfObject)
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
