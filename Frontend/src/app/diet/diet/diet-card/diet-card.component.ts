import { DailyDiet } from './../../../shared/models';
import { DietService } from './../../../services/diet.service';
import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-diet-card',
  templateUrl: './diet-card.component.html',
  styleUrls: ['./diet-card.component.scss'],
})
export class DietCardComponent {
  nameRecipe = '';
  nameRecipe2 = '';
  nameRecipe3 = '';
  constructor(private service: DietService, public router: Router) {}
  counter = 0;
  ctr2 = 0;
  ctr3 = 0;
  @Input() meal: DailyDiet;

  one(dailydiet) {
    var temp = dailydiet as DailyDiet;
    var recipeid = temp.meals[0].recipeId;
    return this.recipe(recipeid);
  }
  two(dailydiet) {
    var temp = dailydiet as DailyDiet;
    var recipeid = temp.meals[1].recipeId;
    return this.recipe2(recipeid);
  }
  third(dailydiet) {
    var temp = dailydiet as DailyDiet;
    if (temp.meals[2] != undefined) {
      var recipeid = temp.meals[2].recipeId;
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
  goToRecipeBreakfast() {
    var link = 'recipe/' + this.meal.meals[0].recipeId;
    this.router.navigateByUrl(link);
  }
  goToRecipeLunch() {
    var link = 'recipe/' + this.meal.meals[1].recipeId;
    this.router.navigateByUrl(link);
  }
  goToRecipeSupper() {
    var link = 'recipe/' + this.meal.meals[2].recipeId;
    this.router.navigateByUrl(link);
  }
}
