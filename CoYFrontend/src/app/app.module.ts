import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CreateComponent } from './pages/create/create.component';
import { ListComponent } from './pages/list/list.component';
import { InputIntComponent } from './shared/input-int/input-int.component';
import { DropdownComponent } from './shared/dropdown/dropdown.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FinancialListComponent } from './shared/financial-list/financial-list.component';
import { APP_BASE_HREF } from '@angular/common';
import { HomeComponent } from './pages/home/home.component';
import { ContributionMainComponent } from './pages/contribution-main/contribution-main.component';
import { ContributionDetailsComponent } from './pages/contribution-details/contribution-details.component';
import { PlayerListComponent } from './shared/player-list/player-list.component';
import { PlayerStatementComponent } from './shared/player-statement/player-statement.component';
import { LoginComponent } from './pages/login/login.component';
import { SignupComponent } from './pages/signup/signup.component';
import { ContributionFormComponent } from './shared/contribution-form/contribution-form.component';

@NgModule({
  declarations: [
    AppComponent,
    ListComponent,
    CreateComponent,
    InputIntComponent,
    DropdownComponent,
    FinancialListComponent,
    HomeComponent,
    ContributionMainComponent,
    ContributionDetailsComponent,
    PlayerListComponent,
    PlayerStatementComponent,
    LoginComponent,
    SignupComponent,
    ContributionFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [{ provide: APP_BASE_HREF, useValue: '/' }],
  bootstrap: [AppComponent]
})
export class AppModule { }
