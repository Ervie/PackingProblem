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
		WorstWidthFit,
		BestHeightFit,
		BestAreaFit,
		WorstAreaFit,
		// Guillotine cut
		BestShortSideFit,
		WorstShortSideFit,
		BestLongSideFit,
		WorstLongSideFit,
		// Skyline
		BottomLeft,
		BestFitFirstContainer,
		BestFitBestContainer,
		// ? Probably to delete
		FloorCeiling
	}
}
