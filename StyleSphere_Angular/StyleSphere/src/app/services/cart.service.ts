import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  private cart: any[] = [];

  constructor() { }

  addProduct(addedproduct:any): void {
    const cartItem = {
      productId: addedproduct.productId,
      productName: addedproduct.productName,
      price: addedproduct.price,
      selectedSize: addedproduct.selectedSize,
      selectedColor: addedproduct.selectedColor,
      quantity: addedproduct.quantity,
      productMappingId: addedproduct.productMappingId
    };    
    this.cart.push(cartItem);
    localStorage.setItem('cart', JSON.stringify(this.cart));
  }

  removeProduct(productId: number): void {
    const index = this.cart.findIndex(item => item.productId === productId);
    if (index !== -1) {
      this.cart.splice(index, 1);
      localStorage.setItem('cart', JSON.stringify(this.cart));
    }
  }

  clearCart(): void {
    this.cart = [];
    localStorage.removeItem('cart');
  }

  getCart(): any[] {
    const cartData = localStorage.getItem('cart');
    if (cartData) {
      this.cart = JSON.parse(cartData);
    }
    return this.cart;
  }

  getCartTotal(): number {
    let total = 0;
    for (const item of this.cart) {
      total += item.price * item.quantity;
    }
    return total;
  }

}
