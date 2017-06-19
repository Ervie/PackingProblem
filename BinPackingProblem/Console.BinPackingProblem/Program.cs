using Logic.Algorithms;
using Logic.Algorithms.Enums;
using Logic.Algorithms.Structs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console.BinPackingProblem
{


	internal class Program
	{
		public static string[] arguments = { "-d", "-t", "-o", "-s" };
		public static string[] dimensionalities = { "3", "2",};
		public static string[] algorithTypes = { "ShN", "ShF", "ShBA", "ShBW", "ShBH", "ShWA", "ShWW", "SkBL", "SkBFFC", "SkBFBC",
		"GBA", "GWA", "GBSS", "GWSS", "GBLS", "GWLS", "GBL"};
		public static string[] orderings = { "N", "W", "H", "D", "L", "S", "P", "A", "V", "PA", "SA", "SR", "WHR", "WHD",
		"WDR", "WDD", "HDR", "HDD"};
		public static string[] splittingStrategies = { "MinA", "MaxA", "LA", "LL", "SA", "SL" };

		public static string InputFilePath { get; set; }

		public static string OutputFilePath { get; set; }

		public static AlgorithmProperties Properties { get; set; }

		public static ObjectOrdering Ordering { get; set; }

		static void Main(string[] args)
		{
			if (args.Count() < 2)
			{
				System.Console.WriteLine("Input or output file is not specified");
				DisplayHelp();
			}
			else
			{
				try
				{
					ProcessArguments(args);
				}
				catch (Exception er)
				{
					System.Console.WriteLine($"Error during computing: {er.Message}" );
					DisplayHelp();
				}
			}

			System.Console.ReadKey();
		}

		private static void ProcessArguments(string[] args)
		{
			InputFilePath = args[0];

			string pathWithoutFile = Path.GetDirectoryName(InputFilePath);

			if (!Directory.Exists(pathWithoutFile))
			{
				Directory.CreateDirectory(pathWithoutFile);
			}

			if (!File.Exists(InputFilePath))
			{
				File.Create(InputFilePath);
			}

			OutputFilePath = Path.GetDirectoryName(InputFilePath) + args.Last();

			if (!OutputFilePath.EndsWith(".csv"))
				OutputFilePath += ".csv";

			if (args.Count() > 3 && arguments.Contains(args[2]))
				RecognizePair(args[2], args[3]);
			if (args.Count() > 5 && arguments.Contains(args[4]))
				RecognizePair(args[4], args[5]);
			if (args.Count() > 7 && arguments.Contains(args[6]))
				RecognizePair(args[6], args[7]);
			if (args.Count() > 9 && arguments.Contains(args[8]))
				RecognizePair(args[8], args[9]);


			var factory = new AlgorithmFactory();
			//var algorithm = factory.Create(Properties);
		}

		private static void RecognizePair(string argumentType, string argumentValue)
		{
			switch (argumentType)
			{
				case ("-d"):
					Properties.Dimensionality = SetDimensionality(argumentValue);
					break;
				case ("-t"):
					Properties.Family = SetFamily(argumentValue);
					Properties.AlgorithmType = SetObjectFittingStrategy(argumentValue);
					break;
				case ("-o"):
					Ordering = SetOrdering(argumentValue);
					break;
				case ("-s"):
					Properties.SplittingStrategy = SetSplittingStrategy(argumentValue);
					break;
			}
		}

		private static AlgorithmDimensionality SetDimensionality(string argumentValue)
		{
			switch(argumentValue)
			{
				case ("2"):
					return AlgorithmDimensionality.TwoDimensional;
				case ("3"):
					return AlgorithmDimensionality.ThreeDimensional;
				default:
					throw new InvalidArgumentException();
			}
		}

		private static AlgorithmFamily SetFamily(string argumentValue)
		{
			switch (argumentValue)
			{
				case ("ShN"):
				case ("ShF"):
				case ("ShBA"):
				case ("ShBH"):
				case ("ShBW"):
				case ("ShWA"):
				case ("ShWW"):
					return AlgorithmFamily.Shelf;
				case ("SkBL"):
				case ("SkBFFC"):
				case ("SkBFBC"):
					return AlgorithmFamily.Skyline;
				case ("GBA"):
				case ("GWA"):
				case ("GBSS"):
				case ("GWSS"):
				case ("GWLS"):
				case ("GBLS"):
				case ("GWBL"):
					return AlgorithmFamily.GuillotineCut;
				default:
					throw new InvalidArgumentException();
			}
		}

		private static ObjectFittingStrategy SetObjectFittingStrategy(string argumentValue)
		{
			switch (argumentValue)
			{
				case ("ShN"):
					return ObjectFittingStrategy.NextFit;
				case ("ShF"):
					return ObjectFittingStrategy.FirstFit;
				case ("ShBA"):
				case ("GBA"):
					return ObjectFittingStrategy.BestAreaFit;
				case ("ShBH"):
					return ObjectFittingStrategy.BestHeightFit;
				case ("ShBW"):
					return ObjectFittingStrategy.BestWidthFit;
				case ("ShWA"):
				case ("GWA"):
					return ObjectFittingStrategy.WorstAreaFit;
				case ("ShWW"):
					return ObjectFittingStrategy.WorstWidthFit;
				case ("SkBL"):
				case ("GWBL"):
					return ObjectFittingStrategy.BottomLeft;
				case ("SkBFFC"):
					return ObjectFittingStrategy.BestFitFirstContainer;
				case ("SkBFBC"):
					return ObjectFittingStrategy.BestFitBestContainer;
				case ("GBSS"):
					return ObjectFittingStrategy.BestShortSideFit;
				case ("GWSS"):
					return ObjectFittingStrategy.WorstShortSideFit;
				case ("GWLS"):
					return ObjectFittingStrategy.WorstLongSideFit;
				case ("GBLS"):
					return ObjectFittingStrategy.BestLongSideFit;
				default:
					throw new InvalidArgumentException();
			}
		}

		private static ContainerSplittingStrategy SetSplittingStrategy(string argumentValue)
		{
			switch (argumentValue)
			{
				case ("MaxA"):
					return ContainerSplittingStrategy.MaxAreaSplitRule;
				case ("MinA"):
					return ContainerSplittingStrategy.MinAreaSplitRule;
				case ("LA"):
					return ContainerSplittingStrategy.LongerAxisSplitRule;
				case ("LL"):
					return ContainerSplittingStrategy.LongerLeftoverAxisSplitRule;
				case ("SA"):
					return ContainerSplittingStrategy.ShorterAxisSplitRule;
				case ("SL"):
					return ContainerSplittingStrategy.ShorterLeftoverAxisSplitRule;
				default:
					throw new InvalidArgumentException();
			}
		}

		private static ObjectOrdering SetOrdering(string argumentValue)
		{
			switch (argumentValue)
			{
				case ("N"):
					return ObjectOrdering.None;
				case ("W"):
					return ObjectOrdering.ByWidth;
				case ("H"):
					return ObjectOrdering.ByHeight;
				case ("D"):
					return ObjectOrdering.ByDepth;
				case ("L"):
					return ObjectOrdering.ByLongest;
				case ("S"):
					return ObjectOrdering.ByShortest;
				case ("P"):
					return ObjectOrdering.ByPerimeter;
				case ("A"):
					return ObjectOrdering.ByArea;
				case ("V"):
					return ObjectOrdering.ByVolume;
				case ("SA"):
					return ObjectOrdering.BySurfaceArea;
				case ("SR"):
					return ObjectOrdering.BySideRatio;
				case ("SD"):
					return ObjectOrdering.BySideDifference;
				case ("WHR"):
					return ObjectOrdering.ByWidthHeightRatio;
				case ("WHD"):
					return ObjectOrdering.ByWidthHeightDifference;
				case ("WDR"):
					return ObjectOrdering.ByWidthDepthRatio;
				case ("WDD"):
					return ObjectOrdering.ByWidthDepthDifference;
				case ("HDR"):
					return ObjectOrdering.ByHeightDepthRatio;
				case ("HDD"):
					return ObjectOrdering.ByHeightDepthDifference;
				default:
					throw new InvalidArgumentException();
			}
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
			sb.AppendLine("GBL - Guillotine cut Bottom left");
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
			sb.AppendLine("V - By volume");
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
