import { Component, OnInit } from '@angular/core';
import { CartService } from '../../services/cart.service';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-view-cart',
  templateUrl: './view-cart.component.html',
  styleUrls: ['./view-cart.component.scss']
})
export class ViewCartComponent implements OnInit {

  cartItems: any[] = [];
  cartTotal: number = 0;

  constructor(private cartService: CartService, private apiService:ApiService) { }

  ngOnInit() {
    this.getCartItems();
    this.getCartTotal();
  }

  getCartItems(): void {
    this.cartItems = this.cartService.getCart();
  }

  getCartTotal(): void {
    this.cartTotal = this.cartService.getCartTotal();
  }

  removeCartItem(productId: number): void {
    this.cartService.removeProduct(productId);
    this.getCartItems();
    this.getCartTotal();
  }

  checkout(): void {
    // const currentUser = JSON.parse(localStorage.getItem('currentUser') || '');
    // const order = {
    //   orderId: 0,
    //   customerId: currentUser.customerId,
    //   orderDate: new Date().toISOString(),
    //   shippingAddress: currentUser.address,
    //   billingAddress: currentUser.address,
    //   trackingId: Math.floor(Math.random() * 100000000).toString(16),
    //   netAmount: this.cartTotal,
    //   activeStatus: true,
    //   orderDetails: this.cartItems.map(item => ({
    //     orderDetailsId: 0,
    //     orderId: 0,
    //     productMappingId: item.productMappingId,
    //     quantity: item.quantity,
    //     price: item.price,
    //     activeStatus: true
    //   }))
    // };
    this.apiService.checkoutOrder().subscribe(() => {
      this.cartService.clearCart();
      this.getCartItems();
      this.getCartTotal();
      alert('Order placed successfully');
    }, (error: any) => {
      console.error(error);
      alert('Error occurred while placing order');
    });
  }

}