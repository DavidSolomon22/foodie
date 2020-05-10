import { Component, OnInit, Input } from '@angular/core';
import { FormControl } from '@angular/forms';
import { RecipesService } from 'src/app/services/recipesService/recipes.service';
import { ActivatedRoute } from '@angular/router';
import { Rate } from 'src/app/shared/models';
import { Subject } from 'rxjs';



@Component({
  selector: 'app-recipe-rate',
  templateUrl: './recipe-rate.component.html',
  styleUrls: ['./recipe-rate.component.scss']
})
export class RecipeRateComponent implements OnInit {

  @Input() recipeCreatorFromParent;
  recipeId = this.route.snapshot.paramMap.get('id');
  comment = new FormControl();
  recipeRate = false;
  recipeRates: Rate[] = [];
  displayedColumns = ['Rate','Comment'];
  subject = new Subject<boolean>();

  rate: Rate = {
    RecipeId: this.recipeId,
    AuthorId: '',
    Value: null,
    Comment: ''
  };

  constructor(private recipeService: RecipesService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.rate.AuthorId = this.recipeCreatorFromParent;
    this.getRecipeRates();
    this.subject.subscribe(
      (response) => {
        this.recipeRate = response;
      }
    );

  }
  rateRecipe(element) {
    const splitted = element.target.id.toString().split('r');
    const stars = document.querySelectorAll('[id^=\'star\']');

    stars.forEach((star) => {
      if(star.id === element.target.id.toString()) {
        star.classList.add('selected');
      } else {
        star.classList.remove('selected');
      }
    });

    const rate: number = +splitted[1];
    this.rate.Value = rate;
    this.subject.next(true);
  }

  getRecipeRates() {
    this.recipeService.getRecipeRates(this.recipeId).subscribe(
      response => {
        this.recipeRates = response;
      }
    );
  }

  clearComment() {
    this.comment.reset();
  }
  saveRate() {
      if ( this.comment.value !== null) {
        this.rate.Comment = this.comment.value;
      }
      this.recipeService.addRecipeRate(this.rate).subscribe(
        () => {
          this.getRecipeRates();
        }
      );
      const stars = document.querySelectorAll('[id^=\'star\']');
      stars.forEach((star) => {
        star.classList.remove('selected');
        this.clearComment();
      });
      this.subject.next(false);
    }
}
