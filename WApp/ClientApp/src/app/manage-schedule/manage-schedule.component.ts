import { Component, OnInit, EventEmitter, Input, Output, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import * as _ from 'lodash';
import { Router } from '@angular/router';

@Component({
  selector: 'app-manage-schedule',
  templateUrl: './manage-schedule.component.html',
  styleUrls: ['./manage-schedule.component.css']
})
export class ManageScheduleComponent implements OnInit {
  //@Output() scheduleCreated = new EventEmitter<any>();
  //@Output() schedulePaid = new EventEmitter<any>();
  //@Output() accountConnected = new EventEmitter<any>();

  //@Input() scheduleInfo: any;
  //@Input() paymentInfo: any;
  //@Input() paymentStatusMessage: any;
  //@Input() getScheduleId: any;

  //uFirst: any;
  //uLast: any;
  //expYear: any;
  //expMonth: any;
  //cNumber: any;
  //cardNumberEd: any;
  //withNoDigits: any;

  //private headers: HttpHeaders;

  //constructor(@Inject('BASE_URL') baseUrl: string) {
  //  this.clearScheduleInfo();
  //  this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  //}

  //private clearScheduleInfo = function () {
  //  // Create an empty service object
  //  this.scheduleInfo = {
  //    id: undefined,
  //    Title: '',
  //    Desc: '',
  //    ModifiedDate: '',
  //    AssignedComp: '',
  //    StatusReason: '',
  //    IncType: '',
  //    CreatedBy: '|'
  //  };
  //};
  //private clearPaymentInfo = function () {
  //  this.paymentInfo = {
  //    CardOwnerFirstName: "",
  //    CardOwnerLastName: "",
  //    CardNumber: 0,
  //    ExpirationYear: 0,
  //    ExpirationMonth: 0,
  //    CVV2: 0,
  //    Buyer_Email: "",
  //    Amount: "",
  //    CurrencyId: 0,
  //    TransactionId: 0,
  //  }
  //}
  //public payScheduleRecord = function (sTitle, cNumber, expYear, expMonth, cardCVV, uFirst, uLast, uEmail) {
  //  if (!(cNumber.indexOf(";") != -1)) {
  //    this.paymentInfo = {
  //      CardOwnerFirstName: uFirst,
  //      CardOwnerLastName: uLast,
  //      CardNumber: cNumber,
  //      ExpirationYear: expYear,
  //      ExpirationMonth: expMonth,
  //      CVV2: cardCVV,
  //      Buyer_Email: uEmail,
  //      Amount: sTitle,
  //      CurrencyId: 0,
  //      TransactionId: parseInt(this.getScheduleId),
  //    }
  //  } else {
  //    uFirst = cNumber.split("^", 2)[0].split("/", 1)[1];
  //    uLast = cNumber.split("^", 2)[0].split("/", 1)[0];
  //    expYear = cNumber.split("=", 1).substring(0, 2);
  //    expMonth = cNumber.split("=", 1).substring(2, 4);
  //    cNumber = cNumber.split(";", 1)[0].split("=", 1)[0];
  //    this.paymentInfo = {
  //      CardOwnerFirstName: uFirst,
  //      CardOwnerLastName: uLast,
  //      CardNumber: cNumber,
  //      ExpirationYear: expYear,
  //      ExpirationMonth: expMonth,
  //      CVV2: cardCVV,
  //      Buyer_Email: uEmail,
  //      Amount: sTitle,
  //      CurrencyId: 0,
  //      TransactionId: parseInt(this.getScheduleId),
  //    }
  //  }
  //  //alert(this.getScheduleId);
  //  //alert(this.paymentInfo);
  //  this.schedulePaid.emit(this.paymentInfo);

  //  this.sMessage = this.paymentStatusMessage;
  //  //alert(this.paymentStatusMessage);
  //  this.clearServiceInfo();
  //  this.sTitle = '';
  //  this.sDesc = '';
  //  this.sNotes = '';
  //  this.sCompany = '';
  //  this.sType = '';
  //  this.sDate = '';
  //  this.uFirst = '';
  //  this.uLast = '';
  //  this.uPhone = '';
  //  this.uEmail = '';

  //  this.clearScheduleInfo();
  //  this.clearPaymentInfo();
  //};
  //public addOrUpdateScheduleRecord = function (sTitle, sDesc, sNotes, sCompany, sType, sDate, sTime, uFirst, uLast, uPhone, uEmail) {
  //  this.stripeParams = {
  //    id: undefined,
  //    Title: sTitle,
  //    Desc: sDesc,
  //    ModifiedDate: sDate + sTime,
  //    AssignedComp: sCompany,
  //    StatusReason: sNotes,
  //    IncType: sType,
  //    CreatedBy: uFirst + "|" + uLast + "|" + uPhone + "|" + uEmail
  //  }


  //  this.sMessage = 'Successfully scheduled!';
  //  //alert(this.scheduleInfo.Title);
  //  //alert(this.scheduleInfo.Title);
  //  this.scheduleCreated.emit(this.scheduleInfo);

  //  this.clearScheduleInfo();
  //};

  ngOnInit() {
  }

}
