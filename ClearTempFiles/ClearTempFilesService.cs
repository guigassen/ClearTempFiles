using System;
using System.IO;
using System.Timers;

namespace ClearTempFiles
{
    public class ClearTempFilesService
    {

        public void Start()
        {
            var _timer = new System.Timers.Timer();
            _timer.Interval = 60000;
            _timer.Enabled = true;
            _timer.Elapsed += _timer_Elapsed;
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var directory = Directory.CreateDirectory(@"C:/Users/ggassen/AppData/Local/Temp");
            foreach (FileInfo file in directory.EnumerateFiles())
            {
                try
                {
                    file.Delete();
                }

                catch (System.Exception excpt)
                {
                    Console.WriteLine(excpt.Message);
                    continue;
                }
            }
                 
            foreach (DirectoryInfo dir in directory.EnumerateDirectories())
            {
                try
                {
                    dir.Delete(true);
                }
                catch (System.Exception excpt)
                {
                    Console.WriteLine(excpt.Message);
                    continue;
                }
            }
            
            Console.WriteLine("The service is running at {0}", DateTime.Now);
        }

        public void Stop()
        {
            Console.WriteLine("The service has been stopped.");
        }
    }
}
