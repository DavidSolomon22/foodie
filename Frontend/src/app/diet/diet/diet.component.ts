import { DietAddComponent } from './diet-add/diet-add.component';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-diet',
  templateUrl: './diet.component.html',
  styleUrls: ['./diet.component.scss'],
})
export class DietComponent implements OnInit {
  diets = [{}];
  constructor(public dialog: MatDialog) {}

  ngOnInit() {}

  addDiet() {
    this.dialog.open(DietAddComponent, {
      height: '25%',
      width: '60%',
    });
  }
}
