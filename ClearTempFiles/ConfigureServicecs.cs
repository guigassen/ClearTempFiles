using Topshelf;

namespace ClearTempFiles
{
    public class ConfigureService
    {
        internal static void Configure()
        {
            HostFactory.Run(configure =>
            {
                configure.Service<ClearTempFilesService>(service =>
                {
                    service.ConstructUsing(s => new ClearTempFilesService());
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                });

                configure.RunAsLocalSystem();
                configure.SetServiceName("ClearTempFilesService");
                configure.SetDisplayName("ClearTempFilesService");
                configure.SetDescription("This service will clear temp files in Windows.");
            });
        }
    }
}
