namespace HangFire.WEB.Services
{
    public interface IEmeailSender
    {
        Task Sender(string userId, string message);
    }
}
