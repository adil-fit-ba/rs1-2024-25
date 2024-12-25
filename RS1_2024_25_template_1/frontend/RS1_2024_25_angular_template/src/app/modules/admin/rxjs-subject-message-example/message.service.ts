import {Injectable} from '@angular/core';
import {startWith, Subject} from 'rxjs';
import {debounceTime, distinctUntilChanged, tap} from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class MessageService {
  private messageSubject = new Subject<string>();

  // Observable sa operatorima
  message$ = this.messageSubject.asObservable().pipe(
    startWith("otvoren stream"),
    debounceTime(300), // Odgađa emitovanje za 300ms
    distinctUntilChanged(), // Propušta samo promijenjene vrijednosti
    //filter((message) => message.length > 2), // Propušta samo poruke duže od 3 znaka
    tap((message) => console.log("message-service: " + message))
  );

  // Emitovanje poruke
  sendMessage(message: string): void {
    this.messageSubject.next(message);
  }
}
