import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormControl } from '@angular/forms';
import { User } from 'src/app/model/user.interface';
import { intValidator } from '../intValidator.directive';

@Component({
  selector: 'coy-input-int',
  templateUrl: './input-int.component.html',
  styleUrls: ['./input-int.component.scss']
})
export class InputIntComponent {

  /**
   * Inputs the selected user from the create page to check if ID isn't zero.
   */
  @Input() selectedUser!: User;

  /**
   * Outputs the user contribution to create page.
   */
  @Output() userContribution = new EventEmitter<number>();

  contribution = new FormControl(0, intValidator());

  /**
   * Event triggers when save button is clicked. User Contribution is outputed.
   * @param contribution User contribution
   */
  clickEvent(contribution: number): void {
    this.userContribution.emit(contribution);
  }
}
