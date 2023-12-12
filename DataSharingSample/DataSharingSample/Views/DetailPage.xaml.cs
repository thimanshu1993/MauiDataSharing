using DataSharingSample.Helper;
using DataSharingSample.ViewModels;

namespace DataSharingSample.Views;

public partial class DetailPage : ContentPage
{
	public DetailPage()
	{
		InitializeComponent();
        BindingContext = ServiceHelper.GetService<DetailPageViewModel>();
    }
}
