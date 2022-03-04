import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl } from '@angular/forms';
import { User } from 'src/app/model/user.interface';
import { intValidator } from '../intValidator.directive';

@Component({
  selector: 'coy-input-int',
  templateUrl: './input-int.component.html',
  styleUrls: ['./input-int.component.scss']
})
export class InputIntComponent implements OnInit {

  @Input() selectedUser!: User; //Inputs the selected user from the create page to check if ID isn't zero.
  @Output() userContribution = new EventEmitter<Number>(); //Outputs the user contribution to create page.

  contribution = new FormControl(0, intValidator());

  ngOnInit(): void {
  }

  /**
   * Event triggers when save button is clicked. User Contribution is outputed.
   * @param contribution User contribution
   */
  clickEvent(contribution: Number): void {
    this.userContribution.emit(contribution);
  }
}
