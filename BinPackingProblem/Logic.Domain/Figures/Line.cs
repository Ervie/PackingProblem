using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain.Figures
{
	[Serializable]
	public class Line: IFigure
	{
		public int Length { get; private set; }

		public int X { get; private set; }

		public int X2
		{
			get { return X + Length; }
		}

		public Line(int xPosition, int length)
		{
			X = xPosition;
			Length = length;
		}

		public void Resize(int length)
		{
			Length = length;
		}

		public void Move(int xPosition)
		{
			X = xPosition;
		}
	}
}
