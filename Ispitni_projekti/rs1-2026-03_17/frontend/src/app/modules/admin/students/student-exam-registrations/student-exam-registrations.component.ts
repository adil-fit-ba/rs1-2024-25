import { Component } from '@angular/core';

@Component({
  selector: 'app-student-exam-registrations',
  standalone: false,

  templateUrl: './student-exam-registrations.component.html',
  styleUrl: './student-exam-registrations.component.css'
})
export class StudentExamRegistrationsComponent {

  novaPrijava() {
    alert('Ovo je ZADATAK B');
  }
}
