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
  selector: 'app-cities1-edit',
  templateUrl: './cities1-edit.component.html',
  styleUrls: ['./cities1-edit.component.css']
})
export class Cities1EditComponent implements OnInit {
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
      next: (countries) =>{
       console.log("podaci su preuzeti")
        this.countries = countries;
        this.countries.push({
          id:0,
          name:'--odabirite city--'
        })
        },
       
      error: (error) => console.error('Error loading countries', error)
    });
  }

  updateCity(): void {

    let errors:string[] = [];
    if (this.city.countryId == 0){
      errors.push("countryId is required");
    }

    if (this.city.name.length == 0){
      errors.push("name is required");
    }

    if (errors.length > 0)
    {
      alert("errros: " +  errors.join("\n"));
      return;
    }

    this.cityUpdateService.handleAsync({
      countryId: this.city.countryId,
      name: this.city.name,
      id: this.cityId
    }).subscribe({
      next: () => this.router.navigate(['/admin/cities1']),
      error: (error) => console.error('Error updating city', error)
    });
  }
}
