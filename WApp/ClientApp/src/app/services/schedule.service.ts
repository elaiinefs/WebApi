import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { Config } from 'protractor';
import { Observable } from 'rxjs';

@Injectable()
export class ScheduleService {
  private headers: HttpHeaders;
  configUrl = 'assets/config.json';
  private currentUrl: string;
  constructor(private http: HttpClient, private router: Router, @Inject('BASE_URL') baseUrl: string) {
    this.currentUrl = baseUrl;
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  }
  getConfigResponse(): Observable<HttpResponse<Config>> {
    return this.http.get<Config>(
      this.configUrl, { observe: 'response' });
  }
  public add(payload) {
    //alert(this.accessPointUrl);
    return this.http.post(this.currentUrl +'api/SampleData/CreateService', payload, { headers: this.headers });
  }

  public pay(payload) {
    return this.http.post(this.currentUrl +'api/Payment/Pay', payload, { headers: this.headers })
      .subscribe((res: Response) => {
        //console.log(res.headers);
        // you can assign the value to any variable here
      });
  }
}
