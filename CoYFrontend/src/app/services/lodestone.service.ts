import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LodestoneMaintenance, LodestoneTopic } from '../model/lodestone';

@Injectable({
  providedIn: 'root'
})
export class LodestoneService {

  constructor(private http: HttpClient) { }

  getTopics(): Observable<LodestoneTopic[]> {
    return this.http.get<LodestoneTopic[]>('https://lodestonenews.com/news/topics');
  }

  getMaintenance(): Observable<LodestoneMaintenance> {
    return this.http.get<LodestoneMaintenance>('https://lodestonenews.com/news/maintenance/current');
  }
}
