import { Component } from '@angular/core';
import {HttpClient} from '@angular/common/http';

export interface GetPodaciResponse {
  datumPonude: string
  podaci: Drzava[]
}

export interface Drzava {
  id: number
  drzava: string
  boravakGradovi: BoravakGradovi[]
  slikaUrl: string
  opisPonude: string
  akcijaPoruka: string
  naredniPolazak: NaredniPolazak
  planiranaPutovanja: PlaniranaPutovanja[]
}

export interface BoravakGradovi {
  brojNocenja: number
  hotelNaziv: string
  nazivGrada: string
}

export interface NaredniPolazak {
  zaDana: number
  datumPol: string
  countSlobodnoMjesta: number
  cijenaPoOsobiEur: number
}

export interface PlaniranaPutovanja {
  idPutovanje: number
  countSlobodnoMjesta: number
  cijenaPoOsobiEur: number
  datumPol: string
  datumPov: string
  brojDana: number
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

  title = 'adil';
  baseUrl = "https://wrd-fit.info";
  globalPodaci: Drzava[] = [];
  odabranaDrzava: Drzava | null = null;
  odabranoPutovanje: PlaniranaPutovanja | null = null;

  constructor(private httpClient: HttpClient){

  }

  ngOnInit(): void {
    this.k1_Preuzmi();
  }

  k1_Preuzmi(){

    let url = `${this.baseUrl}/Ispit20240921/GetNovePonude`

    this.httpClient.get<GetPodaciResponse>(url).subscribe((x)=>{
      this.globalPodaci = x.podaci;
    });
  }

  K2_odaberiDestinaciju(drzave:Drzava) {
    this.odabranaDrzava = drzave;

  }

  K3_OdaberiPutovanje(polazak:PlaniranaPutovanja) {
    this.odabranoPutovanje = polazak;
  }
}
