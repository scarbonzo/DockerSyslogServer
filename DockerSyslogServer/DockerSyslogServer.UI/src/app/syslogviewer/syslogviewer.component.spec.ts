import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SyslogviewerComponent } from './syslogviewer.component';

describe('SyslogviewerComponent', () => {
  let component: SyslogviewerComponent;
  let fixture: ComponentFixture<SyslogviewerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SyslogviewerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SyslogviewerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
