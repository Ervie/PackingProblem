using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain
{
	// Order of sequence indicate longest to shortest dimensions
	public enum ThreeDimensionsRelation
	{
		WidthHeightDepth,
		WidthDepthHeight,
		HeightWidthDepth,
		HeightDepthWidth,
		DepthWidthHeight,
		DepthHeightWidth
	}
}
