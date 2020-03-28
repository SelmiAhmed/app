import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { tap } from 'rxjs/operators';

export interface AuthResponseData {
  kind: string;
  matricule: string;
  login: string;
  refreshToken: string;
  localId: string;
  expiresIn: string;
  registered?: boolean;
  employees: any;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  apiUrl = 'http://localhost:51655/api';
  private UserIsAuthenticated = false;
  private UserId = null;



  constructor(public http: HttpClient) {
   }
   get userIsAuthenticated() {
    return this.UserIsAuthenticated;
  }

  get userId() {
    return this.UserId;
  }
  logout() {
    this.UserIsAuthenticated = false;
  }
  login(login: string, matricule: string) {
    return this.http.post<AuthResponseData>((this.apiUrl + '/Employe/details' + login + '/' + matricule + '/'), {login, matricule})
.pipe(tap(this.setUserData.bind(this)));
  }

GetEmployebylog(loginemploye, matricule) {
  return new Promise(reslove => {
    this.http.get(this.apiUrl + '/Employe/' + loginemploye + '/' + matricule).subscribe(data => {
      reslove(data);
    }, err => {console.log(err);
    });
  });
  }


  GetEmploye(login) {
    return new Promise(reslove => {
      this.http.get(this.apiUrl + '/Employe/login/' + login ).subscribe(data => {
        reslove(data);
      }, err => {console.log(err);
      });
    });
    }
private setUserData(userData: AuthResponseData) {
  const expirationTime = new Date(
    new Date().getTime() + +userData.expiresIn * 1000
  );
  }

}
