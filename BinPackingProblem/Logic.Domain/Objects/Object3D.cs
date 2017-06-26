using Logic.Domain.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain.Objects
{
    [Serializable]
    public class Object3D: Object
    {
        public Object3D(int height, int width, int depth)
        {
            this.Size = new Cuboid(height, width, depth);
        }

        public Object3D(Cuboid size)
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

		public int Depth
        {
            get { return (Size as Cuboid).Depth; }
			set { (Size as Cuboid).Depth = value; }
		}

        public int Volume
        {
            get { return (Size as Cuboid).Volume; }
        }

        public int SurfaceArea
        {
            get { return (Size as Cuboid).SurfaceArea; }
        }

        public virtual void Resize(Cuboid newSize)
        {
            Size = newSize;
        }
    }
}
