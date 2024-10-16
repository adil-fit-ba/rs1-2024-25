import {Component} from '@angular/core';
import {RouterOutlet} from '@angular/router';
import {FormsModule} from '@angular/forms';
import {NgForOf, NgIf, NgStyle} from '@angular/common';
import {HttpClient, HttpClientModule} from '@angular/common/http';

export interface Student {
  id: number
  ime: string
  prezime: string
  broj_indeksa: string
  opstina_rodjenja_id: number
  opstina_rodjenja: OpstinaRodjenja
  datum_rodjenja: string
  created_time: string
  slika_studenta: string
}

export interface OpstinaRodjenja {
  id: number
  description: string
  drzava_id: number
  drzava: Drzava
}

export interface Drzava {
  id: number
  naziv: string
}


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, FormsModule, NgIf, NgForOf, NgStyle, HttpClientModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {

  constructor(private httpClient: HttpClient) {
  }

  name: string = "Adil";

  counter: number = 0;

  arrayOfNumbers: string[] = ['jedan', 'dva', 'tri', 'četiri'];
  temp: string="";

  getName(): string {

    return "hello: " + this.name;
  }

  button1Click() {
    this.counter++;
    this.name += ("." + this.counter);
  }


  showHeader() {
    return this.name.length > 2
  }

  getHeaderStyle() {
    if (this.name.startsWith('A')) {
      return {backgroundColor: 'red'}
    } else {
      return {backgroundColor: 'blue'};
    }
  }

  studentArray:Student[] = [];

  fetchData() {
    const url = `https://wrd-fit.info/Student/GetAll`;

    this.httpClient.get(url).subscribe((x:any)=>{
      this.studentArray =x;
    });


  }
}
