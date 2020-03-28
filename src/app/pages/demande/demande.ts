import { DemandeService } from './../../services/demande.service';
import { Component, ViewEncapsulation } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { InAppBrowser } from '@ionic-native/in-app-browser/ngx';
import { ActionSheetController, NavParams } from '@ionic/angular';
import {FormBuilder, FormGroup, Validators, AbstractControl} from '@angular/forms';
import { Injectable } from '@angular/core';

import { ConferenceData } from '../../providers/conference-data';
import { AuthService } from 'src/app/services/auth.service';
import { LoginPage } from '../login/login';

@Component({
  selector: 'page-speaker-list',
  templateUrl: 'demande.html',
  styleUrls: ['./demande.scss'],
})

export class SpeakerListPage {
  speakers: any[] = [];
  formgroup: FormGroup;
  montant: AbstractControl;
  login: any;
  public employees: any;
  public employee: Array<any> = [];
  constructor(
    public actionSheetCtrl: ActionSheetController,
    public confData: ConferenceData,
    public inAppBrowser: InAppBrowser,
    public router: Router,
    public activatedRoute: ActivatedRoute,
    public auth: AuthService,
    public demandeservice: DemandeService,
    public log: LoginPage,    ) {
      this.activatedRoute.queryParams.subscribe((res) => {
        this.login = JSON.parse(res.value);
        console.log(JSON.parse(res.value));

        this.auth.GetEmploye(JSON.parse(res.value)
           // tslint:disable-next-line:no-shadowed-variable
           ).then(data => {
           this.employees = data ;
           this.employee[0] = this.employees;
           console.log(this.employee[0]);
           // tslint:disable-next-line:max-line-length
           this.employee[0].numcarte = '************' + this.employee[0].numcarte.toString()[12] + this.employee[0].numcarte.toString()[13] + this.employee[0].numcarte.toString()[14] + this.employee[0].numcarte.toString()[15] ;
           console.log(this.employee[0].numcarte);

         }
            );
      /*  this.router.navigate(['/app/tabs/home'], {
              queryParams: {value : JSON.stringify(this.login)
              , }
              });*/
       /* console.log(this.login);*/
          });
    }


ionViewDidEnter() {
    this.confData.getSpeakers().subscribe((speakers: any[]) => {
      this.speakers = speakers;
    });
  }

goToSpeakerTwitter(speaker: any) {
    this.inAppBrowser.create(
      `https://twitter.com/${speaker.twitter}`,
      '_blank'
    );
  }

async openSpeakerShare(speaker: any) {
    const actionSheet = await this.actionSheetCtrl.create({
      header: 'Share ' + speaker.name,
      buttons: [
        {
          text: 'Copy Link',
          handler: () => {
            console.log(
              'Copy link clicked on https://twitter.com/' + speaker.twitter
            );
          }
        },
        {
          text: 'Share via ...'
        },
        {
          text: 'Cancel',
          role: 'cancel'
        }
      ]
    });

    await actionSheet.present();
  }

// tslint:disable-next-line:align
async openContact(speaker: any) {
    const mode = 'ios'; // this.config.get('mode');

    const actionSheet = await this.actionSheetCtrl.create({
      header: 'Contact ' + speaker.name,
      buttons: [
        {
          text: `Email ( ${speaker.email} )`,
          icon: mode !== 'ios' ? 'mail' : null,
          handler: () => {
            window.open('mailto:' + speaker.email);
          }
        },
        {
          text: `Call ( ${speaker.phone} )`,
          icon: mode !== 'ios' ? 'call' : null,
          handler: () => {
            window.open('tel:' + speaker.phone);
          }
        }
      ]
    });

    await actionSheet.present();
  }
}
