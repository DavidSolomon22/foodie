import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { RegisterService } from '../services/register.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
  form: FormGroup;
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private registerService: RegisterService,
    private snack: MatSnackBar
  ) {
    this.form = this.fb.group({
      firstname: ['', Validators.required],
      surname: ['', Validators.required]
    });
  }

  ngOnInit() {}

  onSubmit() {
    let fo = this.form.value;
    this.registerService.updateUser(fo).subscribe(resp => {
      this.snack.open('Successfully changed', '', {
        duration: 2000,
        panelClass: ['snackbar'],
        verticalPosition: 'top'
      });
    });
  }

  logOut() {
    this.registerService.logOut();
    this.router.navigateByUrl('home');
  }
}
