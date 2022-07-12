import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'coy-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  usernameFormControl = new FormControl("");
  passwordFormControl = new FormControl("");

  loginFailed = false;

  constructor() { }

  ngOnInit(): void {
  }

}
