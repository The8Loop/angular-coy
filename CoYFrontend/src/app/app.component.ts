import { Component } from '@angular/core';
import { LoginService } from './services/login.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'angular-coy';
  year: number = new Date().getFullYear();

  constructor(public loginService: LoginService) { }

  logOut() {
    this.loginService.deleteSession();
  }
}
