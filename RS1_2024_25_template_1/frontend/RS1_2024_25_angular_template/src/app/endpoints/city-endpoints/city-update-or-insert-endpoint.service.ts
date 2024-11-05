import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {MyConfig} from '../../my-config';

export interface CityUpdateOrInsertRequest {
  id?: number;  // Optional or 0 for new city insertion
  name: string;
  countryId: number;
}

export interface CityUpdateOrInsertResponse {
  id: number;
  name: string;
  countryId: number;
}

@Injectable({
  providedIn: 'root'
})
export class CityUpdateOrInsertEndpointService {
  private apiUrl = `${MyConfig.api_address}/api/CityUpdateOrInsertEndpoint`; // Match backend endpoint name

  constructor(private httpClient: HttpClient) {
  }

  saveCity(request: CityUpdateOrInsertRequest): Observable<CityUpdateOrInsertResponse> {
    return this.httpClient.post<CityUpdateOrInsertResponse>(`${this.apiUrl}`, request);
  }
}
