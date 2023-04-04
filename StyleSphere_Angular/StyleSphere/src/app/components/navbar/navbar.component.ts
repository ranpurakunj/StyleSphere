import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';
import { GlobalService } from 'src/app/services/global.service';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  searchText = '';
  isLoggedIn = false;

  constructor(
    private router: Router,
    private apiService: ApiService,
    private globalService: GlobalService,
    private authService: AuthService 
  ) {}

  ngOnInit() {
    this.authService.isLoggedIn$.subscribe(isLoggedIn => {
      this.isLoggedIn = isLoggedIn; 
    });
  }

  onSearch(): void {
    if (this.searchText.trim() !== '') {
      this.apiService.searchProducts(this.searchText).subscribe(
        (response: any) => {
          this.globalService.updateData(response);
        },
        (error: any) => {
          console.log(error);
        }
      );
    }
  }

  goToLogin() {
    this.router.navigate(['/login']);
  }

  goToCart() {
    this.router.navigate(['/cart']);
  }
  
  logout() {
    this.authService.logout(); // Call the logout method from the AuthService
  }
}
