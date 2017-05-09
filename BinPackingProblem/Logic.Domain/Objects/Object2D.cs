using Logic.Domain.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain.Objects
{
    [Serializable]
    public class Object2D : Object
    {
        public Object2D(int height, int width)
        {
            this.Size = new Rectangle(height, width);
        }

        public Object2D(Rectangle size)
        {
            this.Size = size;
        }

        public int Height
        {
            get { return (Size as Rectangle).Height; }
			set { (Size as Rectangle).Height = value; }
        }
        public int Width
        {
            get { return (Size as Rectangle).Width; }
			set { (Size as Rectangle).Width = value; }
		}

        public int Area
        {
            get { return (Size as Rectangle).Area; }
        }

        public int Perimeter
        {
            get { return (Size as Rectangle).Perimeter; }
        }

        public virtual void Resize(Rectangle newSize)
        {
            Size = newSize;
        }
    }
}
