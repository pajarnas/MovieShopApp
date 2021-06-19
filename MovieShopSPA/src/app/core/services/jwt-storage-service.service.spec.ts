import { TestBed } from '@angular/core/testing';

import { JwtStorageServiceService } from './jwt-storage-service.service';

describe('JwtStorageServiceService', () => {
  let service: JwtStorageServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(JwtStorageServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
