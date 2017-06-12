using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Algorithms.Exceptions
{
	[Serializable]
	internal class CannotSortObjectsException: Exception
	{
		public CannotSortObjectsException()
		{
		}

		public CannotSortObjectsException(string message) : base(message)
		{
		}

		public CannotSortObjectsException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected CannotSortObjectsException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
