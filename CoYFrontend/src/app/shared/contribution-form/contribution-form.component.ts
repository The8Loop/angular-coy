import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ContributionTypeDTO, MoneyPostDTO } from 'src/app/model/money.interface';
import { User } from 'src/app/model/user.interface';
import { intValidator } from '../intValidator.directive';

@Component({
  selector: 'coy-contribution-form',
  templateUrl: './contribution-form.component.html',
  styleUrls: ['./contribution-form.component.scss']
})
export class ContributionFormComponent {

  /**
  * Input list of users from create page to create a dropdown menu of names.
  */
  @Input() userList!: User[];
  @Input() contributionTypeList!: ContributionTypeDTO[];

  /**
   * Outputs the user clicked on to the create page.
   */
  //@Output() userSelected = new EventEmitter<User>();
  @Output() moneyPostDTOEmitter = new EventEmitter<MoneyPostDTO>();

  moneyPostDTO: MoneyPostDTO = {
    contribution: 0,
    contributionTypeId: 0,
    userId: 0,
  };

  contribution = new FormControl(0, intValidator());
  userDropdownDisplay = 'Select Company Member';
  contributionTypeDropdownDisplay = 'Select Contribution Type';

  clickEventCTDD(contributionType: ContributionTypeDTO) {
    this.contributionTypeDropdownDisplay = contributionType.contributionType;
    this.moneyPostDTO.contributionTypeId = contributionType.id;
  }

  /**
   * Event ran when clicking dropdown element.
   * @param user - Clicked user assigned to dropdown element.
   */
  clickEventUDD(user: User) {
    this.userDropdownDisplay = user.name;
    this.moneyPostDTO.userId = user.id;
  }

  clickEventSave(contribution: number) {
    this.moneyPostDTO.contribution = contribution;
    this.moneyPostDTOEmitter.emit(this.moneyPostDTO);
  }
}