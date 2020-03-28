import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DemandeService {

  apiUrl = 'http://localhost:51655/api';

  constructor(public http: HttpClient) {
  }
   deleteItem(id) {
return this.http.
 delete(this.apiUrl + '/Demande/' + id);
  }


    GetDemandes() {
    return new Promise(reslove => {
      this.http.get(this.apiUrl + '/Demande').subscribe(data => {
        reslove(data);
      }, err => {console.log(err);
      });
    });
    }
    GetDemandebyid(login) {
      return new Promise(reslove => {
        this.http.get(this.apiUrl + '/Demande/' + login ).subscribe(data => {
          reslove(data);
        }, err => {console.log(err);
        });
      });
      }
    GetEmployebylog(login, matricule) {
      return new Promise(reslove => {
        this.http.get(this.apiUrl + '/Employe/' + login + '/' + matricule).subscribe(data => {
          reslove(data);
        }, err => {console.log(err);
        });
      });
      }

      GetEmploye(login) {
        return new Promise(reslove => {
          this.http.get(this.apiUrl + '/Employe/' + login).subscribe(data => {
            reslove(data);
          }, err => {console.log(err);
          });
        });
        }
     /* GetEmployemat(matricule) {
        return new Promise(reslove => {
          this.http.get(this.apiUrl + '/Employe/' + matricule).subscribe(data => {
            reslove(data);
          }, err => {console.log(err);
          });
        });
        }*/
}
