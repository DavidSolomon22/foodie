import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-recipe-card',
  templateUrl: './recipe-card.component.html',
  styleUrls: ['./recipe-card.component.scss']
})
export class RecipeCardComponent {
  @Input() recipe: any;

  complexityLevels = [
    {
      key: 1,
      value: "Beginner"
    },
    {
      key: 2,
      value: "Intermediate"
    },
    {
      key: 3,
      value: "Advanced"
    }
  ]

  formatComplexityLevel(value) {
    return this.complexityLevels.find((level) => {
      return level.key == value;
    }).value;
  }
}
