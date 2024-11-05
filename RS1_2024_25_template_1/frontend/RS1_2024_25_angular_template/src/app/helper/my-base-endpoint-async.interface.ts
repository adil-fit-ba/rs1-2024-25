import {Observable} from 'rxjs';

export interface MyBaseEndpointAsync<TRequest = void, TResponse = void> {
  execute(request: TRequest): Observable<TResponse>;
}
