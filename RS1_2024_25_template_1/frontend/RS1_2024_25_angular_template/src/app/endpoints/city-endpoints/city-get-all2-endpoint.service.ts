import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {MyConfig} from '../../my-config';
import {MyPagedRequest} from '../../helper/my-paged-request';
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
  private apiUrl = `${MyConfig.api_address}/paged`;

  constructor(private httpClient: HttpClient) {
  }

  getAllCitiesPaged(request: MyPagedRequest): Observable<CityGetAll2Response[]> {
    const params = buildHttpParams(request);  // Use the helper function here

    return this.httpClient.get<CityGetAll2Response[]>(`${this.apiUrl}`, {params});
  }
}
