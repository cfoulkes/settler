import { TestBed } from '@angular/core/testing';

import { RandomColourService } from './random-colour.service';

describe('RandomColourService', () => {
  let service: RandomColourService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RandomColourService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
