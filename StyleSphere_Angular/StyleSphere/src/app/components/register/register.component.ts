import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private apiService: ApiService
  ) {
    this.registerForm = this.formBuilder.group({
      customerName: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required],
      contactNo: ['', Validators.required],
      address: ['', Validators.required],
      zipCode: ['', Validators.required],
    });
  }

  ngOnInit(): void {
  }

  onSubmit(): void {
    const formData = {
      customerName: this.registerForm.value.customerName,
      email: this.registerForm.value.email,
      password: this.registerForm.value.password,
      contactNo: this.registerForm.value.contactNo,
      address: this.registerForm.value.address,
      zipCode: this.registerForm.value.zipCode,
      activeStatus: true,
    };
    this.apiService.postRegisterCustomer(formData).subscribe(
      (response) => {
        // registration successful, navigate to login page
        this.router.navigate(['/login']);
      },
      (error) => {
        console.error('Error registering customer', error);
      }
    );
  }
}
