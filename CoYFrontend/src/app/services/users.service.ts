import { Injectable } from '@angular/core';
import { User } from '../model/user.interface';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  //private userUrl = 'http://localhost:5041/api/User';
  private userUrl = environment.apiUrl + '/User';
  constructor(private http: HttpClient) { }

  /**
   * api/User Get request that retrieves a list of all users (id and names).
   * @returns An observable of users.
   */
  getAll(): Observable<User[]> {
    return this.http.get<User[]>(this.userUrl);
  }
}