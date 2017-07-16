using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain.Objects
{
    [Serializable]
    public class ObjectSet: List<Object>
    {
		public int GetHeighestHeight()
		{
			if (this.First() is Object2D)
			{
				return this.Max(x => (x as Object2D).Height);
			}
			else if (this.First() is Object3D)
			{
				return this.Max(x => (x as Object3D).Height);
			}
			else
				return -1;
		}

		public int GetWidestWidth()
		{
			if (this.First() is Object2D)
			{
				return this.Max(x => (x as Object2D).Width);
			}
			else if (this.First() is Object3D)
			{
				return this.Max(x => (x as Object3D).Width);
			}
			else
				return -1;
		}

		public int GetDeepestDepth()
		{
			if (this.First() is Object3D)
			{
				return this.Max(x => (x as Object3D).Width);
			}
			else
				return -1;
		}
	}
}
