import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs';
import { LodestoneMaintenance, LodestoneTopic } from 'src/app/model/lodestone';
import { LodestoneService } from 'src/app/services/lodestone.service';

@Component({
  selector: 'coy-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  lodestoneTopics: LodestoneTopic[] = [];

  lodestoneMaintenance: LodestoneMaintenance = {
    companion: []
  };

  constructor(private lodestoneService: LodestoneService) { }

  ngOnInit(): void {
    this.lodestoneService.getTopics().pipe(
      map(e => {
        e = e.splice(0, 3);
        e.forEach(e => e.time = (new Date(e.time)).toString());
        console.log({ e });
        return e;
      }))
      .subscribe(lodestoneTopics => this.lodestoneTopics = lodestoneTopics);

    this.lodestoneService.getMaintenance().pipe(
      map(e => {
        e.companion[0].start = new Date(e.companion[0].start).toString();
        e.companion[0].end = new Date(e.companion[0].end).toString();
        return e;
      })
    ).subscribe(lodestoneMaintenance => this.lodestoneMaintenance = lodestoneMaintenance);
  }
}