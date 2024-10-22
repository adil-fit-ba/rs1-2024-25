import {Component, OnInit} from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {HttpClient, HttpClientModule} from '@angular/common/http';
import {NgForOf} from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HttpClientModule, NgForOf],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'adil';
  baseUrl = "https://wrd-fit.info";
  globalPodaci: any[] = [];

  constructor(private httpClient: HttpClient){

  }

  ngOnInit(): void {
    this.k1_Preuzmi();
  }

  k1_Preuzmi(){

    let url = `${this.baseUrl}/Ispit20240921/GetNovePonude`

    this.httpClient.get(url).subscribe((x:any)=>{
        this.globalPodaci = x.podaci;
    });
  }

  K2_odaberiDestinaciju(b:number) {

  }
}
