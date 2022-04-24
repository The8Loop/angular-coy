import { Component, Input } from '@angular/core';
import { UserContribution } from 'src/app/model/user.interface';

@Component({
  selector: 'coy-financial-list',
  templateUrl: './financial-list.component.html',
  styleUrls: ['./financial-list.component.scss']
})
export class FinancialListComponent {

  // usersList: UserCont[] = [{ name: 'Thorak Icestorm', contributions: [100, 500, 700] },
  // { name: 'Zia Mordrem', contributions: [100] }, { name: 'Zia Mordrem', contributions: [100] },
  // { name: 'Zia Mordrem', contributions: [100] }];

  /**
   * Input list of users and their contributions to create a spreadsheet of users and thir contributions.
   */
  @Input() usersList: UserContribution[] = [];

  constructor() { }

  userTotal(user: UserContribution): number {
    let total: number = 0;
    if (user.contributions.length != 0) {
      total = user.contributions.reduce((a, b) => a + b);
    }
    return total;
  }
}
