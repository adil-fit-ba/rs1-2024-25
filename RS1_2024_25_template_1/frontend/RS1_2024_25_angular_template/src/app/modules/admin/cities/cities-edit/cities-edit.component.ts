import {Component} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {
  CityUpdateOrInsertEndpointService
} from '../../../../endpoints/city-endpoints/city-update-or-insert-endpoint.service';
import {
  CityGetByIdEndpointService,
  CityGetByIdResponse
} from '../../../../endpoints/city-endpoints/city-get-by-id-endpoint.service';

@Component({
  selector: 'app-cities-edit',
  templateUrl: './cities-edit.component.html',
  styleUrl: './cities-edit.component.css'
})
export class CitiesEditComponent {
  cityId: number;
  city: CityGetByIdResponse = {id: 0, name: '', countryName: '', countryId: 0}; // Initialize city object

  constructor(
    private route: ActivatedRoute,
    public router: Router,
    private cityGetByIdService: CityGetByIdEndpointService,
    private cityUpdateService: CityUpdateOrInsertEndpointService
  ) {
    this.cityId = 0;
  }

  ngOnInit(): void {
    this.cityId = Number(this.route.snapshot.paramMap.get('id'));
    if (this.cityId) {
      this.loadCityData();
    }
  }

  loadCityData(): void {
    this.cityGetByIdService.getCityById(this.cityId).subscribe({
      next: (city) => this.city = city,
      error: (error) => console.error('Error loading city data', error)
    });
  }

  updateCity(): void {
    this.cityUpdateService.saveCity({
      countryId: this.city.countryId,
      name: this.city.name,
      id: this.cityId
    }).subscribe({
      next: () => this.router.navigate(['/admin/cities']),
      error: (error) => console.error('Error updating city', error)
    });
  }
}
