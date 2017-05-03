using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Algorithms.Enums
{
	public enum ContainerSplittingStrategy
	{
		// For shelf/skyline
		None,
		// For guillotine cut
		LongerAxisSplitRule,
		ShorterAxisSplitRule,
		LongerLeftoverAxisSplitRule,
		ShorterLeftoverAxisSplitRule,
		MaxAreaSplitRule,
		MinAreaSplitRule
	}
}
