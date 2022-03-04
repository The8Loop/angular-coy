import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/model/user.interface';
import { HttpClient } from '@angular/common/http';

const userList: User[] = [{ userName: 'Thorak Icestorm', id: 1 },
{ userName: 'Zia Mordrem', id: 2 }];

@Component({
  selector: 'coy-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent implements OnInit {

  users: User[] = [];
  user: User = { userName: 'Choose Guild Member', id: 0 };
  contribution!: Number;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.users = userList;
    this.http.get('http://localhost:5041/WeatherForecast').subscribe(response => console.log(response));
  }

  /**
   * Sets property user to input from dropdown component
   * @param user - Selected user from dropdown menu
   */
  onSelected(user: User): void {
    this.user = user;
  }

  /**
   * Set property contribution to input from input field component
   * @param userContribution - Contribution of Guild Member from input field component
   */
  onSave(userContribution: Number): void {
    this.contribution = userContribution;
  }
}