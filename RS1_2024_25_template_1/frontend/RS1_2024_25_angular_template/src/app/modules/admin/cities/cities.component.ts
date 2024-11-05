import {Component} from '@angular/core';
import {Router} from '@angular/router';
import {
  CityGetAll1EndpointService,
  CityGetAll1Response
} from '../../../endpoints/city-endpoints/city-get-all1-endpoint.service';

@Component({
  selector: 'app-cities',
  templateUrl: './cities.component.html',
  styleUrl: './cities.component.css'
})
export class CitiesComponent {
  cities: CityGetAll1Response[] = [];

  constructor(private cityService: CityGetAll1EndpointService, private router: Router) {
  }

  ngOnInit(): void {
    this.fetchCities();
  }

  fetchCities(): void {
    this.cityService.getAllCities().subscribe({
      next: (data) => this.cities = data,
      error: (err) => console.error('Error fetching cities:', err)
    });
  }

  editCity(id: number): void {
    this.router.navigate(['/admin/cities/edit', id]);
  }
}
