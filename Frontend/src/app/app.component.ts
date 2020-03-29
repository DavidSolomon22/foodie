import {
  Component,
  AfterViewInit,
  ElementRef,
  HostListener
} from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements AfterViewInit {
  @HostListener('window:beforeunload', ['$event'])
  clearLocalStorage(event) {
    localStorage.clear();
  }
  constructor(private elementRef: ElementRef) {}

  ngAfterViewInit(): void {
    this.elementRef.nativeElement.ownerDocument.body.style.backgroundColor =
      '#ECDCB0';
  }
  title = 'foodie';
}
