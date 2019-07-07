import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {
  @Output() paidOrder = new EventEmitter<any>();
  @Input() emptyCarField = this.emptyCarFields();
  @Input() sMessage: any;
  @Input() paymentError: any;
  @Input() paymentSucceed: boolean;
  @Output() paymentMessage: any;
  @Output() paymentErrorStatus: boolean;
  @Output() paymentSucceedStatus: boolean;
  //Order Info
  public subTotal: number;
  public total: number;
  public tax1: number;
  public tax2: number;
  public uEmail: any;
  public uPhone: any;
  public payStatus: string;
  //Payment Info
  uFirst: any;
  uLast: any;
  expYear: any;
  expMonth: any;
  cNumber: any;
  cardCVV: any;
  cardNumberEd: any;
  withNoDigits: any;
  constructor() { }

  ngOnInit() {
    //this.subTotal = 0;
    this.tax1 = 0;
    this.tax2 = 0;
    this.uEmail = "";
    this.payStatus = "Pay Now!";
    //this.tax1 = .105;
    //this.tax2 = .01;
  }
  public calculateTotal($event) {
    this.total = (this.subTotal * ((this.tax1 / 100) + (this.tax2 / 100))) + this.subTotal;
  }
  public emptyCarFields() {
    console.log("clearing");
    this.cNumber = '';
    this.expYear = '';
    this.expMonth = '';
    this.uFirst = '';
    this.uLast = '';
    this.cardCVV = '';
  }
  public fillCardData($event) {
    if (this.cNumber != '') {
      if (this.cNumber.indexOf(";") != -1) {
        this.cardNumberEd = (this.cNumber.substring(0, 18)).substr(2);
        this.cardNumberEd = (this.cNumber.substring(0, 18)).substr(2);
        this.expYear = (this.cNumber.split("=", 2)[1]).substring(0, 2);
        this.expMonth = (this.cNumber.split("=", 2)[1]).substring(2, 4);
        this.uFirst = (this.cNumber.split("/", 2)[1]).split("^", 2)[0];
        this.uLast = (this.cNumber.split("/", 1)[0]).split("^", 2)[1];
        this.cNumber = this.cardNumberEd;
        this.withNoDigits = this.uFirst.replace(/[0-9]/g, '');
        this.uFirst = this.withNoDigits;
        this.withNoDigits = this.uLast.replace(/[0-9]/g, '');
        this.uLast = this.withNoDigits;
        this.uFirst = this.uFirst + " " + this.uLast;
      }
    }
  }
  public async payOrder(total, cNumber, expYear, expMonth, cardCVV, uPhone, uFirst, uLast, uEmail): Promise<string> {
    var paymentInfo: any;
    if (cNumber !== null) {

      if (!(cNumber.indexOf(";") != -1)) {
        paymentInfo = {
          CardOwnerFirstName: uFirst,
          CardOwnerLastName: uLast,
          CardNumber: cNumber,
          ExpirationYear: expYear,
          ExpirationMonth: expMonth,
          CVV2: cardCVV,
          Buyer_Email: uEmail,
          PhoneNumber: uPhone,
          Amount: total * 100,
          CurrencyId: 0,
          ChargeId: "",
          BusinessEmail: localStorage.getItem("user_email")
          //TransactionId: parseInt(this.getScheduleId),
        }
      } else {
        uFirst = cNumber.split("^", 2)[0].split("/", 1)[1];
        uLast = cNumber.split("^", 2)[0].split("/", 1)[0];
        expYear = cNumber.split("=", 1).substring(0, 2);
        expMonth = cNumber.split("=", 1).substring(2, 4);
        cNumber = cNumber.split(";", 1)[0].split("=", 1)[0];
        paymentInfo = {
          CardOwnerFirstName: uFirst,
          CardOwnerLastName: uLast,
          CardNumber: cNumber,
          ExpirationYear: expYear,
          ExpirationMonth: expMonth,
          CVV2: cardCVV,
          Buyer_Email: uEmail,
          PhoneNumber: uPhone,
          Amount: total * 100,
          CurrencyId: 0,
          ChargeId: "",
          BusinessEmail: localStorage.getItem("user_email")
          //TransactionId: parseInt(this.getScheduleId),
        }
      }
      this.emptyCarFields();
    } else {
      paymentInfo = {
        CardOwnerFirstName: "",
        CardOwnerLastName: "",
        CardNumber: "",
        ExpirationYear: 0,
        ExpirationMonth: 0,
        CVV2: "",
        Buyer_Email: "",
        PhoneNumber: "",
        Amount: 0,
        CurrencyId: 0,
        ChargeId:"",
        BusinessEmail: localStorage.getItem("user_email")
      }
    }
    this.payStatus = "Processing...";
    console.log(paymentInfo);
    this.sMessage = await this.paidOrder.emit(paymentInfo);
    this.payStatus = "Pay Now";
    //this.paymentStatusMessage;
    return "completed";
  };
}
