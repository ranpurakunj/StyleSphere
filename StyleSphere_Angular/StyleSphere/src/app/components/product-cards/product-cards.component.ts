import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';
import { GlobalService } from 'src/app/services/global.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-cards',
  templateUrl: './product-cards.component.html',
  styleUrls: ['./product-cards.component.scss']
})
export class ProductCardsComponent implements OnInit {
  products: any[] = [];
  product:any={};

  constructor(private apiService: ApiService, private globalService: GlobalService, private router:Router) {}

  ngOnInit() {
    this.globalService.currentMessage.subscribe(productData => {
      if (productData.length > 0) {
        this.products = productData;
      } else {
        this.apiService.getProducts().subscribe(response => {
          this.products = response;
        });
      }
    });
  }
  redirectToProductDetails(productId: string) {
    this.router.navigate(['/product-details', productId]);
}
}
