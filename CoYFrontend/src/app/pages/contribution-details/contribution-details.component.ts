import { Component, OnInit } from '@angular/core';
import { User, UserContribution } from 'src/app/model/user.interface';
import { UsersService } from 'src/app/services/users.service';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { Observable, switchMap } from 'rxjs';

@Component({
  selector: 'coy-contribution-details',
  templateUrl: './contribution-details.component.html',
  styleUrls: ['./contribution-details.component.scss']
})
export class ContributionDetailsComponent implements OnInit {

  // users: Users[] = [];
  user!: UserContribution;
  selectedId = 0;

  constructor(
    private usersService: UsersService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    //Request list of users from server
    //this.usersService.getAll().subscribe(users => this.users = users);
    this.route.paramMap.pipe(
      switchMap((params: ParamMap) => {
        this.selectedId = parseInt(params.get('id')!, 10);
        return this.usersService.getUser(this.selectedId);
      })
    ).subscribe(user => this.user = user);
  }


}
