import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/model/user.interface';
import { HttpClient } from '@angular/common/http';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'coy-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent implements OnInit {

  users: User[] = [];
  user: User = { name: 'Choose Guild Member', id: 0 };
  contribution!: Number;

  constructor(private http: HttpClient,
    private usersService: UsersService) { }

  ngOnInit(): void {
    //Request list of users from server
    this.usersService.getAll().subscribe(users => this.users = users);
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