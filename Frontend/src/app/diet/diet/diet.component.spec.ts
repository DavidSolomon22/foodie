/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { DietComponent } from './diet.component';

describe('DietComponent', () => {
  let component: DietComponent;
  let fixture: ComponentFixture<DietComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DietComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DietComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
