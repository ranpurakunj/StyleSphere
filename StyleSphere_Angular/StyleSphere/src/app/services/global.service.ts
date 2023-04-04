import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GlobalService {
  constructor() { }
  public productData: any = [];
  public editDataDetails: any = [];
  private messageSource = new BehaviorSubject(this.editDataDetails);
  currentMessage = this.messageSource.asObservable();

  updateData(editDataDetails: any) {
    this.editDataDetails = editDataDetails;
    this.messageSource.next(this.editDataDetails);
  }
}
