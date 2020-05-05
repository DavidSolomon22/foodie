import { DietService } from './../../../services/diet.service';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-diet-card',
  templateUrl: './diet-card.component.html',
  styleUrls: ['./diet-card.component.scss'],
})
export class DietCardComponent {
  nameRecipe = '';
  nameRecipe2 = '';
  nameRecipe3 = '';
  constructor(private service: DietService) {}
  counter = 0;
  ctr2 = 0;
  ctr3 = 0;
  @Input() meal: any;

  recipe(id: string) {
    if (this.counter == 0) {
      this.service.getRecipe(id).subscribe((resp) => {
        console.log(resp.name);
        this.counter = 1;
        this.nameRecipe = resp.name;
      });
    }
  }
  recipe2(id: string) {
    if (this.ctr2 == 0) {
      this.service.getRecipe(id).subscribe((resp) => {
        console.log(resp.name);
        this.ctr2 = 1;
        this.nameRecipe2 = resp.name;
      });
    }
  }
  recipe3(id: string) {
    if (this.ctr3 == 0) {
      this.service.getRecipe(id).subscribe((resp) => {
        console.log(resp.name);
        this.ctr3 = 1;
        this.nameRecipe3 = resp.name;
      });
    }
  }
  delete() {
    
  }
}
