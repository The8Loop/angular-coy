import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, throwError } from 'rxjs';
import { ContributionTypeDTO, MoneyDTO, MoneyPostDTO } from 'src/app/model/money.interface';
import { User } from 'src/app/model/user.interface';
import { LoginService } from 'src/app/services/login.service';
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
  contributionTypeList: ContributionTypeDTO[] = [];
  displayError = false;

  constructor(private usersService: UsersService, private loginService: LoginService, private router: Router) { }

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
    const sessionIdentfier = this.loginService.getSession();
    if (sessionIdentfier == null) {
      return;
    }
    this.moneyPostDTO = moneyPostDTO;
    this.usersService.addMoneyForUser(this.moneyPostDTO, sessionIdentfier)
      .pipe(
        catchError(error => {
          if (error.status == 403) {
            this.displayError = true;
          }
          return throwError(() => new Error('Error'));
        })
      )
      .subscribe(o => {
        this.router.navigate(['/contribution']);
      });
  }
}