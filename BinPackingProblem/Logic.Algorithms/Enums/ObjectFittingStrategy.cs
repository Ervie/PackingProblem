using System.ComponentModel;

namespace Logic.Algorithms.Enums
{
	public enum ObjectFittingStrategy
	{
		// Shelf 2D

		[Description("Next Fit")]
		NextFit,

		[Description("First Fit")]
		FirstFit,

		[Description("Best Fit by Width")]
		BestWidthFit,

		[Description("Worst Fit by Width")]
		WorstWidthFit,

		[Description("Best Fit by Height")]
		BestHeightFit,

		// Shelf & Guillotine cut 2D
		[Description("Best Fit by Area")]
		BestAreaFit,

		[Description("Worst Fit by Area")]
		WorstAreaFit,

		// Guillotine cut 2D & 3D
		[Description("Best Fit by Short Side")]
		BestShortSideFit,

		[Description("Worst Fit by Short Side")]
		WorstShortSideFit,

		[Description("Best Fit by Long Side")]
		BestLongSideFit,

		[Description("Worst Fit by Long Side")]
		WorstLongSideFit,

		[Description("Best Fit by Volume")]
		BestVolumeFit,

		[Description("Worst Fit by Volume")]
		WorstVolumeFit,

		// Skyline & Guillotine cut 2D
		[Description("Bottom Left Fit")]
		BottomLeft,

		// Skyline 2D
		[Description("Best Fit with First Container")]
		BestFitFirstContainer,

		[Description("Best Fit with Best Container")]
		BestFitBestContainer
	}
}