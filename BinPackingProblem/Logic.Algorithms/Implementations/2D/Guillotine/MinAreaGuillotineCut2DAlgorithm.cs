﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain.Containers._2D;
using Logic.Domain.Objects;
using Logic.Domain.Containers._2D.Guillotine;
using Logic.Domain;
using Logic.Algorithms.Enums;
using Logic.Algorithms.ObjectFittingStrategies._2D;

namespace Logic.Algorithms.Implementations._2D.Guillotine
{
	public class MinAreaGuillotineCut2DAlgorithm : AbstractGuillotineCut2DAlgorithm
	{
		public MinAreaGuillotineCut2DAlgorithm(Container2D initialContainer, AbstractFittingStrategy2D strategy) : base(initialContainer, strategy)
		{
			containers = new List<Container2D>();

			containers.Add(new GuillotineCutMinAreaContainer2D(initialContainer.Width, initialContainer.Height));
		}

		public override void AddContainer()
		{
			if (containers != null)
				containers.Add(new GuillotineCutMinAreaContainer2D(containers.First().Width, containers.First().Height));
		}
	}
}
