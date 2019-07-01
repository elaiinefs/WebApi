import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { InvoiceService} from '../../services/invoice.service'

@Component({
  selector: 'invoice',
  templateUrl: './invoice.component.html',
  styleUrls: ['./invoice.component.css']
})
export class InvoiceComponent implements OnInit {
  private invoice:any;
  @Input() orderInvoiceData : any;
  constructor(private service:InvoiceService) { }

  ngOnInit() {
  }
  private displayInvoice() {
    console.log("entering to display Invoice");
    console.log(this.orderInvoiceData);
  }
  private printingInvoice(res) {
    //console.log(res);
  }
  public fillingInvoice (orderInfo: any) {
    console.log("entering to display Invoice");
    console.log(orderInfo);
  }
}
