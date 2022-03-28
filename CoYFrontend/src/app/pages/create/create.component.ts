import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/model/user.interface';
import { HttpClient } from '@angular/common/http';
import { UsersService } from 'src/app/services/users.service';

//const userList: User[] = [{ userName: 'Thorak Icestorm', id: 1 },
//{ userName: 'Zia Mordrem', id: 2 }];

@Component({
  selector: 'coy-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent implements OnInit {

  users: User[] = [];
  user: User = { name: 'Choose Guild Member', id: 0 };
  userTest?: User;
  contribution!: Number;

  constructor(private http: HttpClient,
    private usersService: UsersService) { }

  ngOnInit(): void {
    this.usersService.getAll().subscribe(users => this.users = users);
    //this.http.get<User[]>('http://localhost:5041/api/User').subscribe(response => this.users = { User: response.name });
    console.log(this.users);

    //this.usersService.getUser(1).subscribe(user => this.userTest = user);
    //console.log(this.userTest);
    //this.users = userList;
    //this.http.get('http://localhost:5041/api/User/1').subscribe(response => console.log(response));
    this.http.get('http://localhost:5041/api/User').subscribe(response => console.log(response));
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