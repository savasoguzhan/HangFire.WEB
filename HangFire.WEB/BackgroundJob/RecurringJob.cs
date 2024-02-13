using Hangfire;
using System.Diagnostics;

namespace HangFire.WEB.BackgroundJob
{
    public class RecurringJob
    {
        public static void ReportingJob()
        {
            Hangfire.RecurringJob.AddOrUpdate("reportJob1", () => EmailReport(),Cron.Minutely);
        }

        public static void EmailReport()
        {
            Debug.WriteLine("Rapor, Email olarak gonderildi");
        }

    }
}
