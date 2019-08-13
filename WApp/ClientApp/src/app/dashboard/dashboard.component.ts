import { Component, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {
  public ordersData: ordersByMonth;
  public customersData: Customers;
  public orderData: any;
  public salesData: any;
  public curr:string;
  private headers: HttpHeaders;

  constructor(http: HttpClient) {
    http.get<ordersByMonth>(environment.apiEndpoint + 'api/v1/Summaries/Charges', { headers: this.headers }).subscribe(result => {
      this.ordersData = result;
      this.updateOrderData(result);
      this.curr = "$";
    }, error => console.error(error));

    http.get<salesByMonth>(environment.apiEndpoint + 'api/v1/Summaries/Sales', { headers: this.headers }).subscribe(result => {
      this.updateSalesData(result);
    }, error => console.error(error));
  }
  private updateOrderData(count: ordersByMonth) {
    this.orderData = {
      labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
      fill: false,
      borderColor: "#33B4B1",
      backgroundColor: [
        "#FF6384",
        "#36A2EB",
        "#FFCE56"
      ],
      hoverBackgroundColor: [
        "#FF6384",
        "#36A2EB",
        "#FFCE56"
      ],
      datasets: [
        {
          borderColor: "#37D7DE",
          label: 'Monthly Orders',
          backgroundColor: "#3ADFE6",
          fill: false,
          hoverBackgroundColor: 
            "#37D7DE",
          data: [count.jan,
            count.feb,
            count.mar,
            count.apr,
            count.may,
            count.jun,
            count.jul,
            count.aug,
            count.sep,
            count.oct,
            count.nov,
            count.dec]
        }
      ]
    }
  }

  private updateSalesData(count: salesByMonth) {
    this.salesData = {
      labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
      datasets: [
        {
          label: 'Monthly sales',
          backgroundColor: 
            "#3BAFB3",
          hoverBackgroundColor: 
            "#36CFD5"
          ,
          data: [count.jan/100,
            count.feb / 100,
            count.mar / 100,
            count.apr / 100,
            count.may / 100,
            count.jun / 100,
            count.jul / 100,
            count.aug / 100,
            count.sep / 100,
            count.oct / 100,
            count.nov / 100,
            count.dec / 100]
        }
        //,
        //{
        //  label: 'My Second dataset',
        //  backgroundColor: [
        //    "#FF6384",
        //    "#36A2EB",
        //    "#FFCE56"
        //  ],
        //  hoverBackgroundColor: [
        //    "#FF6384",
        //    "#36A2EB",
        //    "#FFCE56"
        //  ],
        //  data: this.ordersCount
        //}
      ]
    }
  }

  ngOnInit() {
  }
  update(event: Event) {
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
interface ordersByMonth {
  jan: number;
  feb: number;
  mar: number;
  apr: number;
  may: number;
  jun: number;
  jul: number;
  aug: number;
  sep: number;
  oct: number;
  nov: number;
  dec: number;
  yearTotal: number;
  refundedTotal: number;
  totalOrders: number;
}
interface salesByMonth {
  jan: number;
  feb: number;
  mar: number;
  apr: number;
  may: number;
  jun: number;
  jul: number;
  aug: number;
  sep: number;
  oct: number;
  nov: number;
  dec: number;
}
