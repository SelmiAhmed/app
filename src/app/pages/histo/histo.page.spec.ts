import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { HistoPage } from './histo.page';

describe('HistoPage', () => {
  let component: HistoPage;
  let fixture: ComponentFixture<HistoPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HistoPage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(HistoPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
