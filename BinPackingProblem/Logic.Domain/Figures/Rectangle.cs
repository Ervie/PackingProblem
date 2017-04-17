using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain.Figures
{
    /// <summary>
    /// 2 Dimensions figure.
    /// </summary>
    public class Rectangle: IFigure
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Area
        {
            get { return Width * Height; }
        }

        public int Perimeter
        {
            get { return 2 * Width + 2 * Height; }
        }
    }
}
