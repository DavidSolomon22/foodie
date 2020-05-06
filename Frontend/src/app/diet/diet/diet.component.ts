import { DailyDiet } from './../../shared/models';
import { DietService } from './../../services/diet.service';
import { DietAddComponent } from './diet-add/diet-add.component';
import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Meal, Diet } from 'src/app/shared/models';
import { ThrowStmt } from '@angular/compiler';

@Component({
  selector: 'app-diet',
  templateUrl: './diet.component.html',
  styleUrls: ['./diet.component.scss'],
})
export class DietComponent implements OnInit {
  diets = [{}];
  dailyMeals = Array<Meal>();
  temp: DailyDiet[];
  constructor(public dialog: MatDialog, private service: DietService) {}

  ngOnInit() {
    let dietId = '6cf87a6a-6e83-45e4-16e4-08d7f1dc12f7';
    this.service.getDiet(dietId).subscribe((resp) => {
      var temp1 = resp as Diet;
      //onsole.log(temp.dailyDiets[0].meals[0].recipeId);
      this.temp = temp1.dailyDiets as DailyDiet[];

      console.log(this.temp);
    });
  }

  addDiet() {
    const dialogRef = this.dialog.open(DietAddComponent, {
      height: '25%',
      width: '60%',
      data: this.dailyMeals,
    });
    dialogRef.afterClosed().subscribe((data) => {
      //this.dailyMeals.push(data);
      this.temp.push(data);
      console.log(this.temp);
    });
  }
  saveDiet() {
    console.log(this.temp.length);
  }
}
