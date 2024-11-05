import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {MyConfig} from '../../my-config';

export interface CityGetByIdResponse {
  id: number;
  name: string;
  countryName: string;
  countryId: number;
}

@Injectable({
  providedIn: 'root'
})
export class CityGetByIdEndpointService {
  private apiUrl = `${MyConfig.api_address}/api/CityGetByIdEndpoint`;

  constructor(private httpClient: HttpClient) {
  }

  getCityById(id: number): Observable<CityGetByIdResponse> {
    return this.httpClient.get<CityGetByIdResponse>(`${this.apiUrl}/${id}`);
  }
}
