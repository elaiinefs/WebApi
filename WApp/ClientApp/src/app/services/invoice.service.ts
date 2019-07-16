import { Injectable, Inject, Output, Input } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { Config } from 'protractor';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {
  private currentUrl: string;
  private headers: any;
  @Input() printingInvoice : any;
  constructor(private http: HttpClient, private router: Router, @Inject('BASE_URL') baseUrl: string) {
    this.currentUrl = baseUrl;
  }
  public sendInvoice = function (order: any) {
    var receipt: Receipt;
    receipt = {
      description: order.description,
      customer: order.billing_details.name,
      id: order.id,
      createdDate: order.created,
      amount: order.amount,
      cardBrand: order.payment_method_details.card.brand,
      cardFunding: order.payment_method_details.card.funding,
      last4: order.payment_method_details.card.last4,
      email: order.billing_details.email,
      phoneNumber: order.customer.phone,
    }
      return this.http.post(environment.apiEndpoint + 'api/v1/Messages/Send', receipt, { headers: this.headers })
        .pipe(map((res: Response) => {
          return res.status;
      }));
  }
}
interface Receipt {
  description: string;
  customer: string;
  id: string;
  createdDate: string;
  amount: string;
  cardBrand: string;
  cardFunding: string;
  last4: string;
  email: string;
  phoneNumber: string;
}
