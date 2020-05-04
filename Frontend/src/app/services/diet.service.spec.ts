/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { DietService } from './diet.service';

describe('Service: Diet', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [DietService]
    });
  });

  it('should ...', inject([DietService], (service: DietService) => {
    expect(service).toBeTruthy();
  }));
});
