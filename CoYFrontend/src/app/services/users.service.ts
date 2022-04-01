import { Injectable } from '@angular/core';
import { User, UserCont } from '../model/user.interface';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(private http: HttpClient) { }

  /**
   * api/User Get request that retrieves a list of all users (id and names).
   * @returns An observable of users.
   */
  getAll(): Observable<User[]> {
    return this.http.get<User[]>(environment.apiUrl + '/User');
  }

  getMoney(): Observable<UserCont[]> {
    return this.http.get<UserCont[]>(environment.apiUrl + '/User/Money');
  }
}