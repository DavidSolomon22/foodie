import { DataService } from './../../../services/data.service';
import { RecipePageComponent } from './../../../recipes/recipe-page/recipe-page.component';
import { DailyDiet } from './../../../shared/models';
import { DietService } from './../../../services/diet.service';
import { Component, OnInit, Input, Output } from '@angular/core';
import { Router } from '@angular/router';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { EventEmitter } from '@angular/core';

@Component({
  selector: 'app-diet-card',
  templateUrl: './diet-card.component.html',
  styleUrls: ['./diet-card.component.scss'],
})
export class DietCardComponent {
  nameRecipe = '';
  nameRecipe2 = '';
  nameRecipe3 = '';
  constructor(
    private service: DietService,
    public router: Router,
    public dialog: MatDialog,
    private data: DataService
  ) {}
  counter = 0;
  ctr2 = 0;
  ctr3 = 0;
  @Input() meal: DailyDiet;
  link1 = '';
  link2 = '';
  link3 = '';
  edit = false;

  ngOnInit() {
    this.data.currentMessage.subscribe((resp) => {
      if (resp == 'edit') {
        this.edit = true;
      }
      if (resp == 'editStop') {
        this.edit = false;
      }
    });
  }
  one(dailydiet) {
    var temp = dailydiet as DailyDiet;
    var recipeid = temp.meals[0].recipeId;
    this.link1 = 'http://localhost:4200/recipe/' + recipeid;
    return this.recipe(recipeid);
  }
  two(dailydiet) {
    var temp = dailydiet as DailyDiet;
    var recipeid = temp.meals[1].recipeId;
    this.link2 = 'http://localhost:4200/recipe/' + recipeid;
    return this.recipe2(recipeid);
  }
  third(dailydiet) {
    var temp = dailydiet as DailyDiet;
    if (temp.meals[2] != undefined) {
      var recipeid = temp.meals[2].recipeId;
      this.link3 = 'http://localhost:4200/recipe/' + recipeid;
      return this.recipe3(recipeid);
    } else {
      return null;
    }
  }
  recipe(id: string) {
    if (this.counter == 0) {
      this.service.getRecipe(id).subscribe((resp) => {
        this.counter = 1;
        this.nameRecipe = resp.name;
      });
    }
  }
  recipe2(id: string) {
    if (this.ctr2 == 0) {
      this.service.getRecipe(id).subscribe((resp) => {
        this.ctr2 = 1;
        this.nameRecipe2 = resp.name;
      });
    }
  }
  recipe3(id: string) {
    if (this.ctr3 == 0) {
      this.service.getRecipe(id).subscribe((resp) => {
        this.ctr3 = 1;
        this.nameRecipe3 = resp.name;
      });
    }
  }
  deleteDay() {
    this.data.newMessage(this.meal.day);
  }
}
