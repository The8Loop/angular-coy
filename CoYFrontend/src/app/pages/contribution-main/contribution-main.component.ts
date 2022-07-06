import { Component, OnInit } from '@angular/core';
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
  totalSP: TotalSP | null = null;
  leaderboard: Leaderboard[] = [];

  constructor(private usersService: UsersService) { }

  ngOnInit(): void {
    //Request list of users from server
    this.usersService.getAll().subscribe(users => this.users = users);
    this.usersService.getCompanyTotal().subscribe(totalSP => this.totalSP = totalSP);
    this.usersService.getLeaderboard().subscribe(leaderboard => this.leaderboard = leaderboard);
  }
}
