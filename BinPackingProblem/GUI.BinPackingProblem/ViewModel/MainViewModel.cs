using GUI.Helpers;
using Logic.Algorithms;
using Logic.Algorithms.Containers;
using Logic.Algorithms.Enums;
using Logic.Algorithms.Sorting;
using Logic.Algorithms.Structs;
using Logic.Domain.Containers;
using Logic.Domain.Containers._2D;
using Logic.Domain.Containers._3D;
using Logic.Domain.Figures;
using Logic.Domain.Objects;
using Logic.ObjectGenerator;
using Logic.Utilities.Files;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;

namespace GUI.BinPackingProblem.ViewModel
{
	internal class MainViewModel : BaseNotifyPropertyChanged
	{
		#region Fields

		private ObjectGenerator generator;

		private IContainerFactory containerFactory;

		private IAlgorithmFactory factory;

		private AlgorithmProperties algorithmProperties;

		private AlgorithmExecutionResults results;

		private ObjectSet objectsToPack;

		private Stopwatch stopwatch;

		private string _dialogBoxFilter;

		private string _dataPath;

		private bool _isSelectedAlgorithm3D;

		private int _containerWidth;

		private int _containerHeight;

		private int _containerDepth;

		public List<AlgorithmFamily> families;

		public List<ObjectFittingStrategy> strategies;

		public List<ContainerSplittingStrategy> splittingStrategies;

		public List<ObjectOrdering> objectOrderings;

		private ObjectOrdering objectOrdering;

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

		public ObjectOrdering ObjectOrdering
		{
			get
			{
				return objectOrdering;
			}
			set
			{
				objectOrdering = value;
				RaisePropertyChanged("ObjectOrdering");
			}
		}
		public List<ObjectOrdering> ObjectOrderings
		{
			get
			{
				return objectOrderings;
			}
			set
			{
				objectOrderings = value;
				RaisePropertyChanged("ObjectOrderings");
			}
		}


		public int ContainersUsed
		{
			get { return results.ContainersUsed; }
			set
			{
				results.ContainersUsed = value;
				RaisePropertyChanged("ContainersUsed");
			}
		}

		public int ObjectTotalFullfilment
		{
			get { return results.ObjectsTotalFulfillment; }
			set
			{
				results.ObjectsTotalFulfillment = value;
				RaisePropertyChanged("ObjectTotalFullfilment");
			}
		}

		public int ContainerFulfillment
		{
			get { return results.ContainerFulfillment; }
			set
			{
				results.ContainerFulfillment = value;
				RaisePropertyChanged("ContainerFulfillment");
			}
		}

		public double Quality
		{
			get { return results.Quality; }
			set
			{
				results.Quality = value;
				RaisePropertyChanged("Quality");
			}
		}

		public double AverageFulfillmentRatio
		{
			get { return results.AverageFulfillmentRatio; }
			set
			{
				results.AverageFulfillmentRatio = value;
				RaisePropertyChanged("AverageFulfillmentRatio");
			}
		}

		public double FulfillmentRatioStandardDeviation
		{
			get { return results.FulfillmentRatioStandardDeviation; }
			set
			{
				results.FulfillmentRatioStandardDeviation = value;
				RaisePropertyChanged("FulfillmentRatioStandardDeviation");
			}
		}

		public double WorstFulfillment
		{
			get { return results.WorstFulfillment; }
			set
			{
				results.WorstFulfillment = value;
				RaisePropertyChanged("WorstFulfillment");
			}
		}

