using TabManager.ViewModels;
using TabManager.Views;

namespace TabManager;

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
                fonts.AddFont("materialdesignicons-webfont.ttf", "IconFontTypes");
            });
		builder.Services.AddSingleton<MainPageViewModel>();
        builder.Services.AddSingleton<AddTabGroupViewModel>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<AddTabGroupPage>();
        return builder.Build();
	}
}
