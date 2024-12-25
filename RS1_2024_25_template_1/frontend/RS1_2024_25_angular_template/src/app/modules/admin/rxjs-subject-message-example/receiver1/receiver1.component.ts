import {Component, OnInit} from '@angular/core';
import {MessageService} from '../message.service';
import {map} from 'rxjs/operators';

@Component({
  selector: 'app-receiver1',
  standalone: false,

  templateUrl: './receiver1.component.html',
  styleUrl: './receiver1.component.css'
})
export class Receiver1Component implements OnInit {
  messages: string[] = [];

  constructor(private messageService: MessageService) {
  }

  ngOnInit(): void {
    this.messageService.message$
      .pipe(map(v => v.toUpperCase()))
      .subscribe((msg) => {
        this.messages.push(msg);
      });
  }
}
