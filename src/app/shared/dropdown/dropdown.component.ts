import { Component, EventEmitter, Input, Output } from '@angular/core';
import { User } from 'src/app/model/user.interface';

@Component({
  selector: 'coy-dropdown',
  templateUrl: './dropdown.component.html',
  styleUrls: ['./dropdown.component.scss']
})
export class DropdownComponent {

  /**
   * Input list of users from create page to create a dropdown menu of names.
   */
  @Input() userList!: User[];

  /**
   * Outputs the user clicked on to the create page.
   */
  @Output() userSelected = new EventEmitter<User>();

  userName = 'Choose Guild Member';

  /**
   * Event ran when clicking dropdown element.
   * @param user - Clicked user assigned to dropdown element.
   */
  clickEvent(user: User): void {
    this.userName = user.userName;
    this.userSelected.emit(user);
  }
}