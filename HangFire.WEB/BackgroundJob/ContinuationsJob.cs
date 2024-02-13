using System.Diagnostics;

namespace HangFire.WEB.BackgroundJob
{
    public class ContinuationsJob
    {

        public static void WriteWaterMarkStatus(string id, string fileName)
        {
            Hangfire.BackgroundJob.ContinueJobWith(id, () => Debug.WriteLine("mark added"));
        }
        
    }
}
