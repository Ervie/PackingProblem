using Logic.Domain.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ObjectGenerator
{
    public class ObjectGenerator
    {
        private Random rng;

        public ObjectGenerator()
        {
            rng = new Random();
        }

        public ObjectSet Generate2DObjectSet(ObjectSetProperties2D objectSetProperties)
        {
            var objectSet = new ObjectSet();

            for (int i = 0; i < objectSetProperties.ObjectAmount; ++i)
            {
                objectSet.Add(Generate2DObject(objectSetProperties));
            }

            return objectSet;
        }

        public ObjectSet Generate3DObjectSet(ObjectSetProperties3D objectSetProperties)
        {
            var objectSet = new ObjectSet();

            for (int i = 0; i < objectSetProperties.ObjectAmount; ++i)
            {
                objectSet.Add(Generate3DObject(objectSetProperties));
            }

            return objectSet;
        }

        private Object2D Generate2DObject(ObjectSetProperties2D objectSetProperties)
        {
            var objectWidthHeightRatio = rng.NextGaussian(
                    (double)objectSetProperties.AverageObjectWidthHeightRatio,
                    (double)objectSetProperties.ObjectWidthHeightRatioStandardDeviation,
                    (double)objectSetProperties.MinObjectWidthHeightRatio,
                    (double)objectSetProperties.MaxObjectWidthHeightRatio);
            var objectArea = rng.NextGaussian(
                    (double)objectSetProperties.AverageObjectArea,
                    (double)objectSetProperties.ObjectAreaStandardDeviation,
                    (double)objectSetProperties.MinObjectArea,
                    (double)objectSetProperties.MaxObjectArea);

            var objectHeight = Math.Sqrt(objectArea / objectWidthHeightRatio);
            var objectWidth = objectArea / objectHeight;

            var rectangleObject = new Object2D(Math.Max((int)objectWidth, 1), Math.Max((int)objectHeight, 1));

            return rectangleObject;
        }

        private Object3D Generate3DObject(ObjectSetProperties3D objectSetProperties)
        {
            var objectWidthHeightRatio = rng.NextGaussian(
                    (double)objectSetProperties.AverageObjectWidthHeightRatio,
                    (double)objectSetProperties.ObjectWidthHeightRatioStandardDeviation,
                    (double)objectSetProperties.MinObjectWidthHeightRatio,
                    (double)objectSetProperties.MaxObjectWidthHeightRatio);

            var objectDepthHeightRatio = rng.NextGaussian(
                    (double)objectSetProperties.AverageObjectDepthHeightRatio,
                    (double)objectSetProperties.ObjectDepthHeightRatioStandardDeviation,
                    (double)objectSetProperties.MinObjectDepthHeightRatio,
                    (double)objectSetProperties.MaxObjectDepthHeightRatio);

            var objectVolume = rng.NextGaussian(
                    (double)objectSetProperties.AverageObjectVolume,
                    (double)objectSetProperties.VolumeStandardDeviation,
                    (double)objectSetProperties.MinVolume,
                    (double)objectSetProperties.MaxVolume);

            //3rd root
            var objectHeight = Math.Pow((objectVolume / (objectWidthHeightRatio * objectDepthHeightRatio)), 1.0 / 3.0);
            var objectWidth = objectHeight * objectWidthHeightRatio;
            var objectDepth = objectHeight * objectDepthHeightRatio;

            var cuboidObject = new Object3D(Math.Max((int)objectWidth, 1), Math.Max((int)objectHeight, 1), Math.Max((int)objectDepth, 1));

            return cuboidObject;
        }
    }
}
