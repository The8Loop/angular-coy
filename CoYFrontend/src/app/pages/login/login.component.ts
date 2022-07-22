import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { catchError, map, throwError } from 'rxjs';
import { UserLogin } from 'src/app/model/user.interface';
import { LoginService } from 'src/app/services/login.service';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'coy-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  usernameFormControl = new FormControl("");
  passwordFormControl = new FormControl("");

  sessionIdentier = "";
  displayError = false;

  constructor(private usersService: UsersService, public loginService: LoginService) { }

  onInput() {
    if (this.passwordFormControl.value != "") {
      const userLogin: UserLogin = {
        name: this.usernameFormControl.value,
        password: this.passwordFormControl.value
      }

      this.usersService.getUserLogin(userLogin)
        .pipe(
          catchError(error => {
            if (error.status === 401) {
              this.displayError = true;
            }
            return throwError(() => new Error('Invalid Login'));
          })
        )
        .subscribe(session => {
          this.loginService.createSession(session.sessionString);
          this.loginService.loggedIn = true;
          this.displayError = false;
        });
    }
    else {
      this.displayError = false;
    }
  }
}
