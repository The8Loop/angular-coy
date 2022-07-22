import { Injectable } from '@angular/core';
import { Leaderboard, SessionDTO, User, UserContribution, UserLogin } from '../model/user.interface';
import { MoneyDTO, TotalSP } from '../model/money.interface';
import { HttpClient, HttpErrorResponse, HttpResponse, HttpEvent, HttpInterceptor, HttpRequest, HttpHandler } from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UsersService implements HttpInterceptor {

  constructor(private http: HttpClient) { }

  intercept(req: HttpRequest<any>, next: HttpHandler):
    Observable<HttpEvent<any>> {
    console.log("Intercepted")
    return next.handle(req);
  }

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

  addUser(userLogin: UserLogin): Observable<User> {
    return this.http.post<User>(`${environment.apiUrl}/User`, userLogin);
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

  /**
   * api/User/Leaderboard Get request to run stored procedure for free company leaderboard
   * @returns An observable of Leaderboard
   */
  getLeaderboard(): Observable<Leaderboard[]> {
    return this.http.get<Leaderboard[]>(`${environment.apiUrl}/User/Leaderboard`);
  }

  getUserLogin(userLogin: UserLogin): Observable<SessionDTO> {
    return this.http.post<SessionDTO>(`${environment.apiUrl}/User/Login`, userLogin);
  }
}