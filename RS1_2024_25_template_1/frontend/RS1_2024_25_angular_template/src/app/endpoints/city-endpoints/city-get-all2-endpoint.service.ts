import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {MyConfig} from '../../my-config';
import {PagingRequest} from '../../helper/paging-request';
import {buildHttpParams} from '../../helper/http-params.helper';

export interface CityGetAll2Response {
  id: number;
  name: string;
  countryName: string;
}

@Injectable({
  providedIn: 'root'
})
export class CityGetAll2EndpointService {
  private apiUrl = `${MyConfig.api_address}/api/CityGetAll2Endpoint`;

  constructor(private httpClient: HttpClient) {
  }

  getAllCitiesPaged(request: PagingRequest): Observable<CityGetAll2Response[]> {
    const params = buildHttpParams(request);  // Use the helper function here

    return this.httpClient.get<CityGetAll2Response[]>(`${this.apiUrl}`, {params});
  }
}
