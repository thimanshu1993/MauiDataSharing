using DataSharingSample.Abstract;
using DataSharingSample.Services;
using DataSharingSample.ViewModels;
using Microsoft.Extensions.Logging;

namespace DataSharingSample;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddTransient<HomePageViewModel>();
        builder.Services.AddTransient<DetailPageViewModel>();
        builder.Services.AddSingleton<ISharedService, SharedService>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

