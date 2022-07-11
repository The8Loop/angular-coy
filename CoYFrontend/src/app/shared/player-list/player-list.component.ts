import { Component, Input } from '@angular/core';
import { User } from 'src/app/model/user.interface';

@Component({
  selector: 'coy-player-list',
  templateUrl: './player-list.component.html',
  styleUrls: ['./player-list.component.scss']
})
export class PlayerListComponent {

  @Input() userList!: User[];

}
