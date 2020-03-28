import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { SwUpdate } from '@angular/service-worker';

import { MenuController, Platform, ToastController } from '@ionic/angular';

import { SplashScreen } from '@ionic-native/splash-screen/ngx';
import { StatusBar } from '@ionic-native/status-bar/ngx';

import { Storage } from '@ionic/storage';

import { UserData } from './providers/user-data';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class AppComponent implements OnInit {
  appPages = [
    {
      title: 'Accueil',
      url: '/app/tabs/home',
      icon: 'home'
    },
    {
      title: 'Mon Historique',
      url: '/app/tabs/Historique',
      icon: 'list'
    },
    {
      title: 'Demande Avance',
      url: '/app/tabs/avance',
      icon: 'document'
    },
    {
      title: 'Consulter Reseau Distributeur',
      url: '/app/tabs/map',
      icon: 'map'
    },
    {
      title: 'A propos',
      url: '/app/tabs/about',
      icon: 'information-circle'
    },
    {
      title: 'Notifications',
      url: '/app/tabs/Notifications',
      icon: 'notifications'
    },
    {
      title: 'Paramèters',
      url: '/app/tabs/Paramèters',
      icon: 'settings'
    }
    ,
    {
      title: 'Statistiques',
      url: '/app/tabs/Statistiques',
      icon: 'analytics'
    }
  ];
  loggedIn = false;
  dark = false;

  constructor(
    private menu: MenuController,
    private platform: Platform,
    private router: Router,
    private splashScreen: SplashScreen,
    private statusBar: StatusBar,
    private storage: Storage,
    private userData: UserData,
    private swUpdate: SwUpdate,
    private toastCtrl: ToastController,
  ) {
    this.initializeApp();
  }

  async ngOnInit() {
    this.checkLoginStatus();
    this.listenForLoginEvents();

    this.swUpdate.available.subscribe(async res => {
      const toast = await this.toastCtrl.create({
        message: 'Update available!',
        position: 'bottom',
      });

      await toast.present();

      toast
        .onDidDismiss()
        .then(() => this.swUpdate.activateUpdate())
        .then(() => window.location.reload());
    });
  }

  initializeApp() {
    this.platform.ready().then(() => {
      this.statusBar.styleDefault();
      this.splashScreen.hide();
      this.login();
    });
  }
login() {
  this.router.navigateByUrl('/login');
}
  checkLoginStatus() {
    return this.userData.isLoggedIn().then(loggedIn => {
      return this.updateLoggedInStatus(loggedIn);
    });
  }

  updateLoggedInStatus(loggedIn: boolean) {
    setTimeout(() => {
      this.loggedIn = loggedIn;
    }, 300);
  }

  listenForLoginEvents() {
    window.addEventListener('user:login', () => {
      this.updateLoggedInStatus(true);
    });

    window.addEventListener('user:signup', () => {
      this.updateLoggedInStatus(true);
    });

    window.addEventListener('user:logout', () => {
      this.updateLoggedInStatus(false);
    });
  }

  logout() {
      return this.router.navigateByUrl('/login');
  }

  openTutorial() {
    this.menu.enable(false);
    this.storage.set('ion_did_tutorial', false);
    this.router.navigateByUrl('/tutorial');
  }
}
