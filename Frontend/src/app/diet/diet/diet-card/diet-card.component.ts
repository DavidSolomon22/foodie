import { DietService } from './../../../services/diet.service';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-diet-card',
  templateUrl: './diet-card.component.html',
  styleUrls: ['./diet-card.component.scss'],
})
export class DietCardComponent {
  nameRecipe;
  constructor(private service: DietService) {}

  @Input() meal: any;

  test(id: string) {
    this.service.getRecipe(id).subscribe((resp) => {
      console.log(resp);
    });
  }
}
