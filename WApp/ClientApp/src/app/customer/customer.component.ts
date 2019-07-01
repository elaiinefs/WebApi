import { Component, Inject } from "@angular/core";
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent{
  public customers: Customers[];
  private headers: HttpHeaders;
  createAuthorizationHeader(headers: Headers) {
    //headers.append('Authorization', 'Bearer ' +
    //  'sk_test_J55K1bgEQSvKRIEyQhxYWRpd00c5CKEOGv');
  }
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    http.get<Customers[]>(baseUrl +'api/Customer/List', { headers: this.headers }).subscribe(result => {
      this.customers = result;
    }, error => console.error(error));
  }
  
}

interface Customers {
  id: string;
  account_balance: string;
  created: string;
  currency: string;
  description: string;
  discount: string;
  email: string;
  shipping: string;
  subscriptions: string;
  tax_info: string;
}
