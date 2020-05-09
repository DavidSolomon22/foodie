/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { DietCardComponent } from './diet-card.component';

describe('DietCardComponent', () => {
  let component: DietCardComponent;
  let fixture: ComponentFixture<DietCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DietCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DietCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
