import { NgForm } from '@angular/forms';
import { LoginPage } from './../login/login';
import { Component, OnInit } from '@angular/core';
import { NavController, NavParams } from '@ionic/angular';
import { DemandeService } from './../../services/demande.service';
import { HttpClientModule } from '@angular/common/http';
import {  AuthResponseData, AuthService } from './../../services/auth.service';

import { LoadingController, AlertController } from '@ionic/angular';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'home.page',
  templateUrl: './home.page.html',
  styleUrls: ['./home.scss'],
})
export class HomePage implements OnInit {
  public cards: any;
  public matricule: string;
  login: any;
 public employees: any;
 public employee: Array<any> = [];
 isLoading = false;
 isLogin = true;
  constructor(public navCtrl: NavController,
              public router: Router,
              private alertCtrl: AlertController,
              private loadingCtrl: LoadingController,
              public auth: AuthService,
              public demandeservice: DemandeService,
              public log: LoginPage,
              public activatedRoute: ActivatedRoute,            ) {
              this.cards = [
      {
        state: 'ON',
        logo: 'assets/img/visa.png',
        a: 1234,
        b: 5522,
        c: 8432,
        d: 2264,
        expires: '12/2030',
        bank: 'STB Bank'
      }
    ];
              this.onGoTohistoPage();
              this.activatedRoute.queryParams.subscribe((res) => {
                this.login = JSON.parse(res.value);
                console.log(JSON.parse(res.value));

                this.auth.GetEmploye(JSON.parse(res.value)
                   // tslint:disable-next-line:no-shadowed-variable
                   ).then(data => {
                   this.employees = data ;
                   this.employee[0] = this.employees;
                   console.log(this.employee[0]);
                   console.log(this.employee[0].numcarte.toString()[12]);
                   // tslint:disable-next-line:max-line-length
                   this.employee[0].numcarte = this.employee[0].numcarte.toString()[12] + this.employee[0].numcarte.toString()[13] + this.employee[0].numcarte.toString()[14] + this.employee[0].numcarte.toString()[15] ;
                   console.log(this.employee[0].numcarte);
                 }
                    );
                this.router.navigate(['/app/tabs/Historique'], {
                      queryParams: {value : JSON.stringify(this.login)
                      , }
                      });
                console.log(this.login);
        });


             /* this.onGoToNextPage();*/
            /*  this.employee[0] =  this.log.getemploye(this.login);
              console.log(this.login);
              this.log.getemploye(this.login) ;
      // tslint:disable-next-line:no-shadowed-variable

              console.log(this.employee[0]);*/
  }
  /*onGoToNextPage() {
    this.router.navigate(['/app/tabs/home'], {
    queryParams: {value : JSON.stringify(this.employee[0].id)
    , }
    });
    console.log(this.employee[0].id);
    return this.employee[0].id;
   }*/
   /*hidecarte(num) {
    const c = num.toString();
    for ( let j = c.length - 4,  j === c.length(), j++) {
    c = c[i];
}
    return c;
  }*/
  onGoTohistoPage() {
    this.router.navigate(['/app/tabs/Historique'], {
    queryParams: {value : JSON.stringify(this.login)
    , }
    });
    console.log(this.login);
    return this.login;
   }
getemp() {


  }

update(card) {
    if (card.state === 'ON') {
      card.state = 'OFF';
    } else {
      card.state = 'ON';
    }
  }
ngOnInit() {
  }

  /*authenticate(login: string, matricule: string) {
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
            this.router.navigateByUrl('/app/tabs/home');
            this.auth.GetEmploye(login
              // tslint:disable-next-line:no-shadowed-variable
              ).then(data => {
              this.employees = data ;
              console.log(this.employees); } );
           } else {

          loadingEl.dismiss();
          const message = 'Could not sign you up, please try again.';
          this.showAlert(message);
            }
         });

        });

  }


  onSubmit(form: any) {
    if (!form.valid) {
      return;
    }
    const login = form.value.login;
    const matricule = form.value.Matricule;
    this.authenticate(login, matricule);
  }*/
  private showAlert(message: string) {
    this.alertCtrl
      .create({
        header: 'Authentication failed',
        message,
        buttons: ['Okay']
      })
      .then(alertEl => alertEl.present());
  }



}
