using GUI.BinPackingProblem.ViewModel;
using System.Windows;

namespace GUI.BinPackingProblem
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			this.DataContext = new MainViewModel();
		}
	}
}