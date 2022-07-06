import { Injectable } from '@angular/core';
import { User, UserContribution } from '../model/user.interface';
import { MoneyDTO, TotalSP } from '../model/money.interface';
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
    return this.http.get<User[]>(`${environment.apiUrl}/User`);
  }

  /**
   * api/User/id Get request that retrieves a user by id, including contributions.
   * @param id
   * @returns An observable of user.
   */
  getUser(id: number): Observable<UserContribution> {
    return this.http.get<UserContribution>(`${environment.apiUrl}/User/${id}`)
  }

  /**
   * api/User/Money Get request that retrieves a list of all users and their contributions.
   * @returns An observable of UserCont[]
   */
  getMoney(): Observable<UserContribution[]> {
    return this.http.get<UserContribution[]>(`${environment.apiUrl}/User/Money`);
  }

  /**
   * api/User/Money Post request of a user contribution
   * @param moneyDTO 
   * @returns An observable of MoneyDTO
   */
  addMoneyForUser(moneyDTO: MoneyDTO): Observable<MoneyDTO> {
    return this.http.post<MoneyDTO>(`${environment.apiUrl}/User/Money`, moneyDTO);
  }

  /**
   * api/Money/Company Get request to run stored procedure for free company total
   * @returns An observable of TotalSP
   */
  getCompanyTotal(): Observable<TotalSP> {
    return this.http.get<TotalSP>(`${environment.apiUrl}/Money/Company`);
  }

  /**
   * api/User/Money/id Get request to run stored procedure for player total
   * @param id
   * @returns An observable of TotalSP
   */
  getPlayerTotal(id: number): Observable<TotalSP> {
    return this.http.get<TotalSP>(`${environment.apiUrl}/User/Money/${id}`);
  }
}