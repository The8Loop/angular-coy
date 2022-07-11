import { Component, OnInit } from '@angular/core';
import { combineLatest } from 'rxjs';
import { TotalSP } from 'src/app/model/money.interface';
import { Leaderboard, User } from 'src/app/model/user.interface';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'coy-contribution-main',
  templateUrl: './contribution-main.component.html',
  styleUrls: ['./contribution-main.component.scss']
})
export class ContributionMainComponent implements OnInit {

  users: User[] = [];
  totalSP!: TotalSP;
  leaderboard: Leaderboard[] = [];
  isLoading = true;

  constructor(private usersService: UsersService) { }

  ngOnInit(): void {
    combineLatest({
      users: this.usersService.getAll(),
      totalSP: this.usersService.getCompanyTotal(),
      leaderboard: this.usersService.getLeaderboard()
    })
      .subscribe(el => {
        this.users = el.users;
        this.totalSP = el.totalSP;
        this.leaderboard = el.leaderboard;
        this.isLoading = false;
      })
  }
}
