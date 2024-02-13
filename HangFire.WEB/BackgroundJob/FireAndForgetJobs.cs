using HangFire.WEB.Services;

namespace HangFire.WEB.BackgroundJob
{
    public class FireAndForgetJobs
    {
        public static void EmailSendToUserJob(string userId, string message)
        {
            Hangfire.BackgroundJob.Enqueue<IEmeailSender>(x => x.Sender(userId, message));



        }


    }
}
