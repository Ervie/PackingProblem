using System.ComponentModel;

namespace Logic.Algorithms.Enums
{
	public enum ContainerSplittingStrategy
	{
		None,

		// For guillotine cut
		[Description("Split by longer axis")]
		LongerAxisSplitRule,

		[Description("Split by shorter axis")]
		ShorterAxisSplitRule,

		[Description("Split by longer leftover axis")]
		LongerLeftoverAxisSplitRule,

		[Description("Split by shorter leftover axis")]
		ShorterLeftoverAxisSplitRule,

		[Description("Split by max area")]
		MaxAreaSplitRule,

		[Description("Split by min axis")]
		MinAreaSplitRule
	}
}