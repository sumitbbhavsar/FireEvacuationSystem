import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';

import { AppComponent } from './app.component';
import { HelloComponent } from './hello.component';
import { GoogleChartsModule } from 'angular-google-charts';
import {CommonService} from './service/common.service';

@NgModule({
  imports:      [ BrowserModule, FormsModule, GoogleChartsModule,HttpClientModule ],
  declarations: [ AppComponent, HelloComponent ],
  bootstrap:    [ AppComponent ],
  providers: [CommonService]
})
export class AppModule { }
