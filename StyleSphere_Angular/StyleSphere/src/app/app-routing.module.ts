import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductDetailsComponent } from './components/product-details/product-details.component';
import { LoginComponent } from './components/login/login.component';
import { CheckoutComponent } from './components/checkout/checkout.component';
import { AppComponent } from './app.component';
import { ProductCardsComponent } from './components/product-cards/product-cards.component';
import { AppContainerComponent } from './components/app-container/app-container.component';
import { ViewCartComponent } from './components/view-cart/view-cart.component';
import { RegisterComponent } from './components/register/register.component';
import { OrderListComponent } from './components/order-list/order-list.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: ProductCardsComponent },
  { path: 'cart', component: ViewCartComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'product-details/:id', component: ProductDetailsComponent },
  { path: 'login', component: LoginComponent },
  { path: 'orderlist', component:OrderListComponent},
  {path:'checkout', component:CheckoutComponent}  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
