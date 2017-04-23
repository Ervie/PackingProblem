using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ObjectGenerator
{
    /// <summary>
    /// For generating 2D Objects
    /// </summary>
    public class ObjectSetProperties2D
    {
        public int ObjectAmount { get; set; }
        public decimal AverageObjectWidthHeightRatio { get; set; }
        public decimal ObjectWidthHeightRatioStandardDeviation { get; set; }
        public decimal MinObjectWidthHeightRatio { get; set; }
        public decimal MaxObjectWidthHeightRatio { get; set; }
        public decimal AverageObjectArea { get; set; }
        public decimal ObjectAreaStandardDeviation { get; set; }
        public decimal MinObjectArea { get; set; }
        public decimal MaxObjectArea { get; set; }
    }

    /// <summary>
    /// For generating 3D Objects
    /// </summary>
    public class ObjectSetProperties3D
    {
        public int ObjectAmount { get; set; }
        public decimal AverageObjectVolume { get; set; }
        public decimal VolumeStandardDeviation { get; set; }
        public decimal MinVolume { get; set; }
        public decimal MaxVolume { get; set; }

        public decimal AverageObjectWidthHeightRatio { get; set; }
        public decimal ObjectWidthHeightRatioStandardDeviation { get; set; }
        public decimal MinObjectWidthHeightRatio { get; set; }
        public decimal MaxObjectWidthHeightRatio { get; set; }

        public decimal AverageObjectDepthHeightRatio { get; set; }
        public decimal ObjectDepthHeightRatioStandardDeviation { get; set; }
        public decimal MinObjectDepthHeightRatio { get; set; }
        public decimal MaxObjectDepthHeightRatio { get; set; }
    }
}
