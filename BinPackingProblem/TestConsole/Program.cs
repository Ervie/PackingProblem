using Logic.Domain.Objects;
using Logic.ObjectGenerator;
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
            ObjectSet testSet;

            ObjectGenerator generator = new ObjectGenerator();

            testSet = generator.Generate2DObjectSet(new ObjectSetProperties2D()
            {
                ObjectAmount = 100,
                AverageObjectWidthHeightRatio = 1,
                ObjectWidthHeightRatioStandardDeviation = 1,
                MaxObjectWidthHeightRatio = 10,
                MinObjectWidthHeightRatio = 0.1m,

                AverageObjectArea = 100,
                ObjectAreaStandardDeviation = 20,
                MaxObjectArea = 200,
                MinObjectArea = 10
            });

            foreach(var element in testSet)
            {
                Console.WriteLine("Object w = {0}, h = {1}", (element as Object2D).Width, (element as Object2D).Height);
            }

            generator.SaveObjectSet(testSet, "E:\\test2d.set");

            Console.ReadKey();

            testSet = generator.Generate3DObjectSet(new ObjectSetProperties3D()
            {
                ObjectAmount = 100,
                AverageObjectWidthHeightRatio = 1,
                ObjectWidthHeightRatioStandardDeviation = 1,
                MaxObjectWidthHeightRatio = 10,
                MinObjectWidthHeightRatio = 0.2m,

                AverageObjectDepthHeightRatio = 1,
                ObjectDepthHeightRatioStandardDeviation = 1,
                MaxObjectDepthHeightRatio = 10,
                MinObjectDepthHeightRatio = 0.2m,

                AverageObjectVolume = 1000,
                VolumeStandardDeviation = 200,
                MaxVolume = 2000,
                MinVolume = 100
            });

            foreach (var element in testSet)
            {
                Console.WriteLine("Object w = {0}, h = {1}, d = {2}", (element as Object3D).Width, (element as Object3D).Height, (element as Object3D).Depth);
            }

            generator.SaveObjectSet(testSet, "E:\\test3d.set");

            Console.ReadKey();


            var objectSet2d = generator.LoadObjectSet("E:\\test2d.set");

            var objectSet3d = generator.LoadObjectSet("E:\\test3d.set");

            Console.ReadKey();
        }
    }
}
