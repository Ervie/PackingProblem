using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain.Figures;
using Logic.Domain.Objects;

namespace Logic.Domain.Containers._2D.Skyline
{
	public class SkylineContainer2D : Container2D
	{
		public PlacedObject2D LastPlacedObject { get; private set; }


		public IList<Line> AvailableSkylines { get; private set; }


		public bool IsOpen
		{
			get { return AvailableSkylines.Any(); }
		}
		public SkylineContainer2D(int width, int height) : base(width, height)
		{
			var availableSkyline = new Line(0, width, 0);
			AvailableSkylines = new List<Line> { availableSkyline };
		}

		protected override SubContainer2D CreateSubcontainer(Position2D position, Rectangle size)
		{
			throw new NotImplementedException();
		}

		public void PlaceNewObject(Object2D theObject, Position2D position)
		{

			LastPlacedObject = (PlaceObject(theObject, position)) as PlacedObject2D;

			MakeSkylineUnavailable(LastPlacedObject);

			CreateSkylineAtopObject(LastPlacedObject);
		}

		public void MakeSkylineUnavailable(PlacedObject2D theObject)
		{
			foreach (var availableSkyline in AvailableSkylines.ToList())
			{
				if (availableSkyline.Y <= theObject.Y)
				{
					// Object partially cover skyline below - resize it (left)
					if (availableSkyline.X < theObject.X &&
						availableSkyline.X2 <= theObject.X2 &&
						availableSkyline.X2 > theObject.X)
					{
						availableSkyline.Resize(theObject.X2 - availableSkyline.X2);
						continue;
					}
					// Object completely cover skyline below - remove it
					if (availableSkyline.X >= theObject.X &&
						availableSkyline.X2 <= theObject.X2)
					{
						AvailableSkylines.Remove(availableSkyline);
						continue;
					}
					// Object partially cover skyline below - resize it (right), and move beginning to right
					if (availableSkyline.X >= theObject.X &&
						availableSkyline.X < theObject.X2 &&
						availableSkyline.X2 > theObject.X2)
					{
						availableSkyline.Resize(availableSkyline.X2 - theObject.X2);
						availableSkyline.Move(theObject.X2);
						continue;
					}
					// Object partially cover skyline below from both size -> resize left, resize and move right
					if (availableSkyline.X < theObject.X &&
						availableSkyline.X2 > theObject.X2)
					{
						var leftSkyline = new Line(availableSkyline.X, theObject.X - availableSkyline.X, availableSkyline.Y);
						AvailableSkylines.Add(leftSkyline);

						var rightSkyline = availableSkyline;
						rightSkyline.Resize(rightSkyline.X2 - theObject.X2);
						rightSkyline.Move(theObject.X2);
					}
				}
			}
		}

		private void CreateSkylineAtopObject(PlacedObject2D lastPlacedObject)
		{
			var newSkyline = new Line(lastPlacedObject.X, lastPlacedObject.Width, lastPlacedObject.Y2);

			AvailableSkylines.Add(newSkyline);
		}
	}
}
