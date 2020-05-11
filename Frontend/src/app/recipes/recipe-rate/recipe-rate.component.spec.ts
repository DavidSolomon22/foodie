import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RecipeRateComponent } from './recipe-rate.component';

describe('RecipeRateComponent', () => {
  let component: RecipeRateComponent;
  let fixture: ComponentFixture<RecipeRateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RecipeRateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RecipeRateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
