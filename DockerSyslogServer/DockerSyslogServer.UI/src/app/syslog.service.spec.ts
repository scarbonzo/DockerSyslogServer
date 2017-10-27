import { TestBed, inject } from '@angular/core/testing';

import { SyslogService } from './syslog.service';

describe('SyslogService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SyslogService]
    });
  });

  it('should be created', inject([SyslogService], (service: SyslogService) => {
    expect(service).toBeTruthy();
  }));
});
