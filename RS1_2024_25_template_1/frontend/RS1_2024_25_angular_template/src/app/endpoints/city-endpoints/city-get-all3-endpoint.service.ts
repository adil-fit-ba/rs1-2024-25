import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyPagedRequest} from '../../helper/my-paged-request';
import {MyConfig} from '../../my-config';
import {buildHttpParams} from '../../helper/http-params.helper';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';
import {MyPagedList} from '../../helper/my-paged-list';

export interface CityGetAll3Request extends MyPagedRequest {
  q?: string;
}

export interface CityGetAll3Response {
  id: number;
  name: string;
  countryName: string;
}

@Injectable({
  providedIn: 'root'
})
export class CityGetAll3EndpointService implements MyBaseEndpointAsync<CityGetAll3Request, MyPagedList<CityGetAll3Response>> {
  private apiUrl = `${MyConfig.api_address}/cities/filter`;

  constructor(private httpClient: HttpClient) {
  }

  handleAsync(request: CityGetAll3Request) {
    const params = buildHttpParams(request);  // Use the helper function here
    return this.httpClient.get<MyPagedList<CityGetAll3Response>>(`${this.apiUrl}`, {params});
  }
}
