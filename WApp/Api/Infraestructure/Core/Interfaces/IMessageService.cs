﻿using Stripe;
using System.Net.Mail;

namespace WApp.Api.Infraestructure.Core.Interfaces
{
    public interface IMessageService
    {
        MailMessage GenerateMessage(string actionDescription, Receipt payment = null, string phoneNumber = "", string to = "");
    }
}
