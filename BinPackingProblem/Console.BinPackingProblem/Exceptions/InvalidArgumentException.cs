using System;
using System.Runtime.Serialization;

namespace Console.BinPackingProblem.Exceptions
{
	internal class InvalidArgumentException : Exception
	{
		public InvalidArgumentException()
		{
		}

		public InvalidArgumentException(string message) : base(message)
		{
		}

		public InvalidArgumentException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected InvalidArgumentException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}