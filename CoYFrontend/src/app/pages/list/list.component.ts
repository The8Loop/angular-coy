import { Component, OnInit } from '@angular/core';
import { UsersService } from 'src/app/services/users.service';
import { UserContribution } from 'src/app/model/user.interface';

@Component({
  selector: 'coy-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  usersContribution: UserContribution[] = [];

  constructor(private usersService: UsersService) { }

  ngOnInit(): void {
    this.usersService.getMoney().subscribe(usersCont => this.usersContribution = usersCont);
  }

}
