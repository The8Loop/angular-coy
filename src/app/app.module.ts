import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CreateComponent } from './pages/create/create.component';
import { ListComponent } from './pages/list/list.component';
import { InputIntComponent } from './shared/input-int/input-int.component';
import { DropdownComponent } from './shared/dropdown/dropdown.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    ListComponent,
    CreateComponent,
    InputIntComponent,
    DropdownComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
