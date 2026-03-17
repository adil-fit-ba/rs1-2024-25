import { Injectable } from "@angular/core";
import { MyConfig } from "../../my-config";
import { HttpClient } from "@angular/common/http";
import { MyBaseEndpointAsync } from '../../helper/my-base-endpoint-async.interface';

export interface CourseLookupResponse {
  id: number;
  name: string;
}

@Injectable({
  providedIn: 'root'
})
export class CourseLookupEndpointService implements MyBaseEndpointAsync<void, CourseLookupResponse[]> {
  private apiUrl = `${MyConfig.api_address}/courses/lookup`;

  constructor(private httpClient: HttpClient) {
  }

  handleAsync() {
    return this.httpClient.get<CourseLookupResponse[]>(this.apiUrl);
  }
}
