import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'coy-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  constructor(private usersService: UsersService) { }

  ngOnInit(): void {
    this.usersService.getMoney().subscribe()
  }

}
