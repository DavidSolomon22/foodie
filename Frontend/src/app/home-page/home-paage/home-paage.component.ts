import { Component, OnInit, ElementRef } from '@angular/core';

@Component({
  selector: 'app-home-paage',
  templateUrl: './home-paage.component.html',
  styleUrls: ['./home-paage.component.css']
})
export class HomePaageComponent implements OnInit {
  constructor(private elementRef: ElementRef) {}

  ngAfterViewInit(): void {
    //Called after ngAfterContentInit when the component's view has been initialized. Applies to components only.
    //Add 'implements AfterViewInit' to the class.
    this.elementRef.nativeElement.ownerDocument.body.style.backgroundColor =
      '#ECDCB0';
  }

  ngOnInit() {}
}
