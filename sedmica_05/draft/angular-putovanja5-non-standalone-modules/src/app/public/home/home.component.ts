import {Component, OnInit} from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  traziVrijednost: string = "";
  baseUrl = "https://wrd-fit.info";
  globalPodaci: any[] = [];
  odabranaDrzava: any = null;

  ngOnInit(): void {
    this.preuzmi();
  }

  getFiltiratiPodaci() {
    if (this.traziVrijednost.length > 2) {
      return this.globalPodaci.filter(x => x.drzava === this.traziVrijednost || x.boravakGradovi.filter((g: any) => g.nazivGrada === this.traziVrijednost).length > 0)
    } else {
      return this.globalPodaci
    }
  }

  preuzmi() {
    //https://wrd-fit.info/ -> Ispit20240921 -> GetPonuda

    let url = `${this.baseUrl}/Ispit20240921/GetNovePonude`

    fetch(url)
      .then(r => {
        if (r.status !== 200) {
          //greska
          return;
        }
        r.json().then(t => {
          this.globalPodaci = t.podaci //setujemo globalnu varijablu

        })
      })
  }

  K2_odaberiDestinaciju(x: any) {
    this.odabranaDrzava = x;
  }
}
