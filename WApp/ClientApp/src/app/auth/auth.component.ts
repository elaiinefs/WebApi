import { Component, OnInit, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Params, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent implements OnInit {
  private headers: HttpHeaders;
  private code: string;
  public message: any;
  private stripeParams = {
    UserId: undefined,
    client_secret: "",
    code: "",
    grant_type: "",
    scope: "",
    amount: "",
    currency: "",
    application_fee_amount: ""
  }

  constructor(private http: HttpClient, private route: ActivatedRoute) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  }

  ngOnInit() {
    this.route.queryParams.forEach((params: Params) => {
      //this.client_secret = params['client_secret']; //"sk_test_j4RHbsHVOtrzWJVQv0QnoRYS00vyAUZ4j2";
      this.code = params['code'];
      //this.grant_type = params['grant_type'];// "authorization_code";
    });
    this.stripeParams = {
      UserId: undefined,
      client_secret: "",
      code: this.code,
      grant_type: "",
      scope: "",
      amount: "",
      currency: "",
      application_fee_amount: ""
    }
    return this.http.post('api/Connect/ConnectWithStripe', this.stripeParams, { headers: this.headers })
      .subscribe((res: Response) => {
        // you can assign the value to any variable here
      });
  }

}
