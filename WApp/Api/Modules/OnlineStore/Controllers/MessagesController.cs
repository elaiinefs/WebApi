using System;
using System.Collections.Generic;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using WApp.Api.Infraestructure.Core.Interfaces;

namespace WApp.Api.Modules.OnlineStore.Controllers
{
    [Route("api/v1/[controller]")]
    public class MessagesController : Controller
    {
        public readonly IMessageService _messageService;
        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        [HttpGet, Route("SendMessage")]
        public string SendMessage(string actionDescription, string phoneNumber = "", string emailAddress = null) 
        {
            _messageService.GenerateMessage(actionDescription, phoneNumber, emailAddress);
            return "sent";

        }
    }
}