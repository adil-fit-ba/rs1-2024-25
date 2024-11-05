import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {MyConfig} from '../../my-config';

@Injectable({
  providedIn: 'root'
})
export class CityDeleteEndpointService {
  private apiUrl = `${MyConfig.api_address}/api/CityDeleteEndpoint`;

  constructor(private httpClient: HttpClient) {
  }

  deleteCity(id: number): Observable<void> {
    return this.httpClient.delete<void>(`${this.apiUrl}/${id}`);
  }
}
