import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl } from '@angular/forms';
import { intValidator } from '../intValidator.directive';

@Component({
  selector: 'coy-input-int',
  templateUrl: './input-int.component.html',
  styleUrls: ['./input-int.component.scss']
})
export class InputIntComponent implements OnInit {

  @Output() userContribution = new EventEmitter<Number>();

  contribution = new FormControl(0, intValidator());

  constructor() { }

  ngOnInit(): void {
  }

  clickEvent(contribution: Number): void {
    this.userContribution.emit(contribution);
  }
}
