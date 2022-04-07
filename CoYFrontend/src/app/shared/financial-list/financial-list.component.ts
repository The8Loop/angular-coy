import { Component, Input } from '@angular/core';
import { UserCont } from 'src/app/model/user.interface';

@Component({
  selector: 'coy-financial-list',
  templateUrl: './financial-list.component.html',
  styleUrls: ['./financial-list.component.scss']
})
export class FinancialListComponent {

  // usersList: UserCont[] = [{ name: 'Thorak Icestorm', contributions: [100, 500, 700] },
  // { name: 'Zia Mordrem', contributions: [100] }, { name: 'Zia Mordrem', contributions: [100] },
  // { name: 'Zia Mordrem', contributions: [100] }];

  @Input() usersList: UserCont[] = [];

  constructor() { }

  userTotal(user: UserCont): number {
    let total: number = 0;
    if (user.contributions.length != 0) {
      total = user.contributions.reduce(function (a, b) { return a + b; });
    }
    return total;
  }
}
