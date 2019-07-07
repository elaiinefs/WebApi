import { Component, Inject, Output, EventEmitter } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import * as _ from 'lodash';

import { Config } from 'protractor';
import { Router } from '@angular/router';

import { environment } from '../../environments/environment';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public order: Order;
  @Output() sMessage: any;
  @Output() paymentError: boolean;
  @Output() paymentSucceed: boolean;
  @Output() ProcessingPayment: boolean;
  @Output() fillInvoice = new EventEmitter<any>();
  @Output() clearCardFields = new EventEmitter<any>();

  @Output() orderData : any;

  //paymentStatus = "not payed.";
  scheduleId = "0";
  private headers: HttpHeaders;
  private currentUrl:string;
  @Inject('BASE_URL') public accessPointUrl: string;
  configUrl = 'assets/config.json';
  constructor(private http: HttpClient, private router: Router, @Inject('BASE_URL') baseUrl: string) {
    this.currentUrl = baseUrl;
    this.paymentError = false;
    this.paymentSucceed = false;
    this.ProcessingPayment = false;
    this.headers = new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8',
      'Stripe-Account':'acct_1EHCbXAdyX2SDB4E'
    });
  }
  getConfigResponse(): Observable<HttpResponse<Config>> {
    return this.http.get<Config>(
      this.configUrl, { observe: 'response' });
  }
  public payingOrder = function (paymentInfo: any) {
    this.paymentError = false;
    this.paymentSucceed = false;
    this.ProcessingPayment = true;
    this.headers.append(localStorage.getItem("user_email"));
    return this.http.post(environment.apiEndpoint + 'api/v1/Payments/Pay', paymentInfo, { headers: this.headers })
      .subscribe(
      res => {
        this.sMessage = res.message;
        if (res.status == "Error") {
          this.paymentError = true;
          this.paymentSucceed = false;
          this.ProcessingPayment = false;
        }
        else {
          this.paymentError = false;
          this.paymentSucceed = true;
          this.ProcessingPayment = false;
          console.log(res);
          this.fillInvoice.emit(paymentInfo);
          console.log(res.objectValue);
          this.order = res.objectValue;
          console.log(this.order);
          this.clearCardFields.emit();
        }
      });
  };

}
interface Order {
  id: string;
  object: string;
  amount: string;
  amount_refunded: string;
  created: Date;
  billing_details: object;
  Customer: object;
  Description: string;
  FailureCode: string;
  FailureMessage: string;
  paid: string;
  refunded: string;
  status: string;
  payment_method_details: object;
  refunds: object;
}
