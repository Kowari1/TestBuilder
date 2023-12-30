using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Test_Builder.Pages;
using Test_Builder.Services;
using Test_Builder.ViewModels;

namespace Test_Builder;

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

#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<IFileService>(new JsonFormatterService());

        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<MainPageViewModel>();

        builder.Services.AddTransient<CreateTestPage>();
        builder.Services.AddTransient<CreateTestPageViewModel>();

        return builder.Build();
	}
}
