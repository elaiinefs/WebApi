import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { PaymentComponent } from './payment/payment.component';
import { OrdersComponent } from './orders/orders.component';
import { FetchUsersComponent } from './fetch-users/fetch-users.component';
import { ManageScheduleComponent } from './manage-schedule/manage-schedule.component';
import { AuthComponent } from './auth/auth.component';
import { AuthService } from './auth.service';

import { AccordionModule } from 'primeng/accordion';     //accordion and accordion tab
import { MenuItem } from 'primeng/api';                 //api
import { MultiSelectModule } from 'primeng/multiselect';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TableModule } from 'primeng/table';
import 'chart.js/dist/Chart.min.js';
import { ChartModule } from 'primeng/chart';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { CustomerComponent } from './customer/customer.component';
import { ProductComponent } from './product/product.component';
import { ChargesComponent } from './charges/charges.component';
import { LogoutComponent } from './logout/logout.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LoaderComponent } from './loader/loader.component';
import { InvoiceComponent } from './presenters/invoice/invoice.component';
import { NgxPrintModule } from 'ngx-print';

import { Interceptor } from './services/incerceptor';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    PaymentComponent,
    OrdersComponent,
    FetchUsersComponent,
    ManageScheduleComponent,
    AuthComponent,
    CustomerComponent,
    ProductComponent,
    ChargesComponent,
    LogoutComponent,
    DashboardComponent,
    LoaderComponent,
    InvoiceComponent
  ],
  imports: [
    BrowserModule,
    MultiSelectModule,
    BrowserAnimationsModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AccordionModule,
    TableModule,
    ChartModule,
    ToastModule,
    NgxPrintModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'orders', component: OrdersComponent },
      { path: 'fetch-users', component: FetchUsersComponent },
      { path: 'authorize', component: AuthComponent },
      { path: 'customer', component: CustomerComponent },
      { path: 'charges', component: ChargesComponent },
      { path: 'logout', component: LogoutComponent },
      { path: 'dashboard', component: DashboardComponent}
    ])
  ],
  providers: [AuthService, MessageService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: Interceptor,
      multi: true
    }],
  bootstrap: [AppComponent]
})
export class AppModule { }
