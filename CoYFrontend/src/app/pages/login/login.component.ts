import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { UserLogin } from 'src/app/model/user.interface';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'coy-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  usernameFormControl = new FormControl("");
  passwordFormControl = new FormControl("");

  loginCheck = false;
  displayError = false;

  constructor(private usersService: UsersService) { }

  onInput(): void {
    if (this.passwordFormControl.value != "") {
      const userLogin: UserLogin = {
        name: this.usernameFormControl.value,
        password: this.passwordFormControl.value
      }

      this.usersService.getUserLogin(userLogin)
        .subscribe(o => {
          this.loginCheck = o;
          this.displayError = !this.loginCheck;
          console.log(this.loginCheck);
        });
    }
    else {
      this.displayError = false;
    }
  }
}
