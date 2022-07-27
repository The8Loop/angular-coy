import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient) { }

  public loggedIn = false;

  createSession(sessionIdentier: string) {
    sessionStorage.setItem("session", sessionIdentier);
  }

  getSession(): string | null {
    return sessionStorage.getItem("session");
  }

  deleteSession() {
    const session = this.getSession()
    if (session != null) {
      this.userLogout(session);
      sessionStorage.clear();
    }
  }

  userLogout(sessionIdentfier: string) {
    const header = new HttpHeaders().set("Session-Identifier", sessionIdentfier);
    this.http.delete(`${environment.apiUrl}/User/Logout`, { 'headers': header }).subscribe();
  }
}