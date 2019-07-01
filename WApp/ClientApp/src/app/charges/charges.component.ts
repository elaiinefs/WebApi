import { Component, Inject, EventEmitter, Output } from "@angular/core";
import { HttpClient, HttpResponse } from '@angular/common/http';
import { MessageService } from "primeng/api";

@Component({
  selector: 'app-charges',
  templateUrl: './charges.component.html',
  styleUrls: ['./charges.component.css']
})
export class ChargesComponent {
  public orders: Order[];
  public refund: RefundInfo;
  constructor(private http: HttpClient,@Inject('BASE_URL') private baseUrl: string, private messageService: MessageService) {
    http.get<Order[]>(baseUrl + 'api/Order/List').subscribe(result => {
      console.error(result);
      this.orders = result;
    }, error => console.error(error));
  }

  ngOnInit() {
  }
  showConfirm(orderId, amount) {
    this.messageService.clear();
    this.refund = {
      chargeId : orderId,
      amount : amount,
      businessEmail: localStorage.getItem("user_email"),
      reason : ""
    }

    this.messageService.add({ key: 'custom', sticky: true, severity: 'warn', summary: "Are you sure you want to complete a refund of " + (amount/100), detail: "Order Number: " + orderId +'. Confirm to proceed.' });
  }

  public async refundOrder(orderId, amount, @Inject('BASE_URL') baseUrl: string, http: HttpClient) {
    await http.post(baseUrl + 'api/Order/Refund', this.refund)
      .subscribe(
      res => {
        this.showSuccess(res);
      }, error => {
        this.showError(error);
      }
      );
  }
  public async refundingOrder() {

    await this.http.post(this.baseUrl + 'api/Order/Refund', this.refund )
      .subscribe(
        res => {
        }, error => console.error(error));
  }

  private showSuccess(res) {
    this.messageService.add({ severity: 'success', summary: res.status, detail: res.message});
  }
  
  private showError(error) {
    this.messageService.add({ severity: 'error', summary: error.status, detail: error.message });
  }
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
  refunds:object;
}
interface RefundInfo {
  chargeId: string;
  businessEmail: string;
  amount: number;
  reason: string;
}
