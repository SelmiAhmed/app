import { NavController } from '@ionic/angular';
import { Component, OnInit } from '@angular/core';
import { DemandeService } from './../../services/demande.service';
import { HttpClientModule } from '@angular/common/http';
import { AlertController } from '@ionic/angular';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginPage } from '../login/login';

@Component({
  selector: 'histo',
  templateUrl: './histo.page.html',
  styleUrls: ['./histo.page.scss'],
})
export class HistoPage implements OnInit {
  login: any;
  public  demandes: any;
 public demande: Array<any> = [];
  // tslint:disable-next-line:max-line-length
  constructor(public navCtrl: NavController, public log: LoginPage, public router: Router, private alertCtrl: AlertController, public activatedRouter: ActivatedRoute,  public demandeservice: DemandeService) {
    /*this.getDemandes();*/
    this.log.onGoTohistoPage();
    this.activatedRouter.queryParams.subscribe((res) => {
      this.login = JSON.parse(res.value);
      console.log(JSON.parse(res.value));


      this.onGoToNextPage();
      this.demandeservice.GetDemandebyid(this.login
        // tslint:disable-next-line:no-shadowed-variable
        ).then(data => {
        this.demandes = data ;
        /*this.demande[0] = this.demandes;*/
        console.log(this.demandes);
      }
         );
      this.router.navigate(['/app/tabs/avance'], {
          queryParams: {value : JSON.stringify(this.login)
          , }
          });
      console.log(this.login);
});
}
    onGoToNextPage() {
  this.router.navigate(['/app/tabs/Historique'], {
  queryParams: {value : JSON.stringify(this.login)
  , }
  });
  console.log(this.login);
  return this.login;
 }

   getDemandes() {
    this.demandeservice.GetDemandes().then(data => {
      this.demandes = data ;
      console.log(this.demandes);
    });

  }

   delete(item) {
  this.demandeservice.deleteItem(item.id).subscribe(Response => {
    this.getDemandes(); });
  }

  async alert(item) {
    const alert = await this.alertCtrl.create({
      header: 'Supperssion',
      message: 'Vous etes sure de supprimer cette demande?',
      buttons: [
        {
          text: 'Annuler',
          role: 'Annuler',
          handler: () => {
            console.log('Annulation');
          }
        },
        {
          text: 'Confirmer',
          handler: () => {
            this.demandeservice.deleteItem(item.id).subscribe(Response => {
              this.getDemandes(); });
            console.log('Confirmation');
          }
        }
      ]
    });
    alert.present();
  }
    ngOnInit() {
  }

}
