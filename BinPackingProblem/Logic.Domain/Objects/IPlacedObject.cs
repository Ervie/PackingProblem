﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain.Objects
{
	public interface IPlacedObject
	{
		IPosition GetPostion();
	}
}
