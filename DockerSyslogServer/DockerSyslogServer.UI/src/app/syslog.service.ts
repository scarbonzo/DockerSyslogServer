import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class SyslogService {
  private _url = 'http://syslog.api.lsnj.org:8000/api/v1/';

  constructor(private _http: Http) {}

  getSyslogs(source: string, start: string, end: string, resultsize: number) {
    return this._http.get(this._url + 'syslogs' + '?source=' + source + '&start=' + start + '&end=' + end + '&resultsize=' + resultsize)
      .map((_response: Response) => _response.json());
  }

  getSources() {
    return this._http.get(this._url + 'sources')
    .map((_response: Response) => _response.json());
  }
}
