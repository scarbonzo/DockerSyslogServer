import { Component, Input, OnInit, OnChanges } from '@angular/core';
import { SyslogService } from '../syslog.service';
import 'rxjs/add/operator/map';

@Component({
  selector: 'app-syslogviewer',
  templateUrl: './syslogviewer.component.html',
  styleUrls: ['./syslogviewer.component.css']
})
export class SyslogviewerComponent implements OnInit, OnChanges {
  syslogs = [];
  sources = [];
  selectedSource = '-1';
  resultSize = 100;
  start: Date = new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDate(), 0, 0, 0);
  end: Date = new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDate(), 23, 59, 59);
  en: any;

  constructor(private _syslogService: SyslogService) { }

  ngOnInit() {
    this._syslogService.getSources()
    .subscribe(resUserData => this.sources = resUserData);

    this.en = {
      firstDayOfWeek: 0,
      dayNames: ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'],
      dayNamesShort: ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'],
      monthNames: [ 'January', 'February', 'March', 'April', 'May', 'June',
                     'July', 'August', 'September', 'October', 'November', 'December' ],
      monthNamesShort: [ 'Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec' ]
    };
  }

  ngOnChanges() {
  }

  update() {
    this._syslogService.getSyslogs(this.selectedSource, this.start.toJSON(), this.end.toJSON(), this.resultSize)
      .subscribe(resUserData => this.syslogs = resUserData);
  }
}

