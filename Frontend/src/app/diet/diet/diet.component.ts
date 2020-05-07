import { DietDialogComponent } from './diet-dialog/diet-dialog.component';
import { DailyDiet, Temp } from './../../shared/models';
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
  temp = new Array<DailyDiet>();
  dietId;
  editable = false;
  dietName = '';
  showDiet = false;
  constructor(public dialog: MatDialog, private service: DietService) {}

  ngOnInit() {
    const dialogInfo = this.dialog.open(DietDialogComponent, {
      height: '25%',
      width: '60%',
    });
    dialogInfo.afterClosed().subscribe((data) => {
      var result = data as Temp;
      if (result.first == '1') {
        this.dietId = result.second;
        this.service.getDiet(this.dietId).subscribe((resp) => {
          var temp1 = resp as Diet;
          this.temp = temp1.dailyDiets as DailyDiet[];
          this.dietName = temp1.name;
          this.showDiet = true;
          console.log(this.temp);
        });
      } else {
        this.editable = true;
        console.log('diet created' + result.third);
        this.dietName = result.third;
        console.log(this.dailyMeals.length);
      }
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
    var diet = new Diet();
    diet.dailyDiets = this.temp;
    diet.name = this.dietName;
    var user = localStorage.getItem('user_id');
    diet.creatorId = user;
    diet.description = 'sdsdsdsdsd';
    console.log(diet);
    this.service.postDiet(diet).subscribe((resp) => {
      console.log(resp);
    });
  }
}
