import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DataService {
  private dayToRemove = new BehaviorSubject('test');
  currentMessage = this.dayToRemove.asObservable();
  constructor() {}

  newMessage(message: string) {
    this.dayToRemove.next(message);
  }
}
