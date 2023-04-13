import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';      
import { CartService } from './cart.service';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  constructor(private http:HttpClient, private cartService:CartService) { }

  rooturl:string='https://localhost:7002/api/';
  
  getAllCategories():Observable<any>{
    return this.http.get(this.rooturl+'TblCategories');
  }

  getShowOnTopCategories():Observable<any>{
    return this.http.get(this.rooturl+'TblCategories/ShowOnTop');
  }

  getCustomerLogin(email: string, password: string): Observable<any>{
    const headers = new HttpHeaders()
      .set('Content-Type', 'application/json')
      .set('accept', 'text/plain');
    const url = this.rooturl + 'TblCustomers/login';
    const params = new HttpParams()
      .set('email', email)
      .set('password', password);
    return this.http.get(url, { headers, params }).pipe(
      map((response: any) => {
        return response;
      }),
      catchError(error => {
        console.error(error);
        return throwError(error);
      })
    );
  }

  postRegisterCustomer(formData: any): Observable<any> {
    const headers = new HttpHeaders()
      .set('Content-Type', 'application/json')
      .set('accept', 'text/plain');
    const url = this.rooturl + 'TblCustomers';
    const body = {
      customerName: formData.customerName,
      email: formData.email,
      password: formData.password,
      contactNo: formData.contactNo,
      address: formData.address,
      zipCode: formData.zipCode,
      activeStatus: true
    };
    return this.http.post<any>(url, body, { headers }).pipe(
      catchError(error => {
        console.error(error);
        return throwError(error);
      })
    );
  }  

  getOrderData(id:number): Observable<any>{
    return this.http.get(this.rooturl+'TblOrderDatums/'+id);
  }

  postOrderData(orderData: any): Observable<any> {
    const headers = new HttpHeaders()
      .set('Content-Type', 'application/json')
      .set('accept', 'text/plain');

    const url = this.rooturl+'TblOrderDatum/checkout';

    return this.http.post<any>(url, orderData, { headers }).pipe(
      catchError(error => {
        console.error(error);
        return throwError(error);
      })
    );
  }

  getProducts():Observable<any>{
    return this.http.get(this.rooturl+"TblProducts").pipe(
      map((response:any)=>{
        if(response.value){
          return response.value;
        } else{
          return response;
        }
      }),
      catchError((error:any)=>{
        console.error('Error Fetching Products by Category', error);
        return throwError(error);
      })
    );
  }

  getProductsById(id:number):Observable<any>{
    return this.http.get(this.rooturl+"TblProducts/"+id).pipe(
      map((response:any)=>{
        if(response.value){
          return response.value;
        } else{
          return response;
        }
      }),
      catchError((error:any)=>{
        console.error('Error Fetching Products by Category', error);
        return throwError(error);
      })
    );
  }

  getProductsByCategory(id:number):Observable<any>{
    return this.http.get(this.rooturl+"TblProducts/ProductByCategory?id="+id).pipe(
      map((response:any)=>{
        if(response.value){
          return response.value;
        } else{
          return response;
        }
      }),
      catchError((error:any)=>{
        console.error('Error Fetching Products by Category', error);
        return throwError(error);
      })
    );
  }

  getProductsBySubCategory(id:number):Observable<any>{
    return this.http.get(this.rooturl+"TblProducts/ProductsBySubCategory?id="+id).pipe(
      map((response:any)=>{
        if(response.value){
          return response.value;
        } else{
          return response;
        }
      }),
      catchError((error:any)=>{
        console.error('Error Fetching Products by Category', error);
        return throwError(error);
      })
    );
  }

  getProductsByPrice(price:number):Observable<any>{
    return this.http.get(this.rooturl+"TblProducts/ProductUnderPrice?price="+price).pipe(
      map((response:any)=>{
        if(response.value){
          return response.value;
        } else{
          return response;
        }
      }),
      catchError((error:any)=>{
        console.error('Error Fetching Products by Category', error);
        return throwError(error);
      })
    );
  }

  searchProducts(searchText: string): Observable<any> {
    const headers = new HttpHeaders()
      .set('Content-Type', 'application/json')
      .set('accept', 'text/plain');

    const url = this.rooturl + 'TblProducts/search';

    const params = new HttpParams()
      .set('SearchText', searchText);

    return this.http.post<any>(url, null, { headers, params }).pipe(
      catchError(error => {
        console.error(error);
        return throwError(error);
      })
    );
  }

  checkoutOrder(): Observable<any> {
    const currentUser = localStorage.getItem('currentUser');
    if (!currentUser) {
      // Throw an error or return a default value
      return throwError('User not logged in');
    }
    const customerId = JSON.parse(currentUser).customerId;
    const shippingAddress = JSON.parse(currentUser).address;
    const billingAddress = JSON.parse(currentUser).address;
    const trackingId = Math.floor(Math.random() * 100000000).toString(16);
    const netAmount = this.cartService.getCartTotal();
  
    const orderDetails = this.cartService.getCart().map(item => {
      return {
        orderDetailsId: 0,
        orderId: 0,
        productMappingId: item.productMappingId,
        quantity: item.quantity,
        price: item.price,
        activeStatus: true
      };
    });
  
    const order = {
      orderId: 0,
      customerId: customerId.toString(),
      orderDate: new Date(),
      shippingAddress: shippingAddress,
      billingAddress: billingAddress,
      trackingId: trackingId,
      netAmount: netAmount,
      activeStatus: true,
      orderDetails: orderDetails
    };
  
    const headers = new HttpHeaders()
      .set('Content-Type', 'application/json')
      .set('accept', 'text/plain');
    const url = this.rooturl + 'TblOrderDatums/checkout';
    return this.http.post(url, order, { headers }).pipe(
      catchError(error => {
        console.error(error);
        return throwError(error);
      })
    );
  }

}

  

