using System.ComponentModel;

namespace Logic.Algorithms.Enums
{
	public enum ObjectFittingStrategy
	{
		// Shelf

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

		// Shelf & Guillotine cut
		[Description("Best Fit by Area")]
		BestAreaFit,

		[Description("Worst Fit by Area")]
		WorstAreaFit,

		// Guillotine cut
		[Description("Best Fit by Short Side")]
		BestShortSideFit,

		[Description("Worst Fit by Short Side")]
		WorstShortSideFit,

		[Description("Best Fit by Long Side")]
		BestLongSideFit,

		[Description("Worst Fit by Long Side")]
		WorstLongSideFit,

		// Skyline & Guillotine cut
		[Description("Bottom Left Fit")]
		BottomLeft,

		// Skyline 
		[Description("Best Fit with First Container")]
		BestFitFirstContainer,

		[Description("Best Fit with Best Container")]
		BestFitBestContainer
	}
}