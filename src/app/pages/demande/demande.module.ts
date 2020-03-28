import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule } from '@ionic/angular';

import { SpeakerListPage } from './demande';
import { SpeakerListPageRoutingModule } from './demande-routing.module';

@NgModule({
  imports: [
    CommonModule,
    IonicModule,
    SpeakerListPageRoutingModule
  ],
  declarations: [SpeakerListPage],
})
export class SpeakerListModule {}
