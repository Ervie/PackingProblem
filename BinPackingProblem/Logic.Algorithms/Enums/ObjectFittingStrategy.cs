using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Algorithms.Enums
{
	public enum ObjectFittingStrategy
	{
		// Shelf
		NextFit,
		FirstFit,
		BestWidthFit,
		BestHeightFit,
		BestAreaFit,
		WorstAreaFit,
		BestShortSideFit,
		WorstShortSideFit,
		BestLongSideFit,
		WorstLongSideFit,
		BottomLeft,
		BestFit,
		FloorCeiling
	}
}
