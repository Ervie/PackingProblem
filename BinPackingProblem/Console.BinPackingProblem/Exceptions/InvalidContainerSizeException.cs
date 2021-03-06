﻿using System;
using System.Runtime.Serialization;

namespace Console.BinPackingProblem.Exceptions
{
	[Serializable]
	internal class InvalidContainerSizeException : Exception
	{
		public InvalidContainerSizeException()
		{
		}

		public InvalidContainerSizeException(string message) : base(message)
		{
		}

		public InvalidContainerSizeException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected InvalidContainerSizeException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}