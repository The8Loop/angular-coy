import { Component, OnInit, AfterViewInit } from '@angular/core';
import { LodestoneMaintenance } from 'src/app/model/lodestone';
import { LodestoneService } from 'src/app/services/lodestone.service';

@Component({
  selector: 'coy-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  time?: Date;
  startDate?: Date;
  endDate?: Date;

  lodestoneMaintenance: LodestoneMaintenance = {
    companion: []
  };

  constructor(private lodestoneService: LodestoneService) { }

  ngOnInit(): void {
    this.lodestoneService.getMaintenance().subscribe(lodestoneMaintenance => this.lodestoneMaintenance = lodestoneMaintenance);
  }

  ngAfterViewInit(): void {
    this.time = new Date(this.lodestoneMaintenance.companion[0].time);
    this.startDate = new Date(this.lodestoneMaintenance.companion[0].start);
    this.endDate = new Date(this.lodestoneMaintenance.companion[0].end);
  }

}