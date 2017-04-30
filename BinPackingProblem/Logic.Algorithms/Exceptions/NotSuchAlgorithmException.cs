using System;
using System.Runtime.Serialization;

namespace Logic.Algorithms.Exceptions
{
	[Serializable]
	internal class NotSuchAlgorithmException : Exception
	{
		public NotSuchAlgorithmException()
		{
		}

		public NotSuchAlgorithmException(string message) : base(message)
		{
		}

		public NotSuchAlgorithmException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected NotSuchAlgorithmException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}