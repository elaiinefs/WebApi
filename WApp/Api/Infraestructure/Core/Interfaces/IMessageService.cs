using System.Net.Mail;

namespace WApp.Api.Infraestructure.Core.Interfaces
{
    public interface IMessageService
    {
        MailMessage GenerateMessage(string actionDescription, string phoneNumber = "", string to = "");
    }
}
