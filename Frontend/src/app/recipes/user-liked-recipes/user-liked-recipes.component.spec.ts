import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserLikedRecipesComponent } from './user-liked-recipes.component';

describe('UserLikedRecipesComponent', () => {
  let component: UserLikedRecipesComponent;
  let fixture: ComponentFixture<UserLikedRecipesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserLikedRecipesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserLikedRecipesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
