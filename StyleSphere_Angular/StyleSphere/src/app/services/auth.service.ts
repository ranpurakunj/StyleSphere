import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private isLoggedInSubject = new BehaviorSubject<boolean>(false);
  isLoggedIn$ = this.isLoggedInSubject.asObservable();

  constructor() {
    const currentUser = JSON.parse(localStorage.getItem('currentUser') || '{}');
    this.isLoggedInSubject.next(!!currentUser.customerId);
  }

  login() {
    this.isLoggedInSubject.next(true);
  }

  logout() {
    localStorage.removeItem('currentUser');
    this.isLoggedInSubject.next(false);
  }
}
