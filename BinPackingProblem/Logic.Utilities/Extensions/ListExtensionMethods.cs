using Logic.Domain.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Utilities.Extensions
{
	public static class ListExtensionMethods
	{
		public static ObjectSet ToObjectList(this IList<Object2D> objectList)
		{
			var objects = new ObjectSet();
			objects.AddRange(objectList);

			return objects;
		}

		public static ObjectSet ToObjectList(this IList<Object3D> objectList)
		{
			var objects = new ObjectSet();
			objects.AddRange(objectList);

			return objects;
		}

		public static ObjectSet ToObjectList(this IList<Domain.Objects.Object> objectList)
		{
			var objects = new ObjectSet();
			objects.AddRange(objectList);

			return objects;
		}

		public static ObjectSet ToObjectList(this IOrderedEnumerable<Object2D> objectList)
		{
			var objects = new ObjectSet();
			objects.AddRange(objectList);

			return objects;
		}

		public static ObjectSet ToObjectList(this IOrderedEnumerable<Object3D> objectList)
		{
			var objects = new ObjectSet();
			objects.AddRange(objectList);

			return objects;
		}

		public static ObjectSet ToObjectList(this IOrderedEnumerable<Domain.Objects.Object> objectList)
		{
			var objects = new ObjectSet();
			objects.AddRange(objectList);

			return objects;
		}
	}
}
