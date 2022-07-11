import { Component, OnInit } from '@angular/core';
import { User, UserContribution } from 'src/app/model/user.interface';
import { UsersService } from 'src/app/services/users.service';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { combineLatest, Observable, switchMap } from 'rxjs';
import { TotalSP } from 'src/app/model/money.interface';

interface UserObj { user: UserContribution, total: TotalSP }

@Component({
  selector: 'coy-contribution-details',
  templateUrl: './contribution-details.component.html',
  styleUrls: ['./contribution-details.component.scss']
})
export class ContributionDetailsComponent implements OnInit {

  users: User[] = [];
  totalSP!: TotalSP;
  user!: UserContribution;
  isLoading = true;

  constructor(
    private usersService: UsersService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    //Request list of users from server
    this.usersService.getAll().subscribe(users => this.users = users);

    this.route.paramMap
      .pipe(
        switchMap((params: ParamMap): Observable<UserObj> => {
          const selectedId = parseInt(params.get('id')!, 10);
          return combineLatest({
            total: this.usersService.getPlayerTotal(selectedId),
            user: this.usersService.getUser(selectedId)
          });
        })
      )
      .subscribe(el => {
        this.totalSP = el.total;
        this.user = el.user;
        this.isLoading = false;
      });
  }
}
