import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TabsPage } from './tabs-page';
/*import { SchedulePage } from '../Histo/histo';*/


const routes: Routes = [
  {
    path: 'tabs',
    component: TabsPage,
    children: [
      {
        path: 'avance',
        children: [
          {
            path: '',
            loadChildren: () => import('../demande/demande.module').then(m => m.SpeakerListModule)
          },
          {
            path: 'session/:sessionId',
            loadChildren: () => import('../session-detail/session-detail.module').then(m => m.SessionDetailModule)
          },
          {
            path: 'speaker-details/:speakerId',
            loadChildren: () => import('../speaker-detail/speaker-detail.module').then(m => m.SpeakerDetailModule)
          }
        ]
      },
      {
        path: 'map',
        children: [
          {
            path: '',
            loadChildren: () => import('../map/map.module').then(m => m.MapModule)
          }
        ]
      },
      {
        path: 'Historique',
        children: [
          {
            path: '',
            loadChildren: () => import('../histo/histo.module').then(m => m.HistoPageModule)
          }
        ]
      },
      {
        path: 'about',
        children: [
          {
            path: '',
            loadChildren: () => import('../about/about.module').then(m => m.AboutModule)
          }
        ]
      }, {
        path: 'home',
        children: [
          {
            path: '',
            loadChildren: () => import('../home/home.module').then(m => m.HomePageModule)
          }
        ]
      },
      {
        path: 'Paramèters',
        children: [
          {
            path: '',
            loadChildren: () => import('../parametres/parametres.module').then(m => m.ParametresPageModule)
          }
        ]
      },
      {
        path: 'Statistiques',
        children: [
          {
            path: '',
            loadChildren: () => import('../stat/stat.module').then(m => m.StatPageModule)
          }
        ]
      },
      {
        path: 'Notifications',
        children: [
          {
            path: '',
            loadChildren: () => import('../notif/notif.module').then(m => m.NotifPageModule)
          }
        ]
      },
      {
        path: '',
        redirectTo: '/app/tabs/Historique',
        pathMatch: 'full'
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TabsPageRoutingModule { }

