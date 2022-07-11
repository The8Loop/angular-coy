import { Component, Input, OnInit } from '@angular/core';
import { TotalSP } from 'src/app/model/money.interface';
import { UserContribution } from 'src/app/model/user.interface';

@Component({
  selector: 'coy-player-statement',
  templateUrl: './player-statement.component.html',
  styleUrls: ['./player-statement.component.scss']
})
export class PlayerStatementComponent implements OnInit {

  @Input() totalSP!: TotalSP;
  @Input() user!: UserContribution;

  ngOnInit(): void {
    this.user.contributions;
  }

  /**
   * Checks if the contribution type is a personal contribution or withdrawal, and color codes the cell accordingly.
   * @param contributionTypeId 
   * @returns String representing color for CSS use.
   */
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

  /**
   * Checks if the company total is positive or negative, and color codes accordingly.
   * @param total 
   * @returns String representing color for CSS use.
   */
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