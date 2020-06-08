import { DataService } from './../../services/data.service';
import { Router } from '@angular/router';
import { DietDialogComponent } from './diet-dialog/diet-dialog.component';
import { DailyDiet, Temp } from './../../shared/models';
import { DietService } from './../../services/diet.service';
import { DietAddComponent } from './diet-add/diet-add.component';
import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Meal, Diet } from 'src/app/shared/models';
import { ThrowStmt } from '@angular/compiler';
import { MatSnackBar } from '@angular/material/snack-bar';

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
  diet = new Diet();
  editD = false;
  constructor(
    public dialog: MatDialog,
    private service: DietService,
    private snack: MatSnackBar,
    private router: Router,
    private data: DataService
  ) {}

  ngOnInit() {
    const dialogInfo = this.dialog.open(DietDialogComponent, {
      height: '25%',
      width: '30%',
      disableClose: true,
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
        this.data.newMessage('edit');
        console.log('diet created' + result.third);
        this.dietName = result.third;
        this.diet.description = result.four;
        console.log(this.dailyMeals.length);
      }
    });
    this.data.currentMessage.subscribe((resp) => {
      const del = this.temp.find((t) => t.day == resp);
      const index = this.temp.indexOf(del);
      if (index !== -1) {
        this.temp.splice(index, 1);
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
      if (this.temp.find((t) => t.day == data.day)) {
        this.snack.open('Day is already on diet', '', {
          duration: 5000,
          panelClass: ['snackbar'],
          verticalPosition: 'top',
        });
      } else {
        this.temp.push(data);
        console.log(this.temp);
      }
    });
  }
  saveDiet() {
    this.diet.dailyDiets = this.temp;
    this.diet.name = this.dietName;
    var user = localStorage.getItem('user_id');
    this.diet.creatorId = user;
    console.log(this.diet);
    this.service.postDiet(this.diet).subscribe((resp) => {
      this.snack.open('Diet was created', '', {
        duration: 5000,
        panelClass: ['snackbar'],
        verticalPosition: 'top',
      });
      this.cleanBoard();
      this.ngOnInit();
    });
  }
  deleteDiet() {
    this.service.deleteDiet(this.dietId).subscribe((resp) => {
      this.cleanBoard();
      this.ngOnInit();
    });
  }
  cleanBoard() {
    this.temp = [];
    this.dietName = '';
    this.showDiet = false;
    this.editable = false;
    this.dietId = '';
    this.editD = false;
    this.data.newMessage('editStop');
  }
  openDialog() {
    this.cleanBoard();
    this.ngOnInit();
  }

  editDiet() {
    this.editD = true;
    this.data.newMessage('edit');
  }
  updateDiet() {
    this.diet.dailyDiets = this.temp;
    this.diet.name = this.dietName;
    var user = localStorage.getItem('user_id');
    this.diet.creatorId = user;
    this.service.putDiet(this.diet, this.dietId).subscribe((resp) => {
      this.snack.open('Diet was updated', '', {
        duration: 5000,
        panelClass: ['snackbar'],
        verticalPosition: 'top',
      });
      this.cleanBoard();
      this.ngOnInit();
    });
  }
}
