using InstallmentApp_Front.Pages;
using InstallmentApp_Front.Services;
using InstallmentApp_Front.ViewModel;
using Microsoft.Extensions.Logging;

namespace InstallmentApp_Front;

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

		builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
		builder.Services.AddSingleton<Cabinet>();
        builder.Services.AddSingleton<Installment>();
        builder.Services.AddSingleton<Login>();
        

        builder.Services.AddSingleton<CabinetViewModel>();
        builder.Services.AddSingleton<BaseViewModel>();

		builder.Services.AddSingleton<Installment_Service>();

        builder.Services.AddTransient<DetailsPage>();
		builder.Services.AddTransient<CardAdd>();

        builder.Services.AddTransient<DetailsViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
