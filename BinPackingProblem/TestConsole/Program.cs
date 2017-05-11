using Logic.Algorithms;
using Logic.Algorithms.Structs;
using Logic.Domain.Containers._2D;
using Logic.Domain.Containers._2D.Shelf;
using Logic.Domain.Objects;
using Logic.ObjectGenerator;
using Logic.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectGenerator generator = new ObjectGenerator();

            //testSet = generator.Generate2DObjectSet(new ObjectSetProperties2D()
            //{
            //    ObjectAmount = 100,
            //    AverageObjectWidthHeightRatio = 1,
            //    ObjectWidthHeightRatioStandardDeviation = 1,
            //    MaxObjectWidthHeightRatio = 10,
            //    MinObjectWidthHeightRatio = 0.1m,

            //    AverageObjectArea = 100,
            //    ObjectAreaStandardDeviation = 20,
            //    MaxObjectArea = 200,
            //    MinObjectArea = 10
            //});

            //foreach(var element in testSet)
            //{
            //    Console.WriteLine("Object w = {0}, h = {1}", (element as Object2D).Width, (element as Object2D).Height);
            //}

            //generator.SaveObjectSet(testSet, "E:\\test2d.set");
			

            //testSet = generator.Generate3DObjectSet(new ObjectSetProperties3D()
            //{
            //    ObjectAmount = 100,
            //    AverageObjectWidthHeightRatio = 1,
            //    ObjectWidthHeightRatioStandardDeviation = 1,
            //    MaxObjectWidthHeightRatio = 10,
            //    MinObjectWidthHeightRatio = 0.2m,

            //    AverageObjectDepthHeightRatio = 1,
            //    ObjectDepthHeightRatioStandardDeviation = 1,
            //    MaxObjectDepthHeightRatio = 10,
            //    MinObjectDepthHeightRatio = 0.2m,

            //    AverageObjectVolume = 1000,
            //    VolumeStandardDeviation = 200,
            //    MaxVolume = 2000,
            //    MinVolume = 100
            //});

            //foreach (var element in testSet)
            //{
            //    Console.WriteLine("Object w = {0}, h = {1}, d = {2}", (element as Object3D).Width, (element as Object3D).Height, (element as Object3D).Depth);
            //}

            //generator.SaveObjectSet(testSet, "E:\\test3d.set");
			


            ObjectSet objectSet2d = generator.LoadObjectSet("E:\\test2d.set");

            //var objectSet3d = generator.LoadObjectSet("E:\\test3d.set");


			IAlgorithmFactory factory = new AlgorithmFactory();
			IAlgorithm algo = factory.Create(new AlgorithmProperties()
			{
				Dimensionality = Logic.Algorithms.Enums.AlgorithmDimensionality.TwoDimensional,
				Family = Logic.Algorithms.Enums.AlgorithmFamily.Shelf,
				AlgorithmType = Logic.Algorithms.Enums.ObjectFittingStrategy.NextFit,
				SplittingStrategy = Logic.Algorithms.Enums.ContainerSplittingStrategy.None
			}, new ShelfContainer2D(40, 100));

			algo.Execute(objectSet2d);

			var results = algo.CreateResults();

			ObjectSet sortedObjectSet = objectSet2d.OrderBy(x => (x as Object2D).Height).ToObjectList();
			
			algo = factory.Create(new AlgorithmProperties()
			{
				Dimensionality = Logic.Algorithms.Enums.AlgorithmDimensionality.TwoDimensional,
				Family = Logic.Algorithms.Enums.AlgorithmFamily.Shelf,
				AlgorithmType = Logic.Algorithms.Enums.ObjectFittingStrategy.NextFit,
				SplittingStrategy = Logic.Algorithms.Enums.ContainerSplittingStrategy.None
			}, new ShelfContainer2D(40, 100));

			algo.Execute(sortedObjectSet);

			results = algo.CreateResults();

            Console.ReadKey();
        }
    }
}
