using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ObjectGenerator
{
    /// <summary>
    /// Extension for returning next random value based on Gaussian distribution.
    /// Source: https://bitbucket.org/Superbest/superbest-random/
    /// </summary>
    public static class RandomExtensionMethods
    {
        /// <summary>
        /// Adjusting to min/max value.
        /// </summary>
        /// <returns></returns>
        public static double NextGaussian(this Random random, double average, double standardDeviation, double minValue, double maxValue)
        {
            var randomValue = random.NextGaussian(average, standardDeviation);

            randomValue = Math.Min(randomValue, maxValue);
            randomValue = Math.Max(randomValue, minValue);

            return randomValue;
        }


        private static double NextGaussian(this Random random, double average, double standardDeviation)
        {


            var d1 = random.NextDouble();
            var d2 = random.NextDouble();

            var subresult = Math.Sqrt(-2.0 * Math.Log(d1)) * Math.Sin(2.0 * Math.PI * d2);

            return average + standardDeviation * subresult;
        }
    }
}
