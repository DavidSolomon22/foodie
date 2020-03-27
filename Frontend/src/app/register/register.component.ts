import { Component, OnInit, ElementRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RegisterService } from '../services/register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  form: FormGroup;
  submitted = false;
  constructor(
    private elementRef: ElementRef,
    private fb: FormBuilder,
    private registerService: RegisterService
  ) {
    this.form = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: [
        '',
        Validators.compose([
          Validators.required,
          Validators.minLength(8),
          Validators.pattern(/\d/)
        ])
      ]
    });
  }
  ngAfterViewInit(): void {
    //Called after ngAfterContentInit when the component's view has been initialized. Applies to components only.
    //Add 'implements AfterViewInit' to the class.
    this.elementRef.nativeElement.ownerDocument.body.style.backgroundColor =
      '#ECDCB0';
  }

  ngOnInit() {}

  get f() {
    return this.form.controls;
  }
  onSubmit() {
    this.submitted = true;
    const val = this.form.value;
    console.log(val);
    if (this.form.invalid) {
      console.log('form invalid');
    } else {
      console.log(val);
      this.registerService.register(val).subscribe(resp => {
        alert('Confirmation email has been sent');
      });
    }
    // if (val.email && val.password) {
    //   console.log(val);
    //   this.registerService.register(val).subscribe(resp => {
    //     console.log(resp);
    //   });
    // }
    console.log('brak mailu');
  }
}
