import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { SpeakerListPage } from './demande';
const routes: Routes = [
  {
    path: '',
    component: SpeakerListPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SpeakerListPageRoutingModule {}
