import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CheckTutorial } from './providers/check-tutorial.service';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/home',
    pathMatch: 'full'
  },
  {
    path: 'account',
    loadChildren: () => import('./pages/account/account.module').then(m => m.AccountModule)
  },
  {
    path: 'support',
    loadChildren: () => import('./pages/support/support.module').then(m => m.SupportModule)
  },
  {
    path: 'login',
    loadChildren: () => import('./pages/login/login.module').then(m => m.LoginModule)
  },
  {
    path: 'signup',
    loadChildren: () => import('./pages/signup/signup.module').then(m => m.SignUpModule)
  },
  {
    path: 'app',
    loadChildren: () => import('./pages/tabs-page/tabs-page.module').then(m => m.TabsModule)
  },
  {
    path: 'home',
    loadChildren: () => import('./pages/home/home.module').then( m => m.HomePageModule)
  },
  {
    path: 'stat',
    loadChildren: () => import('./pages/stat/stat.module').then( m => m.StatPageModule)
  },
  {
    path: 'parametres',
    loadChildren: () => import('./pages/parametres/parametres.module').then( m => m.ParametresPageModule)
  },
  {
    path: 'notif',
    loadChildren: () => import('./pages/notif/notif.module').then( m => m.NotifPageModule)
  },
  {
    path: 'histo',
    loadChildren: () => import('./pages/histo/histo.module').then( m => m.HistoPageModule)
  },
  {
    path: 'otp',
    loadChildren: () => import('./pages/otp/otp.module').then( m => m.OtpPageModule)
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
