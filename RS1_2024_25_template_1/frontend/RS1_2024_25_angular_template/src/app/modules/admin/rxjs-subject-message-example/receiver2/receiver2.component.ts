import {Component, OnInit} from '@angular/core';
import {MessageService} from '../message.service';
import {tap} from 'rxjs/operators';

@Component({
  selector: 'app-receiver2',
  standalone: false,
  templateUrl: './receiver2.component.html',
  styleUrl: './receiver2.component.css'
})
export class Receiver2Component implements OnInit {
  messages: string[] = [];

  constructor(private messageService: MessageService) {
  }

  ngOnInit(): void {
    this.messageService.message$
      .pipe(
        tap(v => console.log(v))
      )
      .subscribe((msg) => {
        this.messages.push(msg);
      });
  }
}
