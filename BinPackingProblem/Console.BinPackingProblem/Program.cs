using Console.BinPackingProblem.Exceptions;
using Logic.Algorithms;
using Logic.Algorithms.Containers;
using Logic.Algorithms.Enums;
using Logic.Algorithms.Sorting;
using Logic.Algorithms.Structs;
using Logic.Domain.Containers._2D;
using Logic.Domain.Containers._3D;
using Logic.Domain.Figures;
using Logic.Domain.Objects;
using Logic.ObjectGenerator;
using Logic.Utilities.Files;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Console.BinPackingProblem
{


	internal class Program
	{
		public static string[] arguments = { "-d", "-t", "-o", "-s" };
		public static string[] dimensionalities = { "3", "2",};
		public static string[] algorithTypes = { "ShN", "ShF", "ShBA", "ShBW", "ShBH", "ShWA", "ShWW", "SkBL", "SkBFFC", "SkBFBC",
		"GBA", "GWA", "GBV", "GWV", "GBSS", "GWSS", "GBLS", "GWLS", "GBL"};
		public static string[] orderings = { "N", "W", "H", "D", "L", "S", "P", "A", "V", "PA", "SA", "SR", "WHR", "WHD",
		"WDR", "WDD", "HDR", "HDD"};
		public static string[] splittingStrategies = { "N", "MinA", "MaxA", "MinV", "MaxV", "LA", "LL", "SA", "SL" };

		public static string InputFilePath { get; set; }

		public static string OutputFilePath { get; set; }

		public static int ContainerWidth { get; set; }

		public static int ContainerHeight { get; set; }

		public static int ContainerDepth { get; set; }
		public static AlgorithmProperties Properties { get; set; }

		public static ObjectOrdering Ordering { get; set; }

		static void Main(string[] args)
		{
			if (args.Count() == 1)
			{
				if (args[0].Equals("-h"))
					DisplayHelp();
			}
			else if (args.Count() < 4)
			{
				System.Console.WriteLine("Input or output file is not specified");
				DisplayHelp();
			}
			else
			{
				try
				{
					ProcessArguments(args);
					RunAlgorithm();
					System.Console.WriteLine("Successfully ended computation");
				}
				catch (Exception er)
				{
					System.Console.WriteLine($"Error during computing: {er.Message}" );
					DisplayHelp();
					System.Console.ReadKey();
				}
			}
		}

		private static void ProcessArguments(string[] args)
		{
			InputFilePath = args[0];

			string pathWithoutFile = Path.GetDirectoryName(InputFilePath);
			string fileWithoutPath = Path.GetFileName(InputFilePath);

			bool hasThreeSizes = false;

			if (string.IsNullOrEmpty(pathWithoutFile))
			{
				pathWithoutFile = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
			}
			else if (!Directory.Exists(pathWithoutFile))
			{
				Directory.CreateDirectory(pathWithoutFile);
			}

			InputFilePath = pathWithoutFile + "//" + fileWithoutPath;

			OutputFilePath = args.Last();

			if (!Directory.Exists(OutputFilePath) && !File.Exists(OutputFilePath))
			{
				OutputFilePath = pathWithoutFile + "\\" + OutputFilePath;
				if (!File.Exists(OutputFilePath))
					File.Create(OutputFilePath);
			}

			if (!OutputFilePath.EndsWith(".csv"))
				OutputFilePath += ".csv";

			ContainerWidth = Int32.Parse(args[1]);
			ContainerHeight = Int32.Parse(args[2]);

			int tmpDepth;

			if (Int32.TryParse(args[3], out tmpDepth))
			{
				ContainerDepth = tmpDepth;
				hasThreeSizes = true;
			}

			Properties = new AlgorithmProperties();

			if (hasThreeSizes)
			{
				if (args.Count() > 5 && arguments.Contains(args[4]))
					RecognizePair(args[4], args[5]);
				if (args.Count() > 7 && arguments.Contains(args[6]))
					RecognizePair(args[6], args[7]);
				if (args.Count() > 9 && arguments.Contains(args[8]))
					RecognizePair(args[8], args[9]);
				if (args.Count() > 11 && arguments.Contains(args[10]))
					RecognizePair(args[10], args[11]);
			}
			else
			{
				if (args.Count() > 4 && arguments.Contains(args[3]))
					RecognizePair(args[3], args[4]);
				if (args.Count() > 6 && arguments.Contains(args[5]))
					RecognizePair(args[5], args[6]);
				if (args.Count() > 8 && arguments.Contains(args[7]))
					RecognizePair(args[7], args[8]);
				if (args.Count() > 10 && arguments.Contains(args[9]))
					RecognizePair(args[9], args[10]);
			}

		}

		private static void RunAlgorithm()
		{
			IFigure startingContainer;
			IAlgorithm algorithm;
			Stopwatch stopwatch = new Stopwatch();
			IContainerFactory containerFactory = new ContainerFactory();
			IAlgorithmFactory factory = new AlgorithmFactory();



			if (Properties.Dimensionality == AlgorithmDimensionality.TwoDimensional)
			{
				startingContainer = containerFactory.Create(Properties, ContainerWidth, ContainerHeight);
				algorithm = factory.Create(Properties, startingContainer);
			}
			else
			{
				startingContainer = containerFactory.Create(Properties, ContainerWidth, ContainerHeight, ContainerDepth);
				algorithm = factory.Create(Properties, startingContainer);
			}

			ObjectSet objectsToPack = LoadObjectSet();

			if (!CheckContainerSize(objectsToPack))
				throw new InvalidContainerSizeException("Container is not big enough to contain biggest object. Enlarge the container.");


			stopwatch.Reset();

			var sortedObjects = SortingHelper.Sort(objectsToPack, Ordering);

			stopwatch.Start();
			algorithm.Execute(sortedObjects);
			stopwatch.Stop();

			var endResults = algorithm.CreateResults();

			endResults.ExecutionTime = stopwatch.ElapsedMilliseconds;

			WriteResiltsToCsv(endResults, startingContainer);
		}

		private static ObjectSet LoadObjectSet()
		{
			ObjectGenerator generator = new ObjectGenerator();

			if (FileHelper.HasAccessPermission(InputFilePath) && FileHelper.DirectoryExist(InputFilePath))
			{
				return generator.LoadObjectSet(InputFilePath);
			}
			else
				throw new InvalidArgumentException($"Cannot access data set on given path: {InputFilePath}");
		}

		private static void WriteResiltsToCsv(AlgorithmExecutionResults endResults, IFigure initialContainer)
		{
			CSVWriter.Write(endResults, Properties, Ordering, initialContainer, OutputFilePath);
		}

		/// <summary>
		/// Check if container(s) is(are) big enough to contain every object.
		/// </summary>
		/// <returns>True - big enough, false - not</returns>
		private static bool CheckContainerSize(ObjectSet objectsToPack)
		{
			if (Properties.Dimensionality == AlgorithmDimensionality.TwoDimensional)
			{
				if (objectsToPack.Max(x => (x as Object2D).Height) > ContainerHeight ||
					objectsToPack.Max(x => (x as Object2D).Width) > ContainerWidth)
					return false;
			}
			else
			{
				if (objectsToPack.Max(x => (x as Object3D).Height) > ContainerHeight ||
					objectsToPack.Max(x => (x as Object3D).Width) > ContainerWidth ||
					objectsToPack.Max(x => (x as Object3D).Depth) > ContainerDepth)
					return false;
			}

			return true;
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
				case ("GBV"):
				case ("GWV"):
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
				case ("GWV"):
					return ObjectFittingStrategy.WorstVolumeFit;
				case ("GBV"):
					return ObjectFittingStrategy.BestVolumeFit;
				default:
					throw new InvalidArgumentException();
			}
		}

		private static ContainerSplittingStrategy SetSplittingStrategy(string argumentValue)
		{
			switch (argumentValue)
			{
				case ("None"):
					return ContainerSplittingStrategy.None;
				case ("MaxA"):
					return ContainerSplittingStrategy.MaxAreaSplitRule;
				case ("MinA"):
					return ContainerSplittingStrategy.MinAreaSplitRule;
				case ("MaxV"):
					return ContainerSplittingStrategy.MaxVolumeSplitRule;
				case ("MinV"):
					return ContainerSplittingStrategy.MinVolumeSplitRule;
				case ("LA"):
					return ContainerSplittingStrategy.LongerAxisSplitRule;
				case ("LL"):
					return ContainerSplittingStrategy.LongerLeftoverAxisSplitRule;
				case ("SA"):
					return ContainerSplittingStrategy.ShorterAxisSplitRule;
				case ("SL"):
					return ContainerSplittingStrategy.ShorterLeftoverAxisSplitRule;
				default:
					return ContainerSplittingStrategy.None;
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

			sb.AppendLine("Format of arguments: <input_set> <container_size> [options] <result_file>");
			sb.AppendLine("input_set - file of .2Dset or .3Dset");
			sb.AppendLine("container_size - two (for 2D algorithms) or three (for 3D algorithms) integer numbers representing width and height of container (optionally) depth");
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
			sb.AppendLine("GBV - Guillotine cut best volume");
			sb.AppendLine("GWV - Guillotine cut worst volume");
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
