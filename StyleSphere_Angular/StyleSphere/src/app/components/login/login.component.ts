import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from '../../services/api.service';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  email: string = '';
  password: string = '';
  errorMessage: string = '';

  constructor(
    private apiService: ApiService,
    private authService:AuthService,
    private router: Router
  ) { }

  ngOnInit() {
  }

  login(): void {
    this.apiService.getCustomerLogin(this.email, this.password).subscribe((response) => {
      if (response && response.customerId) {
        localStorage.setItem('currentUser', JSON.stringify(response));
        this.authService.login();
        this.router.navigate(['/']);
      } else {
        this.errorMessage = 'Invalid email or password';
      }
    });
  }

}
