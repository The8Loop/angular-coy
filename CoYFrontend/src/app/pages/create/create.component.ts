import { Component, OnInit } from '@angular/core';
import { MoneyDTO } from 'src/app/model/money.interface';
import { User } from 'src/app/model/user.interface';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'coy-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent implements OnInit {

  users: User[] = [];
  user: User = { name: 'Choose Guild Member', id: 0 };
  contribution: number = 0;
  moneyDTO: MoneyDTO = { contribution: 0, userId: 0 };

  constructor(private usersService: UsersService) { }

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
   * Sets property contribution to input from input field component
   * Sets values of moneyDTO and posts to the server
   * @param userContribution - Contribution of Guild Member from input field component
   */
  onSave(userContribution: number): void {
    this.contribution = userContribution;
    this.moneyDTO = { contribution: this.contribution, userId: this.user.id };
    this.usersService.addMoneyForUser(this.moneyDTO).subscribe(moneyDTO => moneyDTO = this.moneyDTO);
  }
}