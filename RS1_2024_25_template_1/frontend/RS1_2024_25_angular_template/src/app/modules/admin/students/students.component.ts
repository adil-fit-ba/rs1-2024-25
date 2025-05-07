import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {Router} from '@angular/router';
import {
  StudentGetAllEndpointService,
  StudentGetAllResponse
} from '../../../endpoints/student-endpoints/student-get-all-endpoint.service';
import {StudentDeleteEndpointService} from '../../../endpoints/student-endpoints/student-delete-endpoint.service';
import {MatDialog} from '@angular/material/dialog';
import {MatTableDataSource} from '@angular/material/table';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import {debounceTime, distinctUntilChanged, filter, map, tap} from 'rxjs/operators';
import {Subject} from 'rxjs';
import {MyDialogConfirmComponent} from '../../shared/dialogs/my-dialog-confirm/my-dialog-confirm.component';
import {MySnackbarHelperService} from '../../shared/snackbars/my-snackbar-helper.service';
import {MyDialogSimpleComponent} from '../../shared/dialogs/my-dialog-simple/my-dialog-simple.component';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css'],
  standalone: false
})
export class StudentsComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['firstName', 'lastName', 'studentNumber', 'deleteDate', 'deletedBy', 'actions'];
  dataSource: MatTableDataSource<StudentGetAllResponse> = new MatTableDataSource<StudentGetAllResponse>();
  students: StudentGetAllResponse[] = [];

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  showDeleted = false;  //added
  private searchSubject: Subject<string> = new Subject();

  constructor(
    private studentGetService: StudentGetAllEndpointService,
    private studentDeleteService: StudentDeleteEndpointService,
    private snackbar: MySnackbarHelperService,
    private router: Router,
    private dialog: MatDialog
  ) {
  }

  ngOnInit(): void {
    this.initSearchListener();
    this.fetchStudents();
  }

  // Set up the RxJS pipeline for search input
  initSearchListener(): void {
    this.searchSubject.pipe(
      debounceTime(300), 
      map((q: string) => q.toLowerCase()), // Convert the search query to lowercase
      filter((q: string) => q.length > 3), // Only continue if the query is longer than 3 characters
      distinctUntilChanged(), // Only proceed if the query has changed from the previous value
      tap((filterValue: string) => {
        // Call fetchStudents with the filtered value
        this.fetchStudents(filterValue);
            
      })
    ).subscribe(); // Subscribe to start listening for search input changes
  }

  ngAfterViewInit(): void {
    this.paginator.page.subscribe(() => {
      const filterValue = this.dataSource.filter || '';
      this.fetchStudents(filterValue, this.paginator.pageIndex + 1, this.paginator.pageSize);
    });
  }

  applyFilter(event: Event): void {
    const filterValue = (event.target as HTMLInputElement).value.trim().toLowerCase();
    this.searchSubject.next(filterValue);
  }

  // Fetch students from the backend and update the table
  fetchStudents(filter: string = '', page: number = 1, pageSize: number = 5): void {
    this.studentGetService.handleAsync({
      q: filter,
      pageNumber: page,
      pageSize: pageSize
    }).subscribe({
      next: (data) => {
        // Save all students into the students array
        this.students = data.dataItems;
        // Set the table data: show all students if showDeleted is true, otherwise only non-deleted
        this.dataSource.data = this.showDeleted
          ? this.students
          : this.students.filter(s => !s.isDeleted);
        this.paginator.length = data.totalCount;
        // Log the number of currently shown records in the console
        console.log('Currently shown records:', this.dataSource.data.length);
      },
      error: (err) => {
        this.snackbar.showMessage('Error fetching students. Please try again.', 5000);
        console.error('Error fetching students:', err);
      }
    });
  }

  editStudent(id: number): void {
    this.router.navigate(['/admin/students/edit', id]);
  }

  deleteStudent(id: number): void {
    this.studentDeleteService.handleAsync(id).subscribe({
      next: () => {
        this.snackbar.showMessage('Student successfully deleted.');
        this.fetchStudents(); // Refresh the list after deletion
      },
      error: (err) => {
        this.snackbar.showMessage('Error deleting student. Please try again.', 5000);
        console.error('Error deleting student:', err);
      }
    });
  }

  openMyConfirmDialog(id: number): void {
    const dialogRef = this.dialog.open(MyDialogConfirmComponent, {
      width: '350px',
      data: {
        title: 'Confirm Delete',
        message: 'Are you sure you want to delete this student?'
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        console.log('User confirmed deletion');
        this.deleteStudent(id);
      } else {
        console.log('User cancelled deletion');
      }
    });
  }

  openStudentSemesters(id: number) {
    this.dialog.open(MyDialogSimpleComponent, {
      width: '350px',
      data: {
        title: 'Ispitni zadatak',
        message: 'Implementirajte matičnu knjigu?'
      }
    });
  }

  Toggle() {
    this.showDeleted = !this.showDeleted; // change the bool value of showDeleted
    this.fetchStudents(); // fetch the users again after change
  }
}
