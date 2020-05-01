import { DietService } from './../../../services/diet.service';
import { Component, OnInit } from '@angular/core';
import { Recipie } from 'src/app/shared/models';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-diet-add',
  templateUrl: './diet-add.component.html',
  styleUrls: ['./diet-add.component.css'],
})
export class DietAddComponent implements OnInit {
  recipes;
  constructor(private service: DietService, public dialog: MatDialog) {}

  ngOnInit() {
    this.service.getAllRecipes().subscribe((resp) => {
      //console.log(resp);
      this.recipes = resp as Recipie;
      console.log(this.recipes);
    });
  }
  save() {
    this.dialog.closeAll();
  }
}
