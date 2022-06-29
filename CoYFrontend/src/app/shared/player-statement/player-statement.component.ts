import { Component, Input, OnInit } from '@angular/core';
import { UserContribution } from 'src/app/model/user.interface';

@Component({
  selector: 'coy-player-statement',
  templateUrl: './player-statement.component.html',
  styleUrls: ['./player-statement.component.scss']
})
export class PlayerStatementComponent implements OnInit {

  @Input() user: UserContribution | null = null

  constructor() { }

  ngOnInit(): void {
  }

}
