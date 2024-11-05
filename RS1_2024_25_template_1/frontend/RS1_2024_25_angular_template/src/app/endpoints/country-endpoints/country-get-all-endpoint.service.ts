import {Injectable} from "@angular/core";
import {MyConfig} from "../../my-config";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";

export interface CountryGetAllResponse {
  id: number;
  name: string;
}

@Injectable({
  providedIn: 'root'
})
export class CountryGetAllEndpointService {
  private apiUrl = `${MyConfig.api_address}/countries/all`;

  constructor(private httpClient: HttpClient) {
  }

  getAllCountries(): Observable<CountryGetAllResponse[]> {
    return this.httpClient.get<CountryGetAllResponse[]>(this.apiUrl);
  }
}
