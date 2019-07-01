import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
//import { TableModule } from 'primeng/table';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent{
  public orders: Orders[];
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Orders[]>(baseUrl + 'api/Order/GetOrders').subscribe(result => {
      this.orders = result;
    }, error => console.error(error));
  }

  ngOnInit() {

  }
  
}

  interface Orders {
  orderNumber: string;
  createdDate: string;
  createdBy: string;
  orderTotal: string;
  taxAmount: string;
  taxAmount2: string;
  customer: string;
  status: string;
}
