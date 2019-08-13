import { Component, Inject } from "@angular/core";
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent{
  public customers: Customers[];

  constructor(http: HttpClient) {

    http.get<Customers[]>(environment.apiEndpoint +'api/v1/Customers/List').subscribe(result => {
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
