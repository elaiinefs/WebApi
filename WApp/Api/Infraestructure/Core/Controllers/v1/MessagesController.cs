using System;
using System.Collections.Generic;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stripe;
using WApp.Api.Infraestructure.Core.Interfaces;
using WApp.Api.Infraestructure.Core.Services;

namespace WApp.Api.Infraestructure.Core.Controllers
{
    [Route("api/v1/[controller]")]
    public class MessagesController : Controller
    {
        public readonly IMessageService _messageService;
        private readonly IErrorHandlerService _errorService;

        public MessagesController(IMessageService messageService, IErrorHandlerService errorService)
        {
            _messageService = messageService;
            _errorService = errorService;
        }
        [HttpPost, Route("Send")]
        public IActionResult Send([FromBody]Receipt payment = null, string actionDescription = "", string phoneNumber = "", string emailAddress = null) 
        {
            try
            {
                _messageService.GenerateMessage(actionDescription, payment, phoneNumber, emailAddress);
                return Json(new { status = "success", message = "Message sent."});
            }
            catch (Exception e)
            {
                _errorService.LogError(e);
                return Json(new { status = "error", message = "Message not sent.."});
            }
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