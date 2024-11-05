import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {
  CityUpdateOrInsertEndpointService
} from '../../../../endpoints/city-endpoints/city-update-or-insert-endpoint.service';
import {
  CityGetByIdEndpointService,
  CityGetByIdResponse
} from '../../../../endpoints/city-endpoints/city-get-by-id-endpoint.service';
import {
  CountryGetAllEndpointService,
  CountryGetAllResponse
} from '../../../../endpoints/country-endpoints/country-get-all-endpoint.service';

@Component({
  selector: 'app-cities-edit',
  templateUrl: './cities-edit.component.html',
  styleUrls: ['./cities-edit.component.css']
})
export class CitiesEditComponent implements OnInit {
  cityId: number;
  city: CityGetByIdResponse = {
    id: 0,
    name: '',
    countryId: 0
  };
  countries: CountryGetAllResponse[] = []; // Niz za pohranu svih zemalja

  constructor(
    private route: ActivatedRoute,
    public router: Router,
    private cityGetByIdService: CityGetByIdEndpointService,
    private cityUpdateService: CityUpdateOrInsertEndpointService,
    private countryGetAllService: CountryGetAllEndpointService
  ) {
    this.cityId = 0;
  }

  ngOnInit(): void {
    this.cityId = Number(this.route.snapshot.paramMap.get('id'));
    if (this.cityId) {
      this.loadCityData();
    }
    this.loadCountries(); // Učitavanje svih zemalja za combobox
  }

  loadCityData(): void {
    this.cityGetByIdService.handleAsync(this.cityId).subscribe({
      next: (city) => this.city = city,
      error: (error) => console.error('Error loading city data', error)
    });
  }

  loadCountries(): void {
    this.countryGetAllService.handleAsync().subscribe({
      next: (countries) => this.countries = countries,
      error: (error) => console.error('Error loading countries', error)
    });
  }

  updateCity(): void {
    this.cityUpdateService.handleAsync({
      countryId: this.city.countryId,
      name: this.city.name,
      id: this.cityId
    }).subscribe({
      next: () => this.router.navigate(['/admin/cities']),
      error: (error) => console.error('Error updating city', error)
    });
  }
}
