import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {FormsModule} from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, FormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'putovanja';

  baseUrl = "https://wrd-fit.info";

  provjeriImePrezimeGostiju(){

  }

  provjeriBrojPasosa(){

  }

  provjeriBrojGostiju(){

  }

  dialogSuccess(x:any,y:any){

  }

  idPutovanja = null;
  drzavaText = null;
  phone = null;
  datumPolaska = null;
  ukupnaCijena = null;
  brojPasosa = null;
  email = null;
  datumVazenjaPasosa = null;

  funkcija1(){
    let greske = "";
    greske += this.provjeriImePrezimeGostiju();
    greske += this.provjeriBrojPasosa();
    greske += this.provjeriBrojGostiju();

    if (greske !== "") {
      alert("podaci nisu uredu: " + greske);
      return;
    }

    let imenaGostijuArray:any[] = [];

    let n1 =
      {
        "idPutovanje": this.idPutovanja,
        "nazivDrzava": this.drzavaText,
        "brojTelefona": this.phone,
        "datumPolaska": this.datumPolaska,
        "cijenaUkupno": this.ukupnaCijena,
        "gostiPutovanja": imenaGostijuArray,
        "brojPasosa": this.brojPasosa,
        "emailAdresa": this.email,
        "datumVazenjaPasosa": this.datumVazenjaPasosa
      };


    let jsonString = JSON.stringify(n1)
    let url = `${this.baseUrl}/Ispit20240921/Dodaj`;

    //fetch tipa "POST" i saljemo "jsonString"
    fetch(url, {
      method: "POST",
      body: jsonString,
      headers: {
        "Content-Type": "application/json",
      }
    })
      .then(r => {
        if (r.status != 200) {
          alert("Greška")
          return;
        }

        r.json().then(t => {

          if (t.brojGresaka == 0) {
            this.dialogSuccess(`Idi na placanje rezervacije broj ${t.idRezervacije} - iznos ${this.ukupnaCijena} EUR`, () => {
              // @ts-ignore
              window.location = `https://www.paypal.com/cgi-bin/webscr?business=adil.joldic@yahoo.com&cmd=_xclick&currency_code=EUR&amount=${this.ukupnaCijena}&item_name=Dummy invoice`
            });
          }
          else {
            alert("greske: \n" + t.spisakGresaka.join('\n'));
          }
        })

      })
  }
}
