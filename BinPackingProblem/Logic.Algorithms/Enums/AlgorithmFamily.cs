using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Algorithms.Enums
{
	public enum AlgorithmFamily
	{
		[Description("Guillotine Cut")]
		GuillotineCut,
		[Description("Shelf")]
		Shelf,
		[Description("Skyline")]
		Skyline
	}
}
