import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];
  public products: Products[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    //http.get<WeatherForecast[]>(baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
    //  console.log(result);
    //  this.forecasts = result;

    //}, error => console.error(error));
    http.get<Products[]>(baseUrl + 'api/v1/Products/List').subscribe(result => {
      console.log(result);
      this.products = result;

    }, error => console.error(error));
  }
}
interface Products {
  Id: number;
  Sku: string;
  Title: string;
  Desc: string;
  Price: string;
  Qty: string;
  TrackInvent: string;
  Taxable: number;
  Weight: string;
  Type: string;
  Vendor: string;
  Collection: string;
  Cost: string;
  Status: string;
  Notes: string;
  PhotoId: number;
  ApplicableCouponId: string;
}
interface WeatherForecast {
  dateFormatted: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
