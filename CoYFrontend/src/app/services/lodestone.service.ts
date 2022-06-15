import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LodestoneMaintenance, LodestoneTopic } from '../model/lodestone.interface';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LodestoneService {

  constructor(private http: HttpClient) { }

  /**
   * news/topics Get request that retrieves a list of current topics.
   * @returns An observable of topics.
   */
  getTopics(): Observable<LodestoneTopic[]> {
    return this.http.get<LodestoneTopic[]>(`${environment.lodestoneUrl}/topics`);
  }

  /**
   * news/maintenance/current Get request that retrieves a list of current topics.
   * @returns An observable of current maintenance.
   */
  getMaintenance(): Observable<LodestoneMaintenance> {
    return this.http.get<LodestoneMaintenance>(`${environment.lodestoneUrl}/maintenance/current`);
  }
}
