/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { DietAddComponent } from './diet-add.component';

describe('DietAddComponent', () => {
  let component: DietAddComponent;
  let fixture: ComponentFixture<DietAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DietAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DietAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
