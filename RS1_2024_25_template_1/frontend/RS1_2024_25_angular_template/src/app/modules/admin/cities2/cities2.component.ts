import {Component} from '@angular/core';
import {Router} from '@angular/router';
import {
  CityGetAll1EndpointService,
  CityGetAll1Response
} from '../../../endpoints/city-endpoints/city-get-all1-endpoint.service';
import {CityDeleteEndpointService} from '../../../endpoints/city-endpoints/city-delete-endpoint.service';

@Component({
  selector: 'app-cities2',
  templateUrl: './cities2.component.html',
  styleUrls: ['./cities2.component.css'],
  standalone: false
})
export class Cities2Component {
  //ovdje je koristeno Angular Reactive forms

  cities: CityGetAll1Response[] = [];

  constructor(
    private cityGetService: CityGetAll1EndpointService,
    private cityDeleteService: CityDeleteEndpointService,
    private router: Router
  ) {
  }

  ngOnInit(): void {
    this.fetchCities();
  }

  fetchCities(): void {
    this.cityGetService.handleAsync().subscribe({
      next: (data) => (this.cities = data),
      error: (err) => console.error('Error fetching cities1:', err)
    });
  }

  editCity(id: number): void {
    this.router.navigate(['/admin/cities2/edit', id]);
  }

  deleteCity(id: number): void {
    if (confirm('Da li zelite obrisati grad?')) {
      this.cityDeleteService.handleAsync(id).subscribe({
        next: () => {
          console.log(`City with ID ${id} deleted successfully`);
          this.cities = this.cities.filter(city => city.id !== id); // Uklanjanje iz lokalne liste
        },
        error: (err) => console.error('Error deleting city:', err)
      });
    }
  }
}
