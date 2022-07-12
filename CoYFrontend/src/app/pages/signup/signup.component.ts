import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'coy-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {
  usernameFormControl = new FormControl("");
  passwordFormControl = new FormControl("");
  confirmFormControl = new FormControl("");
  passwordTypo = false;

  constructor() { }

  ngOnInit(): void {
  }

  onInput() {
    if (this.confirmFormControl.value != "") {
      if (this.passwordFormControl.value != this.confirmFormControl.value) {
        this.passwordTypo = true;
      }
      else {
        this.passwordTypo = false;
      }
    }
  }


}
