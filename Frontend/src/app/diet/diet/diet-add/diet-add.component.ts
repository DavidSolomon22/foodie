import { DietService } from './../../../services/diet.service';
import { Component, OnInit } from '@angular/core';
import { Recipie, Meal } from 'src/app/shared/models';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-diet-add',
  templateUrl: './diet-add.component.html',
  styleUrls: ['./diet-add.component.scss'],
})
export class DietAddComponent implements OnInit {
  recipes;
  form: FormGroup;
  meals = new Array<Meal>();
  meal = new Meal('', '', '');
  meal2 = new Meal('', '', '');
  meal3 = new Meal('', '', '');
  constructor(
    private service: DietService,
    public dialog: MatDialogRef<DietAddComponent>,
    private fb: FormBuilder
  ) {
    this.form = fb.group({
      firstmeal: ['', Validators.required],
      secondmeal: ['', Validators.required],
      thirdmeal: ['', Validators.required],
    });
  }

  ngOnInit() {
    this.service.getAllRecipes().subscribe((resp) => {
      //console.log(resp);
      this.recipes = resp as Recipie;
      console.log(this.recipes);
    });
  }
  save() {
    this.meal.RecipeId = this.form.controls.firstmeal.value;
    this.meal.Type = 'Breakfast';
    this.meal2.RecipeId = this.form.controls.secondmeal.value;
    this.meal2.Type = 'Lunch';
    this.meal3.RecipeId = this.form.controls.thirdmeal.value;
    this.meal3.Type = 'Supper';
    this.meals.push(this.meal);
    this.meals.push(this.meal2);
    this.meals.push(this.meal3);
    this.dialog.close(this.meals);
  }
}
