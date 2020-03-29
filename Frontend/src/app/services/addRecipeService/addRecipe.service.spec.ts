/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { AddRecipeService } from './addRecipe.service';

describe('Service: Register', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AddRecipeService]
    });
  });

  it('should ...', inject([AddRecipeService], (service: AddRecipeService) => {
    expect(service).toBeTruthy();
  }));
});
