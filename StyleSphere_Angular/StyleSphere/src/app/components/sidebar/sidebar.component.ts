import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiService } from 'src/app/services/api.service';
import { GlobalService } from 'src/app/services/global.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
  categories: any[] = [];

  constructor(private http: HttpClient, private apiService: ApiService, private globalService: GlobalService) {}

  ngOnInit() {
    this.apiService.getAllCategories().subscribe(response => {
      this.categories = response;
    });
  }

  navigateToCategory(categoryId: number) {
    this.apiService.getProductsByCategory(categoryId)
      .subscribe(response => {
        this.globalService.updateData(response);
      }); 
  }
}
