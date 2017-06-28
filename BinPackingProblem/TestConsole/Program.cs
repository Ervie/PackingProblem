using Logic.Algorithms;
using Logic.Algorithms.Enums;
using Logic.Algorithms.Sorting;
using Logic.Algorithms.Structs;
using Logic.Domain.Containers._2D.Guillotine;
using Logic.Domain.Containers._2D.Shelf;
using Logic.Domain.Containers._2D.Skyline;
using Logic.Domain.Containers._3D.Guillotine;
using Logic.Domain.Containers._3D.Shelf;
using Logic.Domain.Objects;
using Logic.ObjectGenerator;
using Logic.Utilities.Extensions;
using System.Linq;

namespace TestConsole
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			ObjectGenerator generator = new ObjectGenerator();

			var testSet = generator.Generate2DObjectSet(new ObjectSetProperties2D()
			{
				ObjectAmount = 1000,
				AverageObjectWidthHeightRatio = 1,
				ObjectWidthHeightRatioStandardDeviation = 0.5m,
				MaxObjectWidthHeightRatio = 5,
				MinObjectWidthHeightRatio = 0.2m,

				AverageObjectArea = 100,
				ObjectAreaStandardDeviation = 20,
				MaxObjectArea = 200,
				MinObjectArea = 10
			});

			//foreach (var element in testSet)
			//{
			//	Console.WriteLine("Object w = {0}, h = {1}", (element as Object2D).Width, (element as Object2D).Height);
			//}

			//generator.SaveObjectSet(testSet, "C:\\Users\\bbuchala\\Documents\\Git Repos\\PackingProblem\\BinPackingProblem\\Data\\test2d.set");
			//generator.SaveObjectSet(testSet, "E:\\test2d.2Dset");

			testSet = generator.Generate3DObjectSet(new ObjectSetProperties3D()
			{
				ObjectAmount = 10000,
				AverageObjectWidthHeightRatio = 1,
				ObjectWidthHeightRatioStandardDeviation = 1,
				MaxObjectWidthHeightRatio = 5,
				MinObjectWidthHeightRatio = 0.5m,

				AverageObjectDepthHeightRatio = 1,
				ObjectDepthHeightRatioStandardDeviation = 1,
				MaxObjectDepthHeightRatio = 5,
				MinObjectDepthHeightRatio = 0.5m,

				AverageObjectVolume = 500,
				VolumeStandardDeviation = 50,
				MaxVolume = 1000,
				MinVolume = 100
			});

			//foreach (var element in testSet)
			//{
			//    Console.WriteLine("Object w = {0}, h = {1}, d = {2}", (element as Object3D).Width, (element as Object3D).Height, (element as Object3D).Depth);
			//}

			generator.SaveObjectSet(testSet, @"C:\Users\bbuchala\Documents\Git Repos\PackingProblem\BinPackingProblem\Data\test3d.3Dset");

			ObjectSet objectSet3d = generator.LoadObjectSet(@"C:\Users\bbuchala\Documents\Git Repos\PackingProblem\BinPackingProblem\Data\test3d.3Dset");

			//var objectSet3d = generator.LoadObjectSet("E:\\test3d.set");

			//ObjectSet sortedObjectSet = objectSet2d.OrderBy(x => (x as Object2D).Width).ToObjectList();

			//IAlgorithmFactory factory = new AlgorithmFactory();
			//IAlgorithm algo = factory.Create(new AlgorithmProperties()
			//{
			//	Dimensionality = Logic.Algorithms.Enums.AlgorithmDimensionality.TwoDimensional,
			//	Family = Logic.Algorithms.Enums.AlgorithmFamily.Shelf,
			//	AlgorithmType = Logic.Algorithms.Enums.ObjectFittingStrategy.NextFit,
			//	SplittingStrategy = Logic.Algorithms.Enums.ContainerSplittingStrategy.None
			//}, new ShelfContainer2D(40, 50));

			//algo.Execute(objectSet2d);

			//var results = algo.CreateResults();

			//algo = factory.Create(new AlgorithmProperties()
			//{
			//	Dimensionality = Logic.Algorithms.Enums.AlgorithmDimensionality.TwoDimensional,
			//	Family = Logic.Algorithms.Enums.AlgorithmFamily.Shelf,
			//	AlgorithmType = Logic.Algorithms.Enums.ObjectFittingStrategy.FirstFit,
			//	SplittingStrategy = Logic.Algorithms.Enums.ContainerSplittingStrategy.None
			//}, new ShelfContainer2D(40, 50));

			//algo.Execute(objectSet2d);

			//var results2 = algo.CreateResults();

			//algo = factory.Create(new AlgorithmProperties()
			//{
			//	Dimensionality = Logic.Algorithms.Enums.AlgorithmDimensionality.TwoDimensional,
			//	Family = Logic.Algorithms.Enums.AlgorithmFamily.Shelf,
			//	AlgorithmType = Logic.Algorithms.Enums.ObjectFittingStrategy.BestHeightFit,
			//	SplittingStrategy = Logic.Algorithms.Enums.ContainerSplittingStrategy.None
			//}, new ShelfContainer2D(40, 50));

			//algo.Execute(objectSet2d);

			//var results3 = algo.CreateResults();

			//algo = factory.Create(new AlgorithmProperties()
			//{
			//	Dimensionality = Logic.Algorithms.Enums.AlgorithmDimensionality.TwoDimensional,
			//	Family = Logic.Algorithms.Enums.AlgorithmFamily.Shelf,
			//	AlgorithmType = Logic.Algorithms.Enums.ObjectFittingStrategy.BestWidthFit,
			//	SplittingStrategy = Logic.Algorithms.Enums.ContainerSplittingStrategy.None
			//}, new ShelfContainer2D(40, 50));

			//algo.Execute(objectSet2d);

			//var results4 = algo.CreateResults();

			//algo = factory.Create(new AlgorithmProperties()
			//{
			//	Dimensionality = Logic.Algorithms.Enums.AlgorithmDimensionality.TwoDimensional,
			//	Family = Logic.Algorithms.Enums.AlgorithmFamily.Shelf,
			//	AlgorithmType = Logic.Algorithms.Enums.ObjectFittingStrategy.BestAreaFit,
			//	SplittingStrategy = Logic.Algorithms.Enums.ContainerSplittingStrategy.None
			//}, new ShelfContainer2D(40, 50));

			//algo.Execute(objectSet2d);

			//var results5 = algo.CreateResults();

			//algo = factory.Create(new AlgorithmProperties()
			//{
			//	Dimensionality = Logic.Algorithms.Enums.AlgorithmDimensionality.TwoDimensional,
			//	Family = Logic.Algorithms.Enums.AlgorithmFamily.Shelf,
			//	AlgorithmType = Logic.Algorithms.Enums.ObjectFittingStrategy.WorstWidthFit,
			//	SplittingStrategy = Logic.Algorithms.Enums.ContainerSplittingStrategy.None
			//}, new ShelfContainer2D(40, 50));

			//algo.Execute(objectSet2d);

			//var results6 = algo.CreateResults();

			//algo = factory.Create(new AlgorithmProperties()
			//{
			//	Dimensionality = Logic.Algorithms.Enums.AlgorithmDimensionality.TwoDimensional,
			//	Family = Logic.Algorithms.Enums.AlgorithmFamily.Shelf,
			//	AlgorithmType = Logic.Algorithms.Enums.ObjectFittingStrategy.WorstAreaFit,
			//	SplittingStrategy = Logic.Algorithms.Enums.ContainerSplittingStrategy.None
			//}, new ShelfContainer2D(40, 50));

			//algo.Execute(objectSet2d);

			//var results7 = algo.CreateResults();

			//algo = factory.Create(new AlgorithmProperties()
			//{
			//	Dimensionality = Logic.Algorithms.Enums.AlgorithmDimensionality.TwoDimensional,
			//	Family = Logic.Algorithms.Enums.AlgorithmFamily.Skyline,
			//	AlgorithmType = Logic.Algorithms.Enums.ObjectFittingStrategy.BottomLeft,
			//	SplittingStrategy = Logic.Algorithms.Enums.ContainerSplittingStrategy.None
			//}, new SkylineContainer2D(40, 50));

			//algo.Execute(objectSet2d);

			//var results8 = algo.CreateResults();

			//algo = factory.Create(new AlgorithmProperties()
			//{
			//	Dimensionality = Logic.Algorithms.Enums.AlgorithmDimensionality.TwoDimensional,
			//	Family = Logic.Algorithms.Enums.AlgorithmFamily.Skyline,
			//	AlgorithmType = Logic.Algorithms.Enums.ObjectFittingStrategy.BestFitBestContainer,
			//	SplittingStrategy = Logic.Algorithms.Enums.ContainerSplittingStrategy.None
			//}, new SkylineContainer2D(40, 50));

			//algo.Execute(objectSet2d);

			//var results9 = algo.CreateResults();

			//algo = factory.Create(new AlgorithmProperties()
			//{
			//	Dimensionality = Logic.Algorithms.Enums.AlgorithmDimensionality.TwoDimensional,
			//	Family = Logic.Algorithms.Enums.AlgorithmFamily.Skyline,
			//	AlgorithmType = Logic.Algorithms.Enums.ObjectFittingStrategy.BestFitFirstContainer,
			//	SplittingStrategy = Logic.Algorithms.Enums.ContainerSplittingStrategy.None
			//}, new SkylineContainer2D(40, 50));

			//algo.Execute(objectSet2d);

			//var results10 = algo.CreateResults();

			//algo = factory.Create(new AlgorithmProperties()
			//{
			//	Dimensionality = Logic.Algorithms.Enums.AlgorithmDimensionality.TwoDimensional,
			//	Family = Logic.Algorithms.Enums.AlgorithmFamily.GuillotineCut,
			//	AlgorithmType = Logic.Algorithms.Enums.ObjectFittingStrategy.BestAreaFit,
			//	SplittingStrategy = Logic.Algorithms.Enums.ContainerSplittingStrategy.MinAreaSplitRule
			//}, new GuillotineCutMinAreaContainer2D(40, 50));

			//algo.Execute(objectSet2d);

			//var results11 = algo.CreateResults();

			//objectSet2d = SortingHelper.Sort(objectSet2d, ObjectOrdering.ByArea);

			//algo = factory.Create(new AlgorithmProperties()
			//{
			//	Dimensionality = Logic.Algorithms.Enums.AlgorithmDimensionality.TwoDimensional,
			//	Family = Logic.Algorithms.Enums.AlgorithmFamily.GuillotineCut,
			//	AlgorithmType = Logic.Algorithms.Enums.ObjectFittingStrategy.BestAreaFit,
			//	SplittingStrategy = Logic.Algorithms.Enums.ContainerSplittingStrategy.MinAreaSplitRule
			//}, new GuillotineCutMinAreaContainer2D(40, 50));

			//algo.Execute(objectSet2d);

			//var results12 = algo.CreateResults();

			IAlgorithmFactory factory = new AlgorithmFactory();
			//IAlgorithm algo = factory.Create(new AlgorithmProperties()
			//{
			//	Dimensionality = Logic.Algorithms.Enums.AlgorithmDimensionality.ThreeDimensional,
			//	Family = Logic.Algorithms.Enums.AlgorithmFamily.GuillotineCut,
			//	AlgorithmType = Logic.Algorithms.Enums.ObjectFittingStrategy.BestVolumeFit,
			//	SplittingStrategy = Logic.Algorithms.Enums.ContainerSplittingStrategy.MaxVolumeSplitRule
			//}, new GuillotineCutMaxVolumeContainer3D(40, 50, 50));

			//algo.Execute(objectSet3d);

			//var result13 = algo.CreateResults();

			objectSet3d = SortingHelper.Sort(objectSet3d, ObjectOrdering.ByDepth);

			IAlgorithm algo = factory.Create(new AlgorithmProperties()
			{
				Dimensionality = Logic.Algorithms.Enums.AlgorithmDimensionality.ThreeDimensional,
				Family = Logic.Algorithms.Enums.AlgorithmFamily.Shelf,
				AlgorithmType = Logic.Algorithms.Enums.ObjectFittingStrategy.NextFit,
				SplittingStrategy = Logic.Algorithms.Enums.ContainerSplittingStrategy.None
			}, new ShelfContainer3D(100, 100, 100));

			algo.Execute(objectSet3d);

			var result14 = algo.CreateResults();

			algo = factory.Create(new AlgorithmProperties()
			{
				Dimensionality = Logic.Algorithms.Enums.AlgorithmDimensionality.ThreeDimensional,
				Family = Logic.Algorithms.Enums.AlgorithmFamily.Shelf,
				AlgorithmType = Logic.Algorithms.Enums.ObjectFittingStrategy.FirstFit,
				SplittingStrategy = Logic.Algorithms.Enums.ContainerSplittingStrategy.None
			}, new ShelfContainer3D(50, 50, 50));

			algo.Execute(objectSet3d);

			var result15 = algo.CreateResults();
		}
	}
}