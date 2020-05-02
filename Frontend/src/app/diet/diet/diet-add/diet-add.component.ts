import { DietService } from './../../../services/diet.service';
import { Component, OnInit } from '@angular/core';
import { Recipie } from 'src/app/shared/models';
import { MatDialog } from '@angular/material/dialog';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-diet-add',
  templateUrl: './diet-add.component.html',
  styleUrls: ['./diet-add.component.scss'],
})
export class DietAddComponent implements OnInit {
  recipes;
  form: FormGroup;
  constructor(
    private service: DietService,
    public dialog: MatDialog,
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
    console.log(this.form.value);
    console.log(this.form.controls.firstmeal);
    this.dialog.closeAll();
  }
}
