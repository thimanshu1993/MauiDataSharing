using DataSharingSample.Helper;
using DataSharingSample.ViewModels;

namespace DataSharingSample.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
		BindingContext = ServiceHelper.GetService<HomePageViewModel>();
	}
}
