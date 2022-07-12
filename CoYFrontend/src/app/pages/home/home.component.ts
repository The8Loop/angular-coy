import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs';
import { LodestoneMaintenance, LodestoneTopic } from 'src/app/model/lodestone.interface';
import { LodestoneService } from 'src/app/services/lodestone.service';

@Component({
  selector: 'coy-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  lodestoneTopics: LodestoneTopic[] = [];
  lodestoneMaintenance!: LodestoneMaintenance;
  isLoadingMaintenance = true;

  constructor(private lodestoneService: LodestoneService) { }

  ngOnInit(): void {
    this.lodestoneService.getTopics().pipe(
      map(e => {
        e = e.splice(0, 3);
        return e;
      }))
      .subscribe(lodestoneTopics => this.lodestoneTopics = lodestoneTopics);

    this.lodestoneService.getMaintenance()
      .subscribe(lodestoneMaintenance => {
        this.lodestoneMaintenance = lodestoneMaintenance,
          this.isLoadingMaintenance = false
      });
  }
}