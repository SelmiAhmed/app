import { AuthService } from './../../services/auth.service';
import { Component, ViewEncapsulation, OnInit, Injectable } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

import { UserData } from '../../providers/user-data';

import { UserOptions } from '../../interfaces/user-options';

import { DemandeService } from './../../services/demande.service';
import { HttpClientModule } from '@angular/common/http';
import {  AuthResponseData } from './../../services/auth.service';

import { LoadingController, AlertController, NavController } from '@ionic/angular';
import { Observable } from 'rxjs';
import { HomePage } from '../home/home.page';
import { map } from 'jquery';
@Injectable({
  providedIn: 'root'
})
@Component({
  selector: 'page-login',
  templateUrl: 'login.html',
  styleUrls: ['./login.scss'],
})
export class LoginPage implements OnInit {
  /*login: string;
  matricule: string;*/

  submitted = false;
  isLoading = false;
  isLogin = true;
  public mdp: any;
  public employees: any;
  public employe: Array<object> = [];
  authObs: any;

  public constructor( private userData: UserData,
                      public navCtrl: NavController,
                      private router: Router,
                      private alertCtrl: AlertController,
                      private loadingCtrl: LoadingController,
                      private auth: AuthService,
                      private demandeservice: DemandeService
                      ) {  }
               ngOnInit() {}
              /* goTo(login) {
                login = login;
                this.router.navigateByUrl('app/tabs/home', {
                  data: login
                });
              }*/
              onGoTohistoPage() {
                this.router.navigate(['/app/tabs/avance'], {
                queryParams: {value : JSON.stringify(this.mdp)
                , }
                });
                console.log(this.mdp);
                return this.mdp;
               }
               onGoTohomePage() {
                this.router.navigate(['/app/tabs/home'], {
                queryParams: {value : JSON.stringify(this.mdp)
                , }
                });
                console.log(this.mdp);
                return this.mdp;
               }
               getLOG(login, matricule) {
               this.demandeservice.GetEmployebylog(login, matricule).
                then(data => {
                    this.employees = data;
                    this.router.navigateByUrl('app/tabs/home'); }); }
              public getemploye(login) {
                 this.auth.GetEmploye(login
                  // tslint:disable-next-line:no-shadowed-variable
                  ).then(data => {
                  this.employees = data ;
                  console.log(this.employees);
                }
                   );
              }

               authenticate(login, matricule) {
                this.isLoading = true;
                this.loadingCtrl
                  .create({ keyboardClose: true, message: 'Logging in...' })
                  .then(loadingEl => {
                    loadingEl.present();
                    let authObs: any;
                    this.auth.GetEmployebylog(login, matricule).
                    then(data => {
                      this.employees = data;
                      console.log(this.employees);
                      if (data === 1) {
                        if (this.isLogin) {
                          authObs = this.auth.login(login, matricule);
                        }
                        this.isLoading = false;
                        loadingEl.dismiss();
                        /*this.router.navigateByUrl('/app/tabs/home');*/
                        this.onGoTohomePage();
                        this.getemploye(login);
                        login = '';
                        matricule = '';
                        return this.employees;
                       } else {

                      loadingEl.dismiss();
                      const message = 'Could not sign you up, please try again.';
                      this.showAlert(message);
                      return false;

                        }
                     });

                    });

              }

              onSwitchAuthMode() {
                this.isLogin = !this.isLogin;
              }
              onSubmit(form: NgForm) {
                if (!form.valid) {
                  return;
                }
                const login = form.value.login;
                const matricule = form.value.Matricule;
                this.authenticate(login, matricule);
                this.mdp = login;
                return login;
              }
              log() {
              this.onSubmit = this.mdp;
              return this.mdp;
              }
              private showAlert(message: string) {
                this.alertCtrl
                  .create({
                    header: 'Authentication failed',
                    message,
                    buttons: ['Okay']
                  })
                  .then(alertEl => alertEl.present());
              }

  getemployeebylogin(login, matricule) {
   this.demandeservice.GetEmployebylog(login, matricule).then(data => {
     this.employees = data ;
     console.log(this.employees);
   });
 }
 /*getemployeebymat(matricule) {
  this.demandeservice.GetEmployemat(matricule).then(data => {
    this.employees = data ;
    console.log(this.employees);
  });
} onLogin(form: NgForm) {
    this.submitted = true;

    if (form.valid) {
      this.userData.login(this.login.username);
      this.router.navigateByUrl('/app/tabs/schedule');
    }
  }*/

  onSignup() {
    this.router.navigateByUrl('/signup');
  }
}
