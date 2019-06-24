using System;
using System.Collections.Generic;

namespace WApp.Api.Infraestructure.Data.Entities
{
    public partial class DialyActSummary
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Ammount { get; set; }
        public string RefAmount { get; set; }
        public string NumofSales { get; set; }
        public string MonthSubT { get; set; }
        public string CostOfSales { get; set; }
        public string OrderAmount { get; set; }
        public string LayawayAmount { get; set; }
        public string LayawayDeposit { get; set; }
        public string Refunds { get; set; }
        public string Tax1Collect { get; set; }
        public string Tax2Collect { get; set; }
        public string Tax1Refund { get; set; }
        public string Tax2Refund { get; set; }
        public string AmountSold { get; set; }
        public string ItemsSold { get; set; }
        public string YToDateSales { get; set; }
    }
}
