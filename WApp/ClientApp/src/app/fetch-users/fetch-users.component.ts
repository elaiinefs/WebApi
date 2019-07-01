import { Component, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
//import { TableModule } from 'primeng/table';

@Component({
  selector: 'app-fetch-users',
  templateUrl: './fetch-users.component.html',
  styleUrls: ['./fetch-users.component.css']
})
export class FetchUsersComponent{
  public users: Users[];
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Users[]>('https://api.stripe.com/' + 'api/User/GetUsers').subscribe(result => {
      this.users = result;
    }, error => console.error(error));
  }

  ngOnInit() {
  }

}

interface Users {
  phoneNumber: string;
  email: string;
  fName: string;
  lName: string;
  modifiedDate: string;
  numberOfOrders: string;
  createdDate: string;
  status: string;
}

