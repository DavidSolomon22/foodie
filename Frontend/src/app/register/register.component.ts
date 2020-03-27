import { Component, OnInit, ElementRef } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  constructor(private elementRef: ElementRef) {}
  ngAfterViewInit(): void {
    //Called after ngAfterContentInit when the component's view has been initialized. Applies to components only.
    //Add 'implements AfterViewInit' to the class.
    this.elementRef.nativeElement.ownerDocument.body.style.backgroundColor =
      '#ECDCB0';
  }

  ngOnInit() {}
}
