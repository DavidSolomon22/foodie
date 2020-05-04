import { DietAddComponent } from './diet-add/diet-add.component';
import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Meal } from 'src/app/shared/models';
import { ThrowStmt } from '@angular/compiler';

@Component({
  selector: 'app-diet',
  templateUrl: './diet.component.html',
  styleUrls: ['./diet.component.scss'],
})
export class DietComponent implements OnInit {
  diets = [{}];
  meals = new Array<Meal>();
  constructor(public dialog: MatDialog) {}

  ngOnInit() {}

  addDiet() {
    const dialogRef = this.dialog.open(DietAddComponent, {
      height: '25%',
      width: '60%',
      data: this.meals,
    });
    dialogRef.afterClosed().subscribe((data) => {
      this.meals.push(data);
      console.log(this.meals);
    });
  }
}
