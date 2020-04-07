import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { RegisterService } from '../services/register.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { group } from '@angular/animations';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css'],
})
export class UserProfileComponent implements OnInit {
  form: FormGroup;
  formPass: FormGroup;
  userData;
  show = false;
  submitted = false;
  differentPass = true;
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private registerService: RegisterService,
    private snack: MatSnackBar
  ) {
    this.form = this.fb.group({
      firstname: ['', Validators.required],
      surname: ['', Validators.required],
    });
    this.formPass = this.fb.group(
      {
        oldPassword: ['', Validators.required],
        newPassword: [
          '',
          Validators.compose([
            Validators.required,
            Validators.minLength(8),
            Validators.pattern(/\d/),
          ]),
        ],
      },
      { validator: this.checkPasswords }
    );
  }

  ngOnInit() {
    this.registerService.getUser().subscribe((resp) => {
      this.userData = resp;
      this.form.patchValue({
        firstname: this.userData.firstName,
        surname: this.userData.surname,
      });
    });
  }
  get f() {
    return this.formPass.controls;
  }
  checkPasswords(group: FormGroup) {
    // here we have the 'passwords' group
    let pass = group.get('oldPassword').value;
    let newPass = group.get('newPassword').value;

    return pass !== newPass ? null : { differentPass: true };
  }
  onSubmit() {
    this.submitted = true;
    if (this.show == true) {
      if (this.formPass.invalid) {
      } else {
        console.log(this.formPass.value);
        this.registerService.newPassword(this.formPass).subscribe(
          (resp) => {
            this.snack.open('Successfully changed', '', {
              duration: 2000,
              panelClass: ['snackbar'],
              verticalPosition: 'top',
            });
          },
          (error) => {}
        );
      }
    } else {
      let fo = this.form.value;
      this.registerService.updateUser(fo).subscribe((resp) => {
        this.snack.open('Successfully changed', '', {
          duration: 2000,
          panelClass: ['snackbar'],
          verticalPosition: 'top',
        });
      });
    }
  }
  showPassword() {
    if (this.show == true) {
      this.show = false;
    } else {
      this.show = true;
    }
  }

  logOut() {
    this.registerService.logOut();
    this.router.navigateByUrl('home');
  }
}
