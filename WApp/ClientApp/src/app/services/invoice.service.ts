import { Injectable, Inject, Output, Input } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { Config } from 'protractor';
import { Observable } from 'rxjs';

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
  public getInvoiceData(orderId) {
    //alert(this.accessPointUrl);
    return this.http.post(this.currentUrl + 'api/SampleData/CreateService/'+orderId, { headers: this.headers });
  }
  public printInvoice(order) {

  }
}
