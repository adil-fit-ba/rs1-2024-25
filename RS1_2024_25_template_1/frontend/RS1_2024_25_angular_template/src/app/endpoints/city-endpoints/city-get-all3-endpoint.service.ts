import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {MyPagedRequest} from '../../helper/my-paged-request';
import {MyConfig} from '../../my-config';
import {buildHttpParams} from '../../helper/http-params.helper';

export interface CityGetAll3Request extends MyPagedRequest {
  filterCityName?: string;
  filterCountryName?: string;
}

export interface CityGetAll3Response {
  id: number;
  name: string;
  countryName: string;
}

@Injectable({
  providedIn: 'root'
})
export class CityGetAll3EndpointService {
  private apiUrl = `${MyConfig.api_address}/filter`;

  constructor(private httpClient: HttpClient) {
  }

  getAllCitiesPagedFiltered(request: CityGetAll3Request): Observable<CityGetAll3Response[]> {
    const params = buildHttpParams(request);  // Use the helper function here
    return this.httpClient.get<CityGetAll3Response[]>(`${this.apiUrl}`, {params});
  }
}
