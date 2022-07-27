import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { UserLogin } from 'src/app/model/user.interface';
import { UsersService } from 'src/app/services/users.service';
import { catchError, throwError } from 'rxjs';

@Component({
  selector: 'coy-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent {

  usernameFormControl = new FormControl("");
  passwordFormControl = new FormControl("");
  confirmFormControl = new FormControl("");
  passwordTypo = false;
  userExists = false;

  constructor(private usersService: UsersService) { }

  onInput() {
    if (this.confirmFormControl.value != "") {
      if (this.passwordFormControl.value != this.confirmFormControl.value) {
        this.passwordTypo = true;
      }
      else {
        this.passwordTypo = false;
        const user: UserLogin = {
          name: this.usernameFormControl.value,
          password: this.passwordFormControl.value
        }
        this.usersService.addUser(user)
          .pipe(
            catchError(error => {
              if (error.status === 409) {
                this.userExists = true;
              }
              return throwError(() => new Error('Something bad happened.'));
            })
          )
          .subscribe(response => {
            console.log(response);
            this.userExists = false;
          });
      }
    }
  }
}