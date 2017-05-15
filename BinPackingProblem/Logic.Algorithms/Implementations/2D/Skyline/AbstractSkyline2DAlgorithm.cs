using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain.Containers._2D;
using Logic.Domain.Objects;
using Logic.Domain.Containers._2D.Skyline;
using Logic.Domain;
using Logic.Domain.Figures;

namespace Logic.Algorithms.Implementations._2D.Skyline
{
	public abstract class AbstractSkyline2DAlgorithm : Algorithm2D
	{
		public AbstractSkyline2DAlgorithm(Container2D initialContainer) : base(initialContainer)
		{
			containers = new List<Container2D>();

			containers.Add(new SkylineContainer2D(initialContainer.Width, initialContainer.Height));
		}

		public override void AddContainer()
		{
			if (containers != null)
				containers.Add(new SkylineContainer2D(containers.First().Width, containers.First().Height));
		}

		protected Position2D CheckShiftedPositionAvailability(SkylineContainer2D container2D, Object2D objectToPlace, Line currentSkyline)
		{
			//Skylines on left side of currently checked skyline, starting from nearest
			var skylinesOnLeft = container2D.AvailableSkylines.Where(x => x.X < currentSkyline.X).OrderByDescending(x => x.X).ToList();

			Position2D mostLeftPosition = new Position2D(currentSkyline.X, currentSkyline.Y);

			// Look if object can be moved further to left, i.e. skyylines on left are below current skyline
			foreach (Line skyline in skylinesOnLeft)
			{
				if (skyline.Y < currentSkyline.Y)
				{
					mostLeftPosition.X = skyline.X;
				}
				else
					break;
			}

			// Part protruding on the right side of current skyline
			int protrudingPartLenght = mostLeftPosition.X + objectToPlace.Width - currentSkyline.X2;

			// If it exceed container width, then break
			if (protrudingPartLenght + currentSkyline.X2 > container2D.Width)
				return null;

			//Skylines on right side of currently checked skyline covered by protruding part, starting from nearest
			var skylinesOnRight = container2D.AvailableSkylines.Where(x => x.X > currentSkyline.X && x.X < currentSkyline.X2 + protrudingPartLenght).OrderBy(x => x.X).ToList();

			// Check if skylines on right are below object; If yes, it can be placed, otherwise object would overlap
			foreach (Line skyline in skylinesOnRight)
			{
				if (skyline.Y > currentSkyline.Y)
				{
					mostLeftPosition = null;
					break;
				}
			}

			return mostLeftPosition;
		}
	}
}
