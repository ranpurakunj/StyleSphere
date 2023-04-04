import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';
import { GlobalService } from 'src/app/services/global.service';

@Component({
  selector: 'app-top-buttons',
  templateUrl: './top-buttons.component.html',
  styleUrls: ['./top-buttons.component.scss']
})
export class TopButtonsComponent implements OnInit {

  categories:any[]=[];

  constructor( private apiService:ApiService, private globalService:GlobalService, private router:Router){}
  ngOnInit() {
    this.apiService.getAllCategories().subscribe(response => {
      this.categories = response;
    });
  }

  navigateToProductbyCategory(categoryId: number) {
    this.router.navigate(['/'], { queryParams: { category: categoryId } })
      .then(() => {
        this.apiService.getProductsByCategory(categoryId)
          .subscribe(response => {
            this.globalService.updateData(response);
          });
      });
  }

  navigateToProductbyPrice(price: number) {
    this.router.navigate(['/home']).then(() => {
      this.apiService.getProductsByPrice(price)
      .subscribe(response => {
        this.globalService.updateData(response);
      });
    });
  }

  navigateToAllProduct() {
    this.router.navigate(['/home']).then(() => {
    this.apiService.getProducts()
      .subscribe(response => {
        this.globalService.updateData(response);
      });
    });
  }

}
