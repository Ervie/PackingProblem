using GUI.Helpers;
using GUI.ObjectSetGenerator.Properties;
using Logic.ObjectGenerator;
using Logic.Utilities.Files;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI.ObjectSetGenerator.ViewModel
{
    class MainViewModel: BaseNotifyPropertyChanged
    {
		#region Fields

		public ObjectSetProperties2D objectSetProperties2D;

		public ObjectSetProperties3D objectSetProperties3D;

		private ObjectGenerator generator;

		private string savePath2D;

		private string savePath3D;


		/// <summary>
		/// Command for Generating 2D Object Set.
		/// </summary>
		ICommand _Generate2dObjectSet;

		/// <summary>
		/// Command for Generating 3D Object Set.
		/// </summary>
		ICommand _Generate3dObjectSet;

		/// <summary>
		/// Command for changing object save path for 2D object sets.
		/// </summary>
		ICommand _ChangePath2D;

		/// <summary>
		/// Command for changing object save path for 3D object sets.
		/// </summary>
		ICommand _ChangePath3D;

		#endregion

		#region Constructors

		/// <summary>
		/// Constructor with dummy values.
		/// </summary>
		public MainViewModel()
		{
			savePath2D = Settings.Default.DefaultSavePath;
			savePath3D = Settings.Default.DefaultSavePath;
			generator = new ObjectGenerator();
			objectSetProperties2D = new ObjectSetProperties2D()
			{
				ObjectAmount = 100,
				AverageObjectWidthHeightRatio = 1,
				ObjectWidthHeightRatioStandardDeviation = 1,
				MaxObjectWidthHeightRatio = 10,
				MinObjectWidthHeightRatio = 0.1m,

				AverageObjectArea = 100,
				ObjectAreaStandardDeviation = 20,
				MaxObjectArea = 200,
				MinObjectArea = 10
			};

			objectSetProperties3D = new ObjectSetProperties3D()
			{
				ObjectAmount = 100,
				AverageObjectWidthHeightRatio = 1,
				ObjectWidthHeightRatioStandardDeviation = 1,
				MaxObjectWidthHeightRatio = 10,
				MinObjectWidthHeightRatio = 0.2m,

				AverageObjectDepthHeightRatio = 1,
				ObjectDepthHeightRatioStandardDeviation = 1,
				MaxObjectDepthHeightRatio = 10,
				MinObjectDepthHeightRatio = 0.2m,

				AverageObjectVolume = 1000,
				VolumeStandardDeviation = 200,
				MaxVolume = 2000,
				MinVolume = 100
			};
		}

		#endregion

		#region Properties

		public string SavePath2D
		{
			get
			{
				return savePath2D;
			}
			set
			{
				savePath2D = value;
				RaisePropertyChanged("SavePath2D");
			}
		}

		public string SavePath3D
		{
			get
			{
				return savePath3D;
			}
			set
			{
				savePath3D = value;
				RaisePropertyChanged("SavePath3D");
			}
		}

		#region 2 Dimensions

		public int ObjectAmount2d
		{
			get
			{
				return objectSetProperties2D.ObjectAmount;
			}
			set
			{
				objectSetProperties2D.ObjectAmount = value;
				RaisePropertyChanged("ObjectAmount2d");
			}
		}

		public decimal AverageObjectArea2d
		{
			get
			{
				return objectSetProperties2D.AverageObjectArea;
			}
			set
			{
				objectSetProperties2D.AverageObjectArea = value;
				RaisePropertyChanged("AverageObjectArea2d");
			}
		}

		public decimal StandardDeviationObjectArea2d
		{
			get
			{
				return objectSetProperties2D.ObjectAreaStandardDeviation;
			}
			set
			{
				objectSetProperties2D.ObjectAreaStandardDeviation = value;
				RaisePropertyChanged("StandardDeviationObjectArea2d");
			}
		}

		public decimal MinArea2d
		{
			get
			{
				return objectSetProperties2D.MinObjectArea;
			}
			set
			{
				objectSetProperties2D.MinObjectArea = value;
				RaisePropertyChanged("MinArea2d");
			}
		}

		public decimal MaxArea2d
		{
			get
			{
				return objectSetProperties2D.MaxObjectArea;
			}
			set
			{
				objectSetProperties2D.MaxObjectArea = value;
				RaisePropertyChanged("MaxArea2d");
			}
		}

		public decimal AverageWidthHeightRatio2d
		{
			get
			{
				return objectSetProperties2D.AverageObjectWidthHeightRatio;
			}
			set
			{
				objectSetProperties2D.AverageObjectWidthHeightRatio = value;
				RaisePropertyChanged("AverageWidthHeightRatio2d");
			}
		}

		public decimal StandardDeviationWidthHeightRatio2d
		{
			get
			{
				return objectSetProperties2D.ObjectWidthHeightRatioStandardDeviation;
			}
			set
			{
				objectSetProperties2D.ObjectWidthHeightRatioStandardDeviation = value;
				RaisePropertyChanged("StandardDeviationWidthHeightRatio2d");
			}
		}

		public decimal MinWidthHeightRatio2d
		{
			get
			{
				return objectSetProperties2D.MinObjectWidthHeightRatio;
			}
			set
			{
				objectSetProperties2D.MinObjectWidthHeightRatio = value;
				RaisePropertyChanged("MinWidthHeightRatio2d");
			}
		}

		public decimal MaxWidthHeightRatio2d
		{
			get
			{
				return objectSetProperties2D.MaxObjectWidthHeightRatio;
			}
			set
			{
				objectSetProperties2D.MaxObjectWidthHeightRatio = value;
				RaisePropertyChanged("MaxWidthHeightRatio2d");
			}
		}

		#endregion

		#region 3 Dimensions

		public int ObjectAmount3d
		{
			get
			{
				return objectSetProperties3D.ObjectAmount;
			}
			set
			{
				objectSetProperties3D.ObjectAmount = value;
				RaisePropertyChanged("ObjectAmount3d");
			}
		}

		public decimal AverageObjectVolume3d
		{
			get
			{
				return objectSetProperties3D.AverageObjectVolume;
			}
			set
			{
				objectSetProperties3D.AverageObjectVolume = value;
				RaisePropertyChanged("AverageObjectVolume3d");
			}
		}

		public decimal StandardDeviationObjectVolume3d
		{
			get
			{
				return objectSetProperties3D.VolumeStandardDeviation;
			}
			set
			{
				objectSetProperties3D.VolumeStandardDeviation = value;
				RaisePropertyChanged("StandardDeviationObjectVolume3d");
			}
		}

		public decimal MinVolume3d
		{
			get
			{
				return objectSetProperties3D.MinVolume;
			}
			set
			{
				objectSetProperties3D.MinVolume = value;
				RaisePropertyChanged("MinVolume3d");
			}
		}

		public decimal MaxVolume3d
		{
			get
			{
				return objectSetProperties3D.MaxVolume;
			}
			set
			{
				objectSetProperties3D.MaxVolume = value;
				RaisePropertyChanged("MaxVolume3d");
			}
		}

		public decimal AverageWidthHeightRatio3d
		{
			get
			{
				return objectSetProperties3D.AverageObjectWidthHeightRatio;
			}
			set
			{
				objectSetProperties3D.AverageObjectWidthHeightRatio = value;
				RaisePropertyChanged("AverageWidthHeightRatio3d");
			}
		}

		public decimal StandardDeviationWidthHeightRatio3d
		{
			get
			{
				return objectSetProperties3D.ObjectWidthHeightRatioStandardDeviation;
			}
			set
			{
				objectSetProperties3D.ObjectWidthHeightRatioStandardDeviation = value;
				RaisePropertyChanged("StandardDeviationWidthHeightRatio3d");
			}
		}

		public decimal MinWidthHeightRatio3d
		{
			get
			{
				return objectSetProperties3D.MinObjectWidthHeightRatio;
			}
			set
			{
				objectSetProperties3D.MinObjectWidthHeightRatio = value;
				RaisePropertyChanged("MinWidthHeightRatio3d");
			}
		}

		public decimal MaxWidthHeightRatio3d
		{
			get
			{
				return objectSetProperties3D.MaxObjectWidthHeightRatio;
			}
			set
			{
				objectSetProperties3D.MaxObjectWidthHeightRatio = value;
				RaisePropertyChanged("MaxWidthHeightRatio3d");
			}
		}

		public decimal AverageDepthHeightRatio3d
		{
			get
			{
				return objectSetProperties3D.AverageObjectDepthHeightRatio;
			}
			set
			{
				objectSetProperties3D.AverageObjectDepthHeightRatio = value;
				RaisePropertyChanged("AverageDepthHeightRatio3d");
			}
		}

		public decimal StandardDeviationDepthHeightRatio3d
		{
			get
			{
				return objectSetProperties3D.ObjectDepthHeightRatioStandardDeviation;
			}
			set
			{
				objectSetProperties3D.ObjectDepthHeightRatioStandardDeviation = value;
				RaisePropertyChanged("StandardDeviationDepthHeightRatio3d");
			}
		}

		public decimal MinDepthHeightRatio3d
		{
			get
			{
				return objectSetProperties3D.MinObjectDepthHeightRatio;
			}
			set
			{
				objectSetProperties3D.MinObjectDepthHeightRatio = value;
				RaisePropertyChanged("MinDepthHeightRatio3d");
			}
		}

		public decimal MaxDepthHeightRatio3d
		{
			get
			{
				return objectSetProperties3D.MaxObjectDepthHeightRatio;
			}
			set
			{
				objectSetProperties3D.MaxObjectDepthHeightRatio = value;
				RaisePropertyChanged("MaxDepthHeightRatio3d");
			}
		}

		#endregion

		#endregion

		#region Commands

		public ICommand Generate2dObjectSet
		{
			get
			{
				if (_Generate2dObjectSet == null)
				{
					_Generate2dObjectSet = new Helpers.RelayCommand(
						param => Generate2dObjectSet_Execute(),
						param => Generate2dObjectSet_CanExecute()
					);
				}
				return _Generate2dObjectSet;
			}
		}

		public ICommand Generate3dObjectSet
		{
			get
			{
				if (_Generate3dObjectSet == null)
				{
					_Generate3dObjectSet = new Helpers.RelayCommand(
						param => Generate3dObjectSet_Execute(),
						param => Generate3dObjectSet_CanExecute()
					);
				}
				return _Generate3dObjectSet;
			}
		}

		public ICommand ChangePath2D
		{
			get
			{
				if (_ChangePath2D == null)
				{
					_ChangePath2D = new Helpers.RelayCommand(
						param => ChangePath2D_Execute(),
						param => true
					);
				}
				return _ChangePath2D;
			}
		}

		public ICommand ChangePath3D
		{
			get
			{
				if (_ChangePath3D == null)
				{
					_ChangePath3D = new Helpers.RelayCommand(
						param => ChangePath3D_Execute(),
						param => true
					);
				}
				return _ChangePath3D;
			}
		}

		#endregion

		#region Methods

		private void Generate2dObjectSet_Execute()
		{
			try
			{
				var objectSet = generator.Generate2DObjectSet(objectSetProperties2D);
				generator.SaveObjectSet(objectSet, SavePath2D);

				System.Windows.MessageBox.Show(string.Format("Object set {0} was successfully created at {1}", Path.GetFileNameWithoutExtension(SavePath2D), Path.GetDirectoryName(SavePath2D)), "Success");
			}
			catch (Exception err)
			{
				System.Windows.MessageBox.Show("Error during changing save path:" + err.Message, "Error");
			}
		}

		private bool Generate2dObjectSet_CanExecute()
		{
			return (FileHelper.HasAccessPermission(SavePath2D) &&
						FileHelper.DirectoryExist(SavePath2D) &&
						ObjectAmount2d > 0 &&
						MaxArea2d >= MinArea2d &&
						MaxWidthHeightRatio2d >= MinWidthHeightRatio2d);
		}

		private void Generate3dObjectSet_Execute()
		{
			try
			{
				var objectSet = generator.Generate3DObjectSet(objectSetProperties3D);
				generator.SaveObjectSet(objectSet, SavePath3D);

				System.Windows.MessageBox.Show(string.Format("Object set {0} was successfully created at {1}", Path.GetFileNameWithoutExtension(SavePath3D), Path.GetDirectoryName(SavePath3D)), "Success");
			}
			catch (Exception err)
			{
				System.Windows.MessageBox.Show("Error during changing save path:" + err.Message, "Error");
			}
		}

		private bool Generate3dObjectSet_CanExecute()
		{
			return (FileHelper.HasAccessPermission(SavePath3D) &&
						FileHelper.DirectoryExist(SavePath3D) &&
						ObjectAmount3d > 0 &&
						MaxVolume3d >= MinVolume3d &&
						MaxWidthHeightRatio3d >= MinWidthHeightRatio3d &&
						MaxDepthHeightRatio3d >= MinDepthHeightRatio3d);
		}

		private void ChangePath2D_Execute()
		{
			try
			{
				var saveFileDialog = new SaveFileDialog();

				saveFileDialog.Filter = "2D Object set file (*.2Dset)|*.2Dset";

				if (saveFileDialog.ShowDialog() == true)
				{
					if (FileHelper.HasAccessPermission(saveFileDialog.FileName) && FileHelper.DirectoryExist(saveFileDialog.FileName))
						SavePath2D = saveFileDialog.FileName;
					else
						System.Windows.MessageBox.Show(string.Format("Error during changing save path: Access is denied."), "Error");
				}
			}
			catch(Exception err)
			{
				System.Windows.MessageBox.Show("Error during changing save path:" + err.Message, "Error");
			}
		}

		private void ChangePath3D_Execute()
		{
			try
			{
				var saveFileDialog = new SaveFileDialog();

				saveFileDialog.Filter = "3D Object set file (*.3Dset)|*.3Dset";

				if (saveFileDialog.ShowDialog() == true)
				{
					if (FileHelper.HasAccessPermission(saveFileDialog.FileName) && FileHelper.DirectoryExist(saveFileDialog.FileName))
						SavePath3D = saveFileDialog.FileName;
					else
						System.Windows.MessageBox.Show(string.Format("Error during changing save path: Access is denied."), "Error");
				}
			}
			catch (Exception err)
			{
				System.Windows.MessageBox.Show("Error during changing save path:" + err.Message, "Error");
			}
		}
		#endregion
	}
}
