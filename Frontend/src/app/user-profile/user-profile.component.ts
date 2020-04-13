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
  url: string;
  file = undefined;
  imageToSee;
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
        firstname: ['', Validators.required],
        surname: ['', Validators.required],
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
    this.registerService.getUserphoto().subscribe((response) => {});
  }
  get f() {
    return this.formPass.controls;
  }
  createImagefromBlob(img: Blob) {
    let reader = new FileReader();
  }
  checkPasswords(group: FormGroup) {
    // here we have the 'passwords' group
    let pass = group.get('oldPassword').value;
    let newPass = group.get('newPassword').value;

    return pass !== newPass ? null : { differentPass: true };
  }

  onSelectFile(event) {
    const self = this;
    if (event.target.files && event.target.files[0]) {
      var reader = new FileReader();
      this.file = event.target.files[0];
      if (this.checkFileType(this.file.type)) {
        this.registerService.postUserPhoto(this.file).subscribe((resp) => {
          console.log(resp);
        });
        reader.readAsDataURL(event.target.files[0]);
        reader.onload = (event) => {
          self.url = event.target.result.toString();
        };
      } else {
        this.snack.open(
          'File extension is wrong. Only .png or .jpg images.',
          '',
          {
            duration: 4000,
            panelClass: ['snackbar-wrong'],
            verticalPosition: 'top',
          }
        );
      }
    }
  }
  private checkFileType(fileType: string): boolean {
    const fileTypeCutted = fileType.split('/');
    if (fileTypeCutted[1] === 'png' || fileTypeCutted[1] === 'jpeg') {
      return true;
    }
    return false;
  }
  onSubmit() {
    this.submitted = true;
    let form = this.form.value;
    if (this.show === true) {
      this.formPass.patchValue({
        firstname: form.firstname,
        surname: form.surname,
      });
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
