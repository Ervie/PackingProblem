using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain.Objects;

namespace Logic.Domain.Containers._3D.Guillotine
{
	public class GuillotineCutMinVolumeContainer3D : GuillotineCutContainer3D
	{
		public GuillotineCutMinVolumeContainer3D(int width, int height, int depth) : base(width, height, depth)
		{
		}

		public override void SplitSubcontainer(GuillotineCutSubcontainer3D subcontainer, PlacedObject3D placedObject)
		{
			var availableVolumeAboveObject = (subcontainer.Height - placedObject.Height) * placedObject.Width * placedObject.Depth;
			var availableVolumeOnTheRightOfObject = placedObject.Height * (subcontainer.Width - placedObject.Width) * placedObject.Depth;
			var availableVolumeBehindObject = placedObject.Height * placedObject.Width * (subcontainer.Depth - placedObject.Depth);

			if ((availableVolumeAboveObject < availableVolumeOnTheRightOfObject) && (availableVolumeAboveObject < availableVolumeBehindObject))
			{
				if (availableVolumeOnTheRightOfObject < availableVolumeBehindObject)
				{
					SplitSubcontainerVerticallyThenHorizontally(subcontainer, placedObject);
				}
				else
				{
					SplitSubcontainerVerticallyThenDepth(subcontainer, placedObject);
				}
			}
			else if ((availableVolumeOnTheRightOfObject < availableVolumeAboveObject) && (availableVolumeOnTheRightOfObject < availableVolumeBehindObject))
			{
				if (availableVolumeAboveObject < availableVolumeBehindObject)
				{
					SplitSubcontainerHorizontallyThenVertically(subcontainer, placedObject);
				}
				else
				{
					SplitSubcontainerHorizontallyThenDepth(subcontainer, placedObject);
				}
			}
			else if ((availableVolumeBehindObject < availableVolumeAboveObject) && (availableVolumeBehindObject < availableVolumeOnTheRightOfObject))
			{
				if (availableVolumeAboveObject < availableVolumeOnTheRightOfObject)
				{
					SplitSubcontainerDepthThenVertically(subcontainer, placedObject);
				}
				else
				{
					SplitSubcontainerDepthThenHorizontally(subcontainer, placedObject);
				}
			}
		}
	}
}
