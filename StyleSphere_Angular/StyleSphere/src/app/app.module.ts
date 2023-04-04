import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { LoginComponent } from './components/login/login.component';
import { ProductCardsComponent } from './components/product-cards/product-cards.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { TopButtonsComponent } from './components/top-buttons/top-buttons.component';
import { ProductDetailsComponent } from './components/product-details/product-details.component';
import { CheckoutComponent } from './components/checkout/checkout.component';
import { AppContainerComponent } from './components/app-container/app-container.component';
import { ViewCartComponent } from './components/view-cart/view-cart.component';
import { RegisterComponent } from './components/register/register.component';
import { ApiService } from './services/api.service';
import { GlobalService } from './services/global.service';
import { CartService } from './services/cart.service';
import { AuthService } from './services/auth.service';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    LoginComponent,
    ProductCardsComponent,
    SidebarComponent,
    TopButtonsComponent,
    ProductDetailsComponent,
    RegisterComponent,
    CheckoutComponent,
    AppContainerComponent,
    ViewCartComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [
    ApiService,
    GlobalService,
    CartService,
    AuthService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
