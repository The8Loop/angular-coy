import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { intValidator } from '../intValidator.directive';

@Component({
  selector: 'coy-input-int',
  templateUrl: './input-int.component.html',
  styleUrls: ['./input-int.component.scss']
})
export class InputIntComponent implements OnInit {

  contribution = new FormControl(0, intValidator());

  userContribution?: number;

  constructor() { }

  ngOnInit(): void {
  }

  clickEvent() {

    this.userContribution = this.contribution.value;
  }
}
