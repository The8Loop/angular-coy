import { Component, OnInit } from '@angular/core';
import { ContributionTypeDTO, MoneyDTO, MoneyPostDTO } from 'src/app/model/money.interface';
import { User } from 'src/app/model/user.interface';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'coy-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent implements OnInit {

  userList: User[] = [];
  user: User = { name: 'Choose Guild Member', id: 0 };
  contribution = 0;
  moneyPostDTO: MoneyPostDTO = { contribution: 0, userId: 0, contributionTypeId: 0 };
  contributionTypeList: ContributionTypeDTO[] = []

  constructor(private usersService: UsersService) { }

  ngOnInit(): void {
    //Request list of users from server
    this.usersService.getAll().subscribe(users => this.userList = users);

    this.usersService.getAllContributionTypes().subscribe(contributionTypes => this.contributionTypeList = contributionTypes)
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
   * @param moneyPostDTO - Contribution of Guild Member from input field component
   */
  onSave(moneyPostDTO: MoneyPostDTO) {
    this.moneyPostDTO = moneyPostDTO;
    this.usersService.addMoneyForUser(this.moneyPostDTO).subscribe();
  }
}