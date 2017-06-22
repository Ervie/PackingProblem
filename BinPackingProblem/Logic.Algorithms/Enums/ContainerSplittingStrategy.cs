using System.ComponentModel;

namespace Logic.Algorithms.Enums
{
	public enum ContainerSplittingStrategy
	{
		None,

		// For guillotine cut 2D and 3D
		[Description("Split by longer axis")]
		LongerAxisSplitRule,

		[Description("Split by shorter axis")]
		ShorterAxisSplitRule,

		[Description("Split by longer leftover axis")]
		LongerLeftoverAxisSplitRule,

		[Description("Split by shorter leftover axis")]
		ShorterLeftoverAxisSplitRule,

		// For guillotine cut 2D
		[Description("Split by max area")]
		MaxAreaSplitRule,

		[Description("Split by min area")]
		MinAreaSplitRule,

		// For guillotine cut 3D
		[Description("Split by max volume")]
		MaxVolumeSplitRule,

		[Description("Split by min volume")]
		MinVolumeSplitRule
	}
}