		public long ExecutionTime
		{
			get { return results.ExecutionTime; }
			set
			{
				results.ExecutionTime = value;
				RaisePropertyChanged("ExecutionTime");
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
			containerFactory = new ContainerFactory();
			factory = new AlgorithmFactory();
			algorithmProperties = new AlgorithmProperties();
			results = new AlgorithmExecutionResults();
			stopwatch = new Stopwatch();

			HandleDimensionalityChange();
		}

		private void HandleDimensionalityChange()
		{
			switch (Dimensionality)
			{
				case (AlgorithmDimensionality.TwoDimensional):
					Families = Enum.GetValues(typeof(AlgorithmFamily)).Cast<AlgorithmFamily>().ToList();
					ObjectOrderings = Enum.GetValues(typeof(ObjectOrdering)).Cast<ObjectOrdering>().Where(x => !x.Equals(ObjectOrdering.ByDepth) &&
																												!x.Equals(ObjectOrdering.ByVolume) &&
																												!x.Equals(ObjectOrdering.BySurfaceArea) &&
																												!x.Equals(ObjectOrdering.ByWidthDepthRatio) &&
																												!x.Equals(ObjectOrdering.ByWidthDepthDifference) &&
																												!x.Equals(ObjectOrdering.ByWidthHeightRatio) &&
																												!x.Equals(ObjectOrdering.ByWidthHeightDifference) &&
																												!x.Equals(ObjectOrdering.ByHeightDepthRatio) &&
																												!x.Equals(ObjectOrdering.ByHeightDepthDifference)).ToList();
					_dialogBoxFilter = "2D Object set file (*.2Dset)|*.2Dset";
					DataPath = string.Empty;
					objectsToPack = null;
					IsSelectedAlgorithm3D = false;
					break;

				case (AlgorithmDimensionality.ThreeDimensional):
					Families = Enum.GetValues(typeof(AlgorithmFamily)).Cast<AlgorithmFamily>().Where(e => !e.Equals(AlgorithmFamily.Skyline)).ToList();
					ObjectOrderings = Enum.GetValues(typeof(ObjectOrdering)).Cast<ObjectOrdering>().Where(x => !x.Equals(ObjectOrdering.ByArea) &&
																							!x.Equals(ObjectOrdering.ByPerimeter) &&
																							!x.Equals(ObjectOrdering.BySideDifference) &&
																							!x.Equals(ObjectOrdering.BySideRatio)).ToList();
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
				System.Windows.MessageBox.Show("Error during loading data: " + err.Message, "Error");
			}
		}

		private bool StartAlgorithm_CanExecute()
		{
			return (ObjectsToPack != null && ContainerWidth > 0 && ContainerHeight > 0 && (ContainerDepth > 0 || Dimensionality.Equals(AlgorithmDimensionality.TwoDimensional)));
		}

		private void StartAlgorithm_Execute()
		{
			try
			{
				IAlgorithm algorithm;

				if (!CheckContainerSize())
					throw new InvalidContainerSizeException("Container is not big enough to contain biggest object. Enlarge the container.");

				if (Dimensionality == AlgorithmDimensionality.TwoDimensional)
				{
					Container2D startingContainer = containerFactory.Create(algorithmProperties, ContainerWidth, ContainerHeight);
					algorithm = factory.Create(algorithmProperties, startingContainer);
				}
				else
				{
					Container3D startingContainer = containerFactory.Create(algorithmProperties, ContainerWidth, ContainerHeight, ContainerDepth);
					algorithm = factory.Create(algorithmProperties, startingContainer);
				}

				stopwatch.Reset();

				var sortedObjects = SortingHelper.Sort(objectsToPack, ObjectOrdering);

				stopwatch.Start();
				algorithm.Execute(sortedObjects);
				stopwatch.Stop();

				var endResults = algorithm.CreateResults();

				ExecutionTime = stopwatch.ElapsedMilliseconds;
				Quality = endResults.Quality;
				ContainersUsed = endResults.ContainersUsed;
				ObjectTotalFullfilment = endResults.ObjectsTotalFulfillment;
				ContainerFulfillment = endResults.ContainerFulfillment;
				AverageFulfillmentRatio = endResults.AverageFulfillmentRatio;
				FulfillmentRatioStandardDeviation = endResults.FulfillmentRatioStandardDeviation;
				WorstFulfillment = endResults.WorstFulfillment;
			}
			catch (Exception err)
			{
				System.Windows.MessageBox.Show("Error during executing algorithm: " + err.Message, "Error");
			}	
		}

		/// <summary>
		/// Check if container(s) is(are) big enough to contain every object.
		/// </summary>
		/// <returns>True - big enough, false - not</returns>
		private bool CheckContainerSize()
		{
			if (Dimensionality == AlgorithmDimensionality.TwoDimensional)
			{
				if (objectsToPack.Max(x => (x as Object2D).Height) > ContainerHeight ||
					objectsToPack.Max(x => (x as Object2D).Width) > ContainerWidth)
					return false;
			}
			else
			{
				if (objectsToPack.Max(x => (x as Object3D).Height) > ContainerHeight ||
					objectsToPack.Max(x => (x as Object3D).Width) > ContainerWidth ||
					objectsToPack.Max(x => (x as Object3D).Depth) > ContainerDepth)
					return false;
			}

			return true;
		}
		#endregion Methods
	}
}