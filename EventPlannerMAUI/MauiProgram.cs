using Camera.MAUI;
using Microsoft.Extensions.Logging;
using UraniumUI;

namespace EventPlannerMAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder.UseMauiApp<App>()
                .UseUraniumUI() // for user interface
                .UseUraniumUIMaterial() // for icons
                .UseMauiCameraView() // for barcode generator
                .ConfigureFonts(fonts =>
            {

                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddMaterialIconFonts();

            });

            #if DEBUG

    		    builder.Logging.AddDebug();

            #endif

            return builder.Build();
        }
    }
}
