import {Component, OnInit} from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {HttpClient, HttpClientModule} from '@angular/common/http';
import {NgForOf, NgIf} from '@angular/common';

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
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HttpClientModule, NgForOf, NgIf],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
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
