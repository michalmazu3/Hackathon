import { TestBed, inject } from '@angular/core/testing';

import { GreenFieldsService } from './green-fields.service';

describe('GreenFieldsService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [GreenFieldsService]
    });
  });

  it('should be created', inject([GreenFieldsService], (service: GreenFieldsService) => {
    expect(service).toBeTruthy();
  }));
});
