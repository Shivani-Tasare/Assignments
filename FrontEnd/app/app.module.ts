import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SearchBodyComponent } from './search-body/search-body.component';
import { ResultsBodyComponent } from './results-body/results-body.component';
//import { NavBarComponent } from './nav-bar/nav-bar.component';
import { HeadNavComponent } from './head-nav/head-nav.component';
import { ClientService } from './client.service';
import { FormsModule } from '@angular/forms'; 
import { HttpClientModule} from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    SearchBodyComponent,
    ResultsBodyComponent,
    
    HeadNavComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule 
  ],
  providers: [ClientService],
  bootstrap: [AppComponent]
})
export class AppModule { }
