using System;
using System.Collections.Generic;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using WApp.Api.Infraestructure.Core.Interfaces;

namespace WApp.Api.Infraestructure.Core.Controllers
{
    [Route("api/v1/[controller]")]
    public class MessagesController : Controller
    {
        public readonly IMessageService _messageService;
        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        [HttpPost, Route("Send")]
        public string Send([FromBody]Receipt payment = null, string actionDescription = "", string phoneNumber = "", string emailAddress = null) 
        {
            _messageService.GenerateMessage(actionDescription, payment, phoneNumber, emailAddress);
            return "sent";

        }
    }
}
public class Receipt
{
    public string Description { get; set; }
    public string Customer { get; set; }
    public string Id { get; set; }
    public string CreatedDate { get; set; }
    public string Amount { get; set; }
    public string CardBrand { get; set; }
    public string CardFunding { get; set; }
    public string Last4 { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}