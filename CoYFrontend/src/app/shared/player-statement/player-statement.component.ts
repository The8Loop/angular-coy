import { Component, Input } from '@angular/core';
import { TotalSP } from 'src/app/model/money.interface';
import { UserContribution } from 'src/app/model/user.interface';

@Component({
  selector: 'coy-player-statement',
  templateUrl: './player-statement.component.html',
  styleUrls: ['./player-statement.component.scss']
})
export class PlayerStatementComponent {

  @Input() totalSP: TotalSP | null = null;
  @Input() user: UserContribution | null = null;

  ColorCodeCell(contributionTypeId: number): string {
    if (contributionTypeId == 1) {
      return '#4CAF50';
    }
    else if (contributionTypeId == 3) {
      return '#cd3939';
    }
    else {
      return '#AF964C';
    }
  }

  ColorCodeTotal(total: number): string {
    if (total > 0) {
      return '#4CAF50';
    }
    else if (total < 0) {
      return '#cd3939';
    }
    return 'white';
  }
}