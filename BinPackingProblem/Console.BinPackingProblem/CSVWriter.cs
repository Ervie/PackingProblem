using Console.BinPackingProblem.Exceptions;
using Logic.Algorithms.Enums;
using Logic.Algorithms.Structs;
using Logic.Domain.Containers._2D;
using Logic.Domain.Containers._3D;
using Logic.Domain.Figures;
using Logic.Utilities.Files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console.BinPackingProblem
{
	public static class CSVWriter
	{
		public static string headers = "Dimensionality;Family;Fitting Strategy;Container Splitting Strategy;Object Ordering;Container Size;Average Fulfillent;Quality;Execution Time [ms];Containers Used;Total Object Amount";

		public static void Write(AlgorithmExecutionResults endResults, AlgorithmProperties properties, ObjectOrdering ordering, IFigure initialContainer, string filePath)
		{
			if (!CheckDestinationCSV(filePath))
				FileHelper.CreateNewFile(filePath);
			//throw new InvalidArgumentException($"Cannot access target file at given path {filePath}");

			WriteHeaders(filePath);

			string containerSize = properties.Dimensionality.Equals(AlgorithmDimensionality.TwoDimensional) ? $"{(initialContainer as Container2D).Width}x{(initialContainer as Container2D).Height}" :
				$"{(initialContainer as Container3D).Width}x{(initialContainer as Container3D).Height}x{(initialContainer as Container3D).Depth}";

			File.AppendAllText(filePath,
				$"{properties.Dimensionality};{properties.Family};{properties.AlgorithmType};{properties.SplittingStrategy};{ordering};{containerSize};{endResults.AverageFulfillmentRatio};{endResults.Quality};{endResults.ExecutionTime};{endResults.ContainersUsed};{endResults.ObjectCount}" + Environment.NewLine);

		}

		private static void WriteHeaders(string filePath)
		{
			bool shouldWriteHeaders = false;
			using (StreamReader readtext = new StreamReader(filePath))
			{
				string firstLine = readtext.ReadLine();
				if (string.IsNullOrEmpty(firstLine) || !firstLine.Equals(headers))
				{
					shouldWriteHeaders = true;
				}
			}

			if (shouldWriteHeaders)
			{
				using (StreamWriter writetext = new StreamWriter(filePath))
				{
					writetext.WriteLine(headers);
				}
			}
		}

		private static bool CheckDestinationCSV(string filePath)
		{
			if (FileHelper.HasAccessPermission(filePath) && FileHelper.DirectoryExist(filePath) && FileHelper.FileExist(filePath))
			{
				return true;
			}
			else
				return false;
		}
	}
}
