import {Component} from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {FormsModule} from '@angular/forms';
import {NgForOf, NgIf} from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, FormsModule, NgIf, NgForOf],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  name: string = "Adil";

  counter:number = 0;

  arrayOfNumbers:string[]=['jedan', 'dva', 'tri', 'četiri'];

  getName():string{

    return "hello: " +this.name;
  }

  button1Click() {
    this.counter++;
    this.name += ("." + this.counter);
  }


  showHeader() {
    return this.name.length>2
  }
}
