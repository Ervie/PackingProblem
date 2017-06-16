using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console.BinPackingProblem
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Count() < 2)
			{
				System.Console.WriteLine("Input or output file is not specified");
				DisplayHelp();
			}
			else
			{
				RecognizeArguments(args);
			}

			System.Console.ReadKey();
		}

		private static void RecognizeArguments(string[] args)
		{
			throw new NotImplementedException();
		}

		private static void DisplayHelp()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine("Format of arguments: <input_set> [options] <result_file>");
			sb.AppendLine("input_set - file of .2Dset or .3Dset");
			sb.AppendLine("result_file - .csv file containing information of carried experiments");
			sb.AppendLine("Format of options - -d <dimensionality> -t <type> -o <ordering> -s <splitting_strategy>");
			sb.AppendLine("");
			sb.AppendLine("Dimensionality values: 2 for 2D object, 3 for 3D objects");
			sb.AppendLine("");
			sb.AppendLine("Type values: ");
			sb.AppendLine("ShN - Shelf next fit");
			sb.AppendLine("ShF - Shelf first fit");
			sb.AppendLine("ShBA - Shelf best fit by area");
			sb.AppendLine("ShBW - Shelf best fit by width");
			sb.AppendLine("ShBH - Shelf best fit by height");
			sb.AppendLine("ShWA - Shelf worst fit by area");
			sb.AppendLine("ShWW - Shelf worst fit by width");
			sb.AppendLine("SkBL - Skyline bottom left");
			sb.AppendLine("SkBFFC - Skyline best fit first container");
			sb.AppendLine("SkBFBC - Skyline best fit best container");
			sb.AppendLine("GBA - Guillotine cut best area");
			sb.AppendLine("GWA - Guillotine cut worst area");
			sb.AppendLine("GBSS - Guillotine cut best short side");
			sb.AppendLine("GWSS - Guillotine cut worst short side");
			sb.AppendLine("GBLS - Guillotine cut best long side");
			sb.AppendLine("GWLS - Guillotine cut worst long side");
			sb.AppendLine("GWLS - Guillotine cut Bottom left");
			sb.AppendLine("");
			sb.AppendLine("Ordering values:");
			sb.AppendLine("N - none");
			sb.AppendLine("W - By width");
			sb.AppendLine("H - By height");
			sb.AppendLine("D - By depth");
			sb.AppendLine("L - By longest");
			sb.AppendLine("S - By shortest");
			sb.AppendLine("P - By perimeter");
			sb.AppendLine("A - By area");
			sb.AppendLine("SA - By surface area");
			sb.AppendLine("SR - By side ratio");
			sb.AppendLine("SD - By side difference");
			sb.AppendLine("WHR - By width-height ratio");
			sb.AppendLine("WHD - By width-height difference");
			sb.AppendLine("WDR - By width-depth ratio");
			sb.AppendLine("WDD - By width-depth difference");
			sb.AppendLine("HDR - By height-depth ratio");
			sb.AppendLine("HDD - By height-depth difference");
			sb.AppendLine("");
			sb.AppendLine("Splitting strategy values (applies only to guillotine cut algorithm:");
			sb.AppendLine("N - none");
			sb.AppendLine("MinA - By minimum area");
			sb.AppendLine("MaxA - By maximum area");
			sb.AppendLine("LA - By longer axis");
			sb.AppendLine("LL - By longer leftover");
			sb.AppendLine("SA - By shorter axis");
			sb.AppendLine("SL - By shorter leftover");

			System.Console.WriteLine(sb);
		}
	}
}
