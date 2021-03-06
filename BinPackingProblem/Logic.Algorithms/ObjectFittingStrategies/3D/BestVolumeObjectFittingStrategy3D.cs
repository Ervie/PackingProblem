﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain.Containers._3D;
using Logic.Domain.Objects;

namespace Logic.Algorithms.ObjectFittingStrategies._3D
{
	public class BestVolumeObjectFittingStrategy3D : AbstractFittingStrategy3D
	{
		public override double CalculateFittingQuality(Object3D objectToPlace, SubContainer3D subcontainer)
		{
			return subcontainer.Volume / (double)objectToPlace.Volume;
		}
	}
}
