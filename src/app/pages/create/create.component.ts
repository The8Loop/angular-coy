import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/model/user.interface';

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

  constructor() { }

  ngOnInit(): void {
    this.users = userList;
  }

  /**
   * Sets property user to input from dropdown component
   * @param user Selected user from dropdown menu
   */
  onSelected(user: User): void {
    this.user = user;
  }

  onSave(contribution: Number): void {
    this.contribution = contribution;
  }
}