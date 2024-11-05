import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {MyConfig} from '../../my-config';

export interface CityGetAll1Response {
  id: number;
  name: string;
  countryName: string;
}

@Injectable({
  providedIn: 'root'
})
export class CityGetAll1EndpointService {
  private apiUrl = `${MyConfig.api_address}/api/CityGetAll1Endpoint`;

  constructor(private httpClient: HttpClient) {
  }

  getAllCities(): Observable<CityGetAll1Response[]> {
    return this.httpClient.get<CityGetAll1Response[]>(`${this.apiUrl}`);
  }
}
