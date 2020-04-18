import { Component, AfterViewInit, ViewChild, ElementRef } from '@angular/core';

@Component({
  selector: 'app-waves',
  templateUrl: './waves.component.html',
  styleUrls: ['./waves.component.scss']
})
export class WavesComponent implements AfterViewInit {
  @ViewChild('canvas') canvas: ElementRef;

  constructor() { }

  /**
   * Calculate Y from a math function y = a * x^2 + b * x + c
   * @param a 
   * @param b 
   * @param c 
   * @param x
   */
  _getY(a, b, c, x) {
    let y = a * Math.pow(x, 2) + b * x + c;
    return y;
  }

  _getRandomInt(min, max) {
    return Math.ceil(Math.random() * (max - min) + min);
  }

  ngAfterViewInit(): void {
    // let canvas = this.canvas.nativeElement;
    // let ctx = canvas.getContext('2d');

    // let currentX = 0;

    // setInterval(() => {
    //   currentX++;
    //   if(currentX >= 400) {
    //     currentX = 0;
    //   }

    //   let y = Math.ceil(Math.sin(currentX / this._getRandomInt(1, 10)) * this._getRandomInt(50, 500));     
    //   ctx.clearRect(currentX, 0, 1, canvas.height);
    //   ctx.lineTo(currentX, y);
    //   ctx.stroke();
    //   ctx.moveTo(currentX, y);
    // }, 17);
  } 

}
