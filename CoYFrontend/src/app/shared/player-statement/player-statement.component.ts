import { Component, Input } from '@angular/core';
import { UserContribution } from 'src/app/model/user.interface';

@Component({
  selector: 'coy-player-statement',
  templateUrl: './player-statement.component.html',
  styleUrls: ['./player-statement.component.scss']
})
export class PlayerStatementComponent {

  @Input() user: UserContribution | null = null

  ColorCode(contributionTypeId: number): string {
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
}