import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { RegisterService } from '../services/register.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
  form: FormGroup;
  constructor(
    private fb: FormBuilder,
    private registerService: RegisterService
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
      alert('Successfully changed');
    });
  }
}
