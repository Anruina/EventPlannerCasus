using Camera.MAUI;
using InputKit.Handlers;
using Microsoft.Extensions.Logging;
using Plugin.LocalNotification;
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
                .UseLocalNotification() //for local pushnotifications
                .ConfigureMauiHandlers(handlers => 
                {
                    handlers.AddInputKitHandlers();
                })
                .ConfigureFonts(fonts =>
                {

                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialIcon");
                fonts.AddMaterialIconFonts();

                });
            

            #if DEBUG

    		    builder.Logging.AddDebug();

            #endif

            return builder.Build();
        }
    }
}
