using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain.Figures
{
    /// <summary>
    /// 3 Dimensions figure.
    /// </summary>
    public class Cuboid: IFigure
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public int Depth { get; set; }

        public Cuboid(int width, int height, int depth)
        {
            Width = width;
            Height = height;
            Depth = depth;
        }

        public int Volume
        {
            get { return Width * Height * Depth; }
        }

        public int SurfaceArea
        {
            get { return 2 * Width * Height + 2 * Width * Depth + 2 * Height * Depth; }
        }
    }
}
