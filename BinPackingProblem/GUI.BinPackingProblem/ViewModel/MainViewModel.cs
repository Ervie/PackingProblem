using GUI.Helpers;
using Logic.Algorithms;
using Logic.Algorithms.Enums;
using Logic.Algorithms.Structs;
using Logic.Domain.Figures;
using Logic.Domain.Objects;
using Logic.ObjectGenerator;
using Logic.Utilities.Files;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace GUI.BinPackingProblem.ViewModel
{
	internal class MainViewModel : BaseNotifyPropertyChanged
	{
		#region Fields

		private ObjectGenerator generator;

		private IAlgorithmFactory factory;

		private AlgorithmProperties algorithmProperties;

		private AlgorithmExecutionResults results;

		private ObjectSet objectsToPack;

		private string _dialogBoxFilter;

		private string _dataPath;

		private bool _isSelectedAlgorithm3D;

		private int _containerWidth;

		private int _containerHeight;

		private int _containerDepth;

		public List<AlgorithmFamily> families;

		public List<ObjectFittingStrategy> strategies;

		public List<ContainerSplittingStrategy> splittingStrategies;

		private ICommand _LoadData;

		private ICommand _StartAlgorithm;

		#endregion Fields

		#region Constructors

		public MainViewModel()
		{
			Init();
		}

		#endregion Constructors

		#region Properties

		public ObjectSet ObjectsToPack
		{
			get
			{
				return objectsToPack;
			}
			set
			{
				objectsToPack = value;
				RaisePropertyChanged("ObjectsToPack");
			}
		}

		public string DataPath
		{
			get
			{
				return _dataPath;
			}
			set
			{
				_dataPath = value;
				RaisePropertyChanged("DataPath");
			}
		}

		public bool IsSelectedAlgorithm3D
		{
			get
			{
				return _isSelectedAlgorithm3D;
			}
			set
			{
				_isSelectedAlgorithm3D = value;
				RaisePropertyChanged("IsSelectedAlgorithm3D");
			}
		}

		public int ContainerWidth
		{
			get { return _containerWidth; }
			set
			{
				_containerWidth = value;
				RaisePropertyChanged("ContainerWidth");
			}
		}

		public int ContainerHeight
		{
			get { return _containerHeight; }
			set
			{
				_containerHeight = value;
				RaisePropertyChanged("ContainerHeight");
			}
		}

		public int ContainerDepth
		{
			get { return _containerDepth; }
			set
			{
				_containerDepth = value;
				RaisePropertyChanged("ContainerDepth");
			}
		}

		public AlgorithmDimensionality Dimensionality
		{
			get
			{
				return algorithmProperties.Dimensionality;
			}
			set
			{
				algorithmProperties.Dimensionality = value;
				HandleDimensionalityChange();
				RaisePropertyChanged("Dimensionality");
			}
		}

		public AlgorithmFamily Family
		{
			get
			{
				return algorithmProperties.Family;
			}
			set
			{
				algorithmProperties.Family = value;
				HandleFamilyChange();
				RaisePropertyChanged("Family");
			}
		}

		public List<AlgorithmFamily> Families
		{
			get
			{
				return families;
			}
			set
			{
				families = value;
				RaisePropertyChanged("Families");
			}
		}

		public ObjectFittingStrategy Strategy
		{
			get
			{
				return algorithmProperties.AlgorithmType;
			}
			set
			{
				algorithmProperties.AlgorithmType = value;
				RaisePropertyChanged("Strategy");
			}
		}

		public List<ObjectFittingStrategy> Strategies
		{
			get
			{
				return strategies;
			}
			set
			{
				strategies = value;
				RaisePropertyChanged("Strategies");
			}
		}

		public ContainerSplittingStrategy SplittingStrategy
		{
			get
			{
				return algorithmProperties.SplittingStrategy;
			}
			set
			{
				algorithmProperties.SplittingStrategy = value;
				RaisePropertyChanged("SplittingStrategy");
			}
		}

		public List<ContainerSplittingStrategy> SplittingStrategies
		{
			get
			{
				return splittingStrategies;
			}
			set
			{
				splittingStrategies = value;
				RaisePropertyChanged("SplittingStrategies");
			}
		}

		#endregion Properties

		#region Commands

		public ICommand LoadData
		{
			get
			{
				if (_LoadData == null)
				{
					_LoadData = new Helpers.RelayCommand(
						param => LoadData_Execute(),
						param => true
					);
				}
				return _LoadData;
			}
		}

		public ICommand StartAlgorithm
		{
			get
			{
				if (_StartAlgorithm == null)
				{
					_StartAlgorithm = new Helpers.RelayCommand(
						param => StartAlgorithm_Execute(),
						param => StartAlgorithm_CanExecute()
					);
				}
				return _StartAlgorithm;
			}
		}



		#endregion Commands

		#region Methods

		private void Init()
		{
			generator = new ObjectGenerator();
			factory = new AlgorithmFactory();
			algorithmProperties = new AlgorithmProperties();
			results = new AlgorithmExecutionResults();

			HandleDimensionalityChange();
		}

		private void HandleDimensionalityChange()
		{
			switch (Dimensionality)
			{
				case (AlgorithmDimensionality.TwoDimensional):
					Families = Enum.GetValues(typeof(AlgorithmFamily)).Cast<AlgorithmFamily>().ToList();
					_dialogBoxFilter = "2D Object set file (*.2Dset)|*.2Dset";
					DataPath = string.Empty;
					objectsToPack = null;
					IsSelectedAlgorithm3D = false;
					break;

				case (AlgorithmDimensionality.ThreeDimensional):
					Families = Enum.GetValues(typeof(AlgorithmFamily)).Cast<AlgorithmFamily>().Where(e => !e.Equals(AlgorithmFamily.Skyline)).ToList();
					_dialogBoxFilter = "3D Object set file (*.3Dset)|*.3Dset";
					DataPath = string.Empty;
					objectsToPack = null;
					IsSelectedAlgorithm3D = true;
					break;

				default:
					break;
			}
			HandleFamilyChange();
		}

		private void HandleFamilyChange()
		{
			switch (Dimensionality)
			{
				case (AlgorithmDimensionality.TwoDimensional):

					switch (Family)
					{
						case (AlgorithmFamily.Shelf):
							Strategies = Enum.GetValues(typeof(ObjectFittingStrategy)).Cast<ObjectFittingStrategy>().Where(e =>
																								e.Equals(ObjectFittingStrategy.NextFit) ||
																								e.Equals(ObjectFittingStrategy.FirstFit) ||
																								e.Equals(ObjectFittingStrategy.BestAreaFit) ||
																								e.Equals(ObjectFittingStrategy.WorstAreaFit) ||
																								e.Equals(ObjectFittingStrategy.BestWidthFit) ||
																								e.Equals(ObjectFittingStrategy.WorstWidthFit) ||
																								e.Equals(ObjectFittingStrategy.BestHeightFit)
																								).ToList();
							SplittingStrategies = null;
							break;

						case (AlgorithmFamily.GuillotineCut):
							Strategies = Enum.GetValues(typeof(ObjectFittingStrategy)).Cast<ObjectFittingStrategy>().Where(e =>
																								e.Equals(ObjectFittingStrategy.BestAreaFit) ||
																								e.Equals(ObjectFittingStrategy.WorstAreaFit) ||
																								e.Equals(ObjectFittingStrategy.BestLongSideFit) ||
																								e.Equals(ObjectFittingStrategy.WorstLongSideFit) ||
																								e.Equals(ObjectFittingStrategy.BestShortSideFit) ||
																								e.Equals(ObjectFittingStrategy.WorstShortSideFit) ||
																								e.Equals(ObjectFittingStrategy.BottomLeft)
																								).ToList();
							SplittingStrategies = Enum.GetValues(typeof(ContainerSplittingStrategy)).Cast<ContainerSplittingStrategy>().Where(e =>
																								!e.Equals(ContainerSplittingStrategy.None)).ToList();
							break;

						case (AlgorithmFamily.Skyline):
							Strategies = Enum.GetValues(typeof(ObjectFittingStrategy)).Cast<ObjectFittingStrategy>().Where(e =>
																								e.Equals(ObjectFittingStrategy.BottomLeft) ||
																								e.Equals(ObjectFittingStrategy.BestFitBestContainer) ||
																								e.Equals(ObjectFittingStrategy.BestFitFirstContainer)
																								).ToList();
							SplittingStrategies = null;
							break;

						default:
							Strategies = null;
							SplittingStrategies = null;
							break;
					}

					break;

				case (AlgorithmDimensionality.ThreeDimensional):

					switch (Family)
					{
						case (AlgorithmFamily.Shelf):
							Strategies = null;
							break;

						case (AlgorithmFamily.GuillotineCut):
							Strategies = null;
							break;

						default:
							Strategies = null;
							break;
					}
					SplittingStrategies = null;
					break;

				default:
					break;
			}
		}

		private void LoadData_Execute()
		{
			try
			{
				var loadFileDialog = new OpenFileDialog();

				loadFileDialog.Filter = _dialogBoxFilter;

				if (loadFileDialog.ShowDialog() == true)
				{
					if (FileHelper.HasAccessPermission(loadFileDialog.FileName) && FileHelper.DirectoryExist(loadFileDialog.FileName))
					{
						DataPath = loadFileDialog.FileName;
						objectsToPack = generator.LoadObjectSet(DataPath);
					}
					else
					{
						System.Windows.MessageBox.Show(string.Format("Error during loading data: Access is denied."), "Error");
						DataPath = string.Empty;
					}
				}
			}
			catch (Exception err)
			{
				System.Windows.MessageBox.Show("Error during loading data:" + err.Message, "Error");
			}
		}

		private bool StartAlgorithm_CanExecute()
		{
			return (ObjectsToPack != null && ContainerDepth > 0 && ContainerHeight > 0 && ContainerWidth > 0);
		}

		private void StartAlgorithm_Execute()
		{
			IFigure startingContainer = PrepareStartingContainer();

			var algorithm = factory.Create(algorithmProperties, startingContainer);
		}

		#endregion Methods
	}
}