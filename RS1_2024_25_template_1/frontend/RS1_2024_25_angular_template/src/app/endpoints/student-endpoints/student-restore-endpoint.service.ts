import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MyConfig } from '../../my-config';
import { MyBaseEndpointAsync } from '../../helper/my-base-endpoint-async.interface';

@Injectable({
  providedIn: 'root'
})
export class StudentRestoreEndpointService implements MyBaseEndpointAsync<number, void> {
  private apiUrl = `${MyConfig.api_address}/students`;

  constructor(private httpClient: HttpClient) {}

  handleAsync(id: number) {
    return this.httpClient.post<void>(`${this.apiUrl}/${id}/restore`, null);
  }
}
