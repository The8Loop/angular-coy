import { Component, OnInit } from '@angular/core';
import { UserCont } from 'src/app/model/user.interface';

@Component({
  selector: 'coy-financial-list',
  templateUrl: './financial-list.component.html',
  styleUrls: ['./financial-list.component.scss']
})
export class FinancialListComponent implements OnInit {

  usersList: UserCont[] = [{ name: 'Thorak Icestorm', contributions: [100, 500, 700] },
  { name: 'Zia Mordrem', contributions: [100] }, { name: 'Zia Mordrem', contributions: [100] },
  { name: 'Zia Mordrem', contributions: [100] }];

  contList: number[][] = [];

  constructor() { }

  ngOnInit(): void {

    for (var index in this.usersList) {
      this.contList[index] = this.usersList[index].contributions;
    }
    console.log(this.contList[1][1]);


  }
}
