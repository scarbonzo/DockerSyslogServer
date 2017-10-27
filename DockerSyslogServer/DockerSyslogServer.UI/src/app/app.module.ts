import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { SyslogviewerComponent } from './syslogviewer/syslogviewer.component';

import { SyslogService } from './syslog.service';
import { DateTimePickerModule } from 'ng-pick-datetime';
import { format } from 'date-fns';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    SyslogviewerComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpModule,
    DateTimePickerModule
  ],
  providers: [
    SyslogService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
