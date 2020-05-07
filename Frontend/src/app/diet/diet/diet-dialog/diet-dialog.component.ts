import { DietService } from './../../../services/diet.service';
import { group } from '@angular/animations';
import { FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { Diet } from 'src/app/shared/models';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-diet-dialog',
  templateUrl: './diet-dialog.component.html',
  styleUrls: ['./diet-dialog.component.css'],
})
export class DietDialogComponent implements OnInit {
  form = this.fb.group({
    first: 0,
    second: ['', Validators.required],
    third: ['', Validators.required],
  });
  diets = new Array<Diet>();
  constructor(
    private fb: FormBuilder,
    private service: DietService,
    public dialog: MatDialogRef<DietDialogComponent>
  ) {}

  ngOnInit() {
    this.service.getAllDiets().subscribe((resp) => {
      this.diets = resp as Diet[];
      console.log(this.diets);
    });
  }
  showDiet() {
    var temp = this.form.controls.second.value;
    console.log(this.form.value);
    this.dialog.close(this.form.value);
  }
  createDiet() {
    console.log(this.form.value);
    this.dialog.close(this.form.value);
  }
}
