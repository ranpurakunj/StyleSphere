import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApiService } from '../../services/api.service';
import { CartService } from '../../services/cart.service';
import { GlobalService } from '../../services/global.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {

  product: any;
  availableColors: any[] = [];
  selectedSize!: string;
  selectedColor!: string;
  quantity: number = 1;
  SuccessModal: boolean = false;

  constructor(
    private route: ActivatedRoute,
    private apiService: ApiService,
    private cartService: CartService,
    private globalService: GlobalService
  ) { }

  ngOnInit() {
    this.route.paramMap.subscribe((params) => {
      const id = Number(params.get('id'));
      this.getProductById(id);
    });
  }

  // Add a boolean variable to track whether to show the modal or not


// Add a method to show the modal when the product is added to the cart
showSuccessModal() {
  this.SuccessModal = true;
}

// Add a method to hide the modal
hideSuccessModal() {
  this.SuccessModal = false;
}


  incrementQuantity(){
    this.quantity++;
  }

  decrementQuantity(){
    if (this.quantity>1){
      this.quantity--;
    }
  }

  selectColor(color: string): void {
    this.selectedColor = color;
  }

  getProductById(id: number): void {
    this.apiService.getProductsById(id).subscribe((products) => {
      if (products && products.length > 0) {
        this.product = products[0];
        this.setAvailableColors();
        console.log(this.product);
      }
    });
  }

  setAvailableColors(): void {
    const availableMappings = this.product.mappingList.filter((mapping: any) => {
      return mapping.euSize === this.selectedSize;
    });
    const availableColors = new Set(availableMappings.map((mapping: any) => mapping.color));
    this.availableColors = Array.from(availableColors);
  }

  isSizeAvailable(size: string): boolean {
    const availableSizes = this.product.mappingList.map((mapping: any) => mapping.euSize);
    return availableSizes.includes(size);
  }

  isColorAvailable(color: string): boolean {
    const availableMappings = this.product.mappingList.filter((mapping: any) => {
      return mapping.euSize === this.selectedSize && mapping.color === color;
    });
    return availableMappings.length > 0;
  }

  addToCart(): void {
    if (!this.product) {
      return;
    }
    const selectedMapping = this.product.mappingList.find((mapping: any) => {
      return mapping.euSize === this.selectedSize && mapping.color === this.selectedColor;
    });
    if (selectedMapping) {
      const productToAdd = {
        productId: this.product.productId,
        productName: this.product.productName,
        price: this.product.price,
        selectedSize: this.selectedSize,
        selectedColor: this.selectedColor,
        quantity: this.quantity,
        productMappingId: selectedMapping.productMappingId
      };
      this.cartService.addProduct(productToAdd);
      this.globalService.updateData(productToAdd);
    }
  }

}
