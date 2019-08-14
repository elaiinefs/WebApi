using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WApp.Api.Modules.OnlineStore.Interfaces;
using WApp.Api.Modules.OnlineStore.Models;

namespace WApp.Api.Modules.OnlineStore.Services
{

    public class StripeChargesService : IStripeChargesService
    {
        public readonly IStripeCustomerService _stripeCustomerService;

        public StripeChargesService(IStripeCustomerService stripeCustomerService)
        {
            _stripeCustomerService = stripeCustomerService;
        }
        public ChargeCreateOptions Options(int amount, int? currency, string customerEmail, string customerId, string businessName, string businessAddress)
        {
            var options = new ChargeCreateOptions
            {
                Amount = amount,
                Currency = currency == 1 ? "ILS" : "USD",
                ReceiptEmail = customerEmail,
                Description = businessName + "\n" + businessAddress,
                CustomerId = customerId,
                //ApplicationFeeAmount = Convert.ToInt32(amountTotal * .01),
                //Description = Convert.ToString(paymentInfo.TransactionId), //Optional  
            };
            return options;
        }

        public Charge CreateCharge(ChargeCreateOptions options)
        {
            var service = new ChargeService();
            service.ExpandCustomer = true;
            Charge charge = service.Create(options);// This will do the Payment
            return charge;
        }

        public List<Charge> List()
        {
            //StripeConfiguration.SetApiKey(_config.GetSection("api_key").Value);

            var service = new ChargeService();
            
            var optionsl = new ChargeListOptions
            {
                Limit = 100,
            };
            var orders = service.List(optionsl);
            foreach (var order in orders)
            {
                var services = new ChargeService();
                var options = new ChargeGetOptions();
                options.AddExpand("customer");
                options.AddExpand("order");
                var charge = service.Get(order.Id, options);
                order.Created = charge.Created.Date;
                order.Amount = charge.Amount;
                order.AmountRefunded = charge.AmountRefunded;
                if (order.Customer != null)
                {
                    if (charge.Customer.Email == "zaraiipay@gmail.com")
                    {
                        charge.Customer.Email = "";
                    }
                }
            }
            return orders.Data;
        }

        public Year Summary()
        {
            var year = new Year();
            var service = new ChargeService();

            service.ExpandCustomer = false;
            service.ExpandOrder = true;
            var options = new ChargeListOptions
            {
                Limit = 100,
            };
            var orders = service.List(options);
            foreach (var order in orders)
            {
                if (order.Created.Year == DateTime.Now.Year)
                {
                    switch (order.Created.Month)
                    {
                        case 1:
                            year.jan++;
                            break;
                        case 2:
                            year.feb++;
                            break;
                        case 3:
                            year.mar++;
                            break;
                        case 4:
                            year.apr++;
                            break;
                        case 5:
                            year.may++;
                            break;
                        case 6:
                            year.jun++;
                            break;
                        case 7:
                            year.jul++;
                            break;
                        case 8:
                            year.aug++;
                            break;
                        case 9:
                            year.sep++;
                            break;
                        case 10:
                            year.oct++;
                            break;
                        case 11:
                            year.nov++;
                            break;
                        case 12:
                            year.dec++;
                            break;
                        default:
                            Console.WriteLine("Other");
                            break;
                    }
                    year.totalOrders++;
                    year.yearTotal += order.Amount;
                    year.refundedTotal += order.AmountRefunded;

                }
            }
            year.totalCustomers = _stripeCustomerService.Count();
            //ordersPerMonth = new int[]{0,12,40,50};
            return year;
        }

        public Sales Sales()
        {
            var year = new Sales();
            var service = new ChargeService();
            service.ExpandCustomer = true;
            service.ExpandOrder = true;
            var options = new ChargeListOptions
            {
                Limit = 100,
            };
            var orders = service.List(options);
            foreach (var order in orders)
            {
                if (order.Created.Year == DateTime.Now.Year)
                {
                    switch (order.Created.Month)
                    {
                        case 1:
                            year.jan += order.Amount;
                            break;
                        case 2:
                            year.feb += order.Amount;
                            break;
                        case 3:
                            year.mar += order.Amount;
                            break;
                        case 4:
                            year.apr += order.Amount;
                            break;
                        case 5:
                            year.may += order.Amount;
                            break;
                        case 6:
                            year.jun += order.Amount;
                            break;
                        case 7:
                            year.jul += order.Amount;
                            break;
                        case 8:
                            year.aug += order.Amount;
                            break;
                        case 9:
                            year.sep += order.Amount;
                            break;
                        case 10:
                            year.oct += order.Amount;
                            break;
                        case 11:
                            year.nov += order.Amount;
                            break;
                        case 12:
                            year.dec += order.Amount;
                            break;
                        default:
                            Console.WriteLine("Other");
                            break;
                    }
                }
                order.Created = order.Created.Date;
                order.Amount = order.Amount;
                order.AmountRefunded = order.AmountRefunded;
            }
            return year;
        }
    }
}
