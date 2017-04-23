using GUI.Helpers;
using Logic.ObjectGenerator;
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

		private string savePath;


		/// <summary>
		/// Command for Generating 2D Object Set.
		/// </summary>
		ICommand _Generate2dObjectSet;

		/// <summary>
		/// Command for changing object save path.
		/// </summary>
		ICommand _ChangePath;

		#endregion

		#region Constructors

		public MainViewModel()
		{
			SavePath = "C:\\";
			generator = new ObjectGenerator();
			objectSetProperties2D = new ObjectSetProperties2D();
			objectSetProperties3D = new ObjectSetProperties3D();
		}

		#endregion

		#region Properties

		public string SavePath
		{
			get
			{
				return savePath;
			}
			set
			{
				savePath = value;
				RaisePropertyChanged("SavePath");
			}
		}

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

		public ICommand ChangePath
		{
			get
			{
				if (_ChangePath == null)
				{
					_ChangePath = new Helpers.RelayCommand(
						param => ChangePath_Execute(),
						param => true
					);
				}
				return _ChangePath;
			}
		}

		#endregion

		#region Methods

		private void Generate2dObjectSet_Execute()
		{
			var objectSet = generator.Generate2DObjectSet(objectSetProperties2D);
			generator.SaveObjectSet(objectSet, SavePath);

			System.Windows.MessageBox.Show(string.Format("Object set {0} was successfully created at {1}", Path.GetFileNameWithoutExtension(SavePath), Path.GetPathRoot(SavePath)), "Success");
		}

		private bool Generate2dObjectSet_CanExecute()
		{
			return true;
		}

		private void ChangePath_Execute()
		{
			var saveFileDialog = new SaveFileDialog();

			saveFileDialog.Filter = "2D Object set file (*.2Dset)|*.2Dset";

			if (saveFileDialog.ShowDialog() == true)
			{
				SavePath = saveFileDialog.FileName;
			}
		}
		#endregion
	}
}
