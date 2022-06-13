import { TestBed } from '@angular/core/testing';

import { LodestoneService } from './lodestone.service';

describe('LodestoneService', () => {
  let service: LodestoneService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LodestoneService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